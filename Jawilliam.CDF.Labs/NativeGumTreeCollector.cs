using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs.DBModel;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jawilliam.CDF.Labs
{
    public class NativeGumTreeCollector : FileRevisionPairAnalyzer
    {
        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void SaveRoslynMLTrees(GumTreeNativeApproach gumTree, InteropArgs interopArgs, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
              delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
              {
                  try
                  {
                      if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                          return;

                      this.SqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach).Load();

                      var delta = repositoryObject.Principal.Deltas.Single(d => d.Approach == gumTreeApproach);
                      if (delta.Report != null || (delta.OriginalTree != null && delta.ModifiedTree != null))
                          return;

                      var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                      var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                      System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                      System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                      var loader = new RoslynML();
                      var xElement = loader.Load(interopArgs.Original, true);
                      this.SetRoslynMLIDs(xElement);
                      this.SetGumTreefiedIDs(xElement);
                      delta.OriginalTree = xElement.ToString(SaveOptions.DisableFormatting);

                      xElement = loader.Load(interopArgs.Modified, true);
                      this.SetRoslynMLIDs(xElement);
                      this.SetGumTreefiedIDs(xElement);
                      delta.ModifiedTree = xElement.ToString(SaveOptions.DisableFormatting);
                  }
                  catch (Exception)
                  {
                  }
              }, true,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        private void SetRoslynMLIDs(XElement root)
        {
            int i = 0;
            foreach (var item in root.PostOrder(n => n.Elements()))
            {
                item.Add(new XAttribute("RmID", i++.ToString(CultureInfo.InvariantCulture)));
            }
        }

        private void SetGumTreefiedIDs(XElement root)
        {
            int i = 0;
            foreach (var item in root.PostOrder(n => n.Elements()).Where(n => !n.Name.LocalName.Contains("_of_") && n.Name.LocalName != "TokenList"))
            {
                item.Add(new XAttribute("GtID", i++.ToString(CultureInfo.InvariantCulture)));
            }
        }

        public virtual void MigrateRoslynMLTrees(GumTreeNativeApproach gumTree, InteropArgs interopArgs, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach && (d.OriginalTree != null || d.ModifiedTree != null)),
              delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
              {
                  if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                      return;

                  var fileFormat = FileFormatKind.Gumtreefied /*| FileFormatKind.RoslynML*/;
                  this.SqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach).Load();
                  this.SqlRepository.FileFormats.Where(ff => ff.FileVersion.Id == repositoryObject.Principal.FromFileVersion.Id && ff.Kind == fileFormat).Load();
                  this.SqlRepository.FileFormats.Where(ff => ff.FileVersion.Id == repositoryObject.Principal.FileVersion.Id && ff.Kind == fileFormat).Load();

                  var delta = repositoryObject.Principal.Deltas.Single(d => d.Approach == gumTreeApproach);
                  var originalFormat = repositoryObject.Principal.FromFileVersion.Formats.SingleOrDefault(ff => ff.Kind == fileFormat);
                  var modifiedFormat = repositoryObject.Principal.FileVersion.Formats.SingleOrDefault(ff => ff.Kind == fileFormat);

                  if (originalFormat == null)
                  {
                      originalFormat = this.SqlRepository.FileFormats.Create();
                      originalFormat.Id = Guid.NewGuid();
                      originalFormat.Kind = fileFormat;
                      originalFormat.XmlTree = delta.OriginalTree;
                      repositoryObject.Principal.FromFileVersion.Formats.Add(originalFormat);
                      delta.OriginalTree = null;
                  }
                  else
                      delta.OriginalTree = null;

                  if (modifiedFormat == null)
                  {
                      modifiedFormat = this.SqlRepository.FileFormats.Create();
                      modifiedFormat.Id = Guid.NewGuid();
                      modifiedFormat.Kind = fileFormat;
                      modifiedFormat.XmlTree = delta.ModifiedTree;
                      repositoryObject.Principal.FileVersion.Formats.Add(modifiedFormat);
                      delta.ModifiedTree = null;
                  }
                  else
                      delta.ModifiedTree = null;

                  //if (delta.Report != null || (delta.OriginalTree != null && delta.ModifiedTree != null))
                  //    return;

                  //var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                  //var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                  //System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                  //System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                  //var loader = new RoslynML();
                  //var xElement = loader.Load(interopArgs.Original, true);
                  //this.SetRoslynMLIDs(xElement);
                  //this.SetGumTreefiedIDs(xElement);
                  //delta.OriginalTree = xElement.ToString(SaveOptions.DisableFormatting);

                  //xElement = loader.Load(interopArgs.Modified, true);
                  //this.SetRoslynMLIDs(xElement);
                  //this.SetGumTreefiedIDs(xElement);
                  //delta.ModifiedTree = xElement.ToString(SaveOptions.DisableFormatting);
              }, true,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

    }
}
