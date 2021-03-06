﻿using CommandDotNet;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <example>RoslynML C:\Users\gdelator\AppData\Local\Temp\gumtree9036915333579494655.cs --gumtreefy --pruning=Basic --defoliate</example>
        [ApplicationMetadata(Name = "RoslynML", Description = "...")]
        public virtual void RoslynML(RoslynMLSaveTreesCommandArgs args)
        {
            SharedRoslynML(args);
        }

        public static void SharedRoslynML(RoslynMLSaveTreesCommandArgs args)
        {
            try
            {
                var loader = new RoslynML();
                var xElement = loader.GetTree(args.FullPath, true, args.IncludeTrivia);

                if (args.Pruning != null)
                {
                    Func<XElement, bool> pruneSelector = null;
                    pruneSelector = CCL.GetPruneSelector(args.Pruning);
                    loader.Prune(xElement, pruneSelector);
                }

                if (args.Defoliate)
                    loader.Defoliate(xElement);

                if (args.Gumtreefy)
                    xElement = loader.Gumtreefy(xElement, args.TypeBasedLabels);

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

        private static Func<XElement, bool> GetPruneSelector(string args)
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

        [Option(LongName = "defoliate")]
        public bool Defoliate { get; set; }

        [Option(LongName = "typeBasedLabels")]
        public bool TypeBasedLabels { get; set; } = false;
    }
}
