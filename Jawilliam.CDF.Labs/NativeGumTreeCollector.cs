using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Domain;
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
        /// Saves RoslynML ASTs.
        /// </summary>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param> 
        /// <param name="includeTrivia">informs whether the trivia should be included, or not.</param>
        public virtual void SaveRoslynMLTrees(GumTreeNativeApproach gumTree, InteropArgs interopArgs, /*ChangeDetectionApproaches gumTreeApproach, */
            Func<FileRevisionPair, bool> skipThese,
            FileFormatKind fileFormat,
            SourceCodeCleaner cleaner = null,
            Func<XElement, bool> pruneSelector = null,
            bool includeTrivia = false)
        {
            this.Analyze(f => f.Principal.Deltas.Any(/*d => d.Approach == gumTreeApproach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null*/),
              delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
              {
                  try
                  {
                      if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                          return;

                      //this.SqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach).Load();
                      this.SqlRepository.FileFormats.Where(ff => ff.FileVersion.Id == repositoryObject.Principal.FromFileVersion.Id && ff.Kind == fileFormat).Load();
                      this.SqlRepository.FileFormats.Where(ff => ff.FileVersion.Id == repositoryObject.Principal.FileVersion.Id && ff.Kind == fileFormat).Load();

                      //var delta = repositoryObject.Principal.Deltas.Single(d => d.Approach == gumTreeApproach);
                      var originalFormat = repositoryObject.Principal.FromFileVersion.Formats.SingleOrDefault(ff => ff.Kind == fileFormat);
                      var modifiedFormat = repositoryObject.Principal.FileVersion.Formats.SingleOrDefault(ff => ff.Kind == fileFormat);

                      var roslynMlServices = new RoslynML();
                      XElement xElement;
                      if (originalFormat == null)
                      {
                          originalFormat = this.SqlRepository.FileFormats.Create();
                          originalFormat.Id = Guid.NewGuid();
                          originalFormat.Kind = fileFormat;

                          var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                          System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());

                          xElement = roslynMlServices.GetTree(interopArgs.Original, true, includeTrivia);
                          if (pruneSelector != null)
                              roslynMlServices.Prune(xElement, pruneSelector);
                          originalFormat.XmlTree = xElement.ToString(SaveOptions.DisableFormatting);

                          repositoryObject.Principal.FromFileVersion.Formats.Add(originalFormat);
                      }

                      if (modifiedFormat == null)
                      {
                          modifiedFormat = this.SqlRepository.FileFormats.Create();
                          modifiedFormat.Id = Guid.NewGuid();
                          modifiedFormat.Kind = fileFormat;

                          var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                          System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                          xElement = roslynMlServices.GetTree(interopArgs.Modified, true, includeTrivia);
                          if (pruneSelector != null)
                              roslynMlServices.Prune(xElement, pruneSelector);
                          modifiedFormat.XmlTree = xElement.ToString(SaveOptions.DisableFormatting);

                          repositoryObject.Principal.FileVersion.Formats.Add(modifiedFormat);
                      }
                  }
                  catch (Exception)
                  {
                  }
              }, true,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
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
