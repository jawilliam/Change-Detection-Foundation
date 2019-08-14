using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jawilliam.Tools.CCL
{
    partial class CCL
    {
        [ApplicationMetadata(Name = "RoslynML", Description = "...")]
        public virtual void RoslynML(RoslynMLSaveTreesCommandArgs args)
        {
            try
            {
                var loader = new RoslynML();
                var xElement = loader.GetTree(args.FullPath, true, args.IncludeTrivia);

                if (args.Pruning != null)
                {
                    Func<XElement, bool> pruneSelector = null;
                    pruneSelector = this.GetPruneSelector(args.Pruning);
                    loader.Prune(xElement, pruneSelector);
                }

                if (args.Gumtreefy)
                    xElement = loader.Gumtreefy(xElement);

                if (args.SaveToFile != null)
                {
                    System.IO.File.WriteAllText(args.SaveToFile, xElement.ToString());
                }
                else
                {
                    Console.WriteLine(xElement.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private Func<XElement, bool> GetPruneSelector(string args)
        {
            Func<XElement, bool> pruneSelector;
            switch (args)
            {
                case "Basic":
                    var selector = new RoslynMLPruneSelector();
                    pruneSelector = e => selector.PruneSelector(e);
                    break;
                default: throw new ArgumentException(args);
            }

            return pruneSelector;
        }
    }

    public class RoslynMLSaveTreesCommandArgs : IArgumentModel
    {
        [Argument(Name = "fullPath")]
        public string FullPath { get; set; }

        [Option(LongName = "pruning")]
        public string Pruning { get; set; }

        [Option(LongName = "gumtreefy")]
        public bool Gumtreefy { get; set; }

        [Option(LongName = "saveToFile")]
        public string SaveToFile { get; set; }

        [Option(LongName = "includeTrivia")]
        public bool IncludeTrivia { get; set; }
    }
}
