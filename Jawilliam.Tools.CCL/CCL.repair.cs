using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jawilliam.Tools.CCL
{
    partial class CCL
    {
        partial class GumTree
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="args"></param>
            /// <example>gumtree repaired-expand Forward 20 -trace=D:\ExperimentLogs\gumtree_repairedexpansion_32_42_48_10.txt -name=NativeGTtreefiedRoslynMLWithIncludeTrivia_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTrivia -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling_Forward -approach=NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling -fileFormat=20 -direction=Forward -name=NativeGTtreefiedRoslynMLAndPermissiveLabeling_Forward -approach=NativeGTtreefiedRoslynMLAndPermissiveLabeling -fileFormat=5 -direction=Forward -name=NativeGTtreefiedRoslynML_Forward -approach=NativeGTtreefiedRoslynML -fileFormat=5 -direction=Forward -from=1 -to=23</example>
            [ApplicationMetadata(Name = "repaired-expand", Description = "Repairs ...")]
            public virtual void RepairedExpand(RepairCommandArgs args)
            {
                var configurations = args.Names.Select((n, i) => new
                {
                    Name = n,
                    Approach = i < args.Approaches.Count
                       ? (ChangeDetectionApproaches)Enum.Parse(typeof(ChangeDetectionApproaches), args.Approaches[i])
                       : default(ChangeDetectionApproaches),
                    Direction = i < args.Directions.Count ? args.Directions[i] : null,
                    FileFormat = i < args.FileFormats.Count
                       ? (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FileFormats[i])
                       : default(FileFormatKind),
                });

                var fullCounterpart = new 
                {
                    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.FullFileFormat),
                    Direction = args.FullDirection
                };

                var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
                var loader = new RoslynML();
                var selector = new RoslynMLPruneSelector();

                var frpPerProjects = OnTheseConfig(args.OnThese)?.ToList();

                var expander = new DeltaExpander();
                foreach (var project in ProjectsConfig(Projects, args.From, args.To, frpPerProjects))
                {
                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;
                        var deltaIds = DeltasConfig(project.Name, 
                            from d in dbRepository.Deltas
                            where d.Report == null && d.Approach == configuration.Approach
                            select d.Id, frpPerProjects);

                        if (args.Trace != null)
                        {
                            System.IO.File.AppendAllText(args.Trace,
                                  $"{Environment.NewLine}{Environment.NewLine}" +
                                  $"{configuration.Name} repaired expanding " +
                                  $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                        }
                        int counter = 0;
                        foreach (var deltaId in deltaIds)
                        {
                            counter++;
                            var delta = dbRepository.Deltas
                                .Include("RevisionPair.FromFileVersion.Content")
                                .Include("RevisionPair.FileVersion.Content")
                                .AsNoTracking()
                                .Single(d => d.Id == deltaId);

                            var detectionResult = (DetectionResult)delta.DetectionResult;
                            if (!detectionResult.Matches.Any() && !detectionResult.Actions.Any())
                                continue;

                            var fullOriginal = fullCounterpart.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullCounterpart.FileFormat && 
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullCounterpart.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);
                            var fullModified = fullCounterpart.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullCounterpart.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fullCounterpart.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);

                            var configurationOriginal = configuration.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);
                            var configurationModified = configuration.Direction == "Forward"
                                    ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id)
                                    : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == configuration.FileFormat &&
                                                                                           ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);

                            if (fullOriginal == null || fullModified == null || configurationOriginal == null || configurationModified == null)
                                continue;

                            var xFullOriginal = XElement.Load(new StringReader(fullOriginal.XmlTree));
                            var xFullModified = XElement.Load(new StringReader(fullModified.XmlTree));
                            var xConfigurationOriginal = XElement.Load(new StringReader(configurationOriginal.XmlTree));
                            var xÇonfigurationModified = XElement.Load(new StringReader(configurationModified.XmlTree));
                            var xSeedOriginal = XElement.Load(new StringReader(configurationOriginal.XmlTree));
                            loader.Prune(xSeedOriginal, selector.PruneSelector);
                            loader.Defoliate(xSeedOriginal);
                            var xSeedModified = XElement.Load(new StringReader(configurationModified.XmlTree));
                            loader.Prune(xSeedModified, selector.PruneSelector);
                            loader.Defoliate(xSeedModified);

                            var expandedApproach = configuration.Approach + 2000;
                            var expandedDelta = dbRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == delta.RevisionPair.Id && d.Approach == expandedApproach);
                            if (expandedDelta == null)
                            {
                                var rp = dbRepository.RepositoryObjects.OfType<FileModifiedChange>().Single(frp => frp.Id == delta.RevisionPair.Id);
                                expandedDelta = new Delta { Id = Guid.NewGuid(), Approach = expandedApproach, RevisionPair = rp  };
                                dbRepository.Deltas.Add(expandedDelta);
                            }

                            if (args.Trace != null)
                            {
                                Console.WriteLine(
                                      $"{configuration.Name} repaired expanding " +
                                      $"{project.Name} - ({counter} of {deltaIds.Count}) {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)}");
                            }
                            try
                            {
                                var annotations = expandedDelta.XAnnotations;
                                RevisionPair<XElement> fullAsts = new RevisionPair<XElement> { Original = xFullOriginal, Modified = xFullModified };
                                RevisionPair<XElement> originalAsts = new RevisionPair<XElement> { Original = xConfigurationOriginal, Modified = xÇonfigurationModified };
                                RevisionPair<XElement> prunedAsts = new RevisionPair<XElement> { Original = xSeedOriginal, Modified = xSeedModified };
                                var fullDelta = SetUp(prunedAsts, originalAsts,
                                    (Matches: XElement.Parse(delta.Matching ?? "<Matches/>").Elements().Where(d => d is XNode),
                                     Actions: XElement.Parse(delta.Differencing ?? "<Actions/>").Elements().Where(d => d is XNode)));
                                var start = Environment.TickCount;
                                expander.Expand(prunedAsts, fullAsts, fullDelta);
                                annotations.RunTime = (Environment.TickCount - start).ToString(CultureInfo.InvariantCulture);
                                expandedDelta.XAnnotations = annotations;

                                if (args.Trace != null)
                                {
                                    Console.WriteLine(
                                          $"{configuration.Name} repaired expanded " +
                                          $"{project.Name} - ({counter} of {deltaIds.Count}) {DateTime.Now.ToString("F", CultureInfo.InvariantCulture)}");
                                }

                                var xMatches = new XElement("Matches", expander.FullDelta.Matches);
                                var xActions = new XElement("Actions", expander.FullDelta.Actions);

                                expandedDelta.Matching = Delta.AsSqlXColumn(xMatches);
                                expandedDelta.Differencing = Delta.AsSqlXColumn(xActions);
                            }
                            catch (Exception ex)
                            {
                                expandedDelta.Report = ex.ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><");
                            }
                            finally
                            {
                                try
                                {
                                    dbRepository.Flush(true);
                                }
                                catch (DbUpdateException ex)
                                {
                                    expandedDelta.Matching = null;
                                    expandedDelta.Differencing = null;
                                    expandedDelta.Report = typeof(DbUpdateException).Name;
                                    dbRepository.Flush(true);
                                }
                            }
                        }
                        if (args.Trace != null)
                        {
                            System.IO.File.AppendAllText(args.Trace,
                                  $"{Environment.NewLine}{Environment.NewLine}" +
                                  $"{configuration.Name} expanded " +
                                  $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                        }
                    }
                }
                Console.Out.WriteLine($"DONE!!!");
            }

            /// <summary>
            /// Computes the full delta starting from a seed one. 
            /// </summary>
            /// <param name="seedAsts">The seed AST revision pair used to generate the delta to be expanded.</param>
            /// <param name="fullAsts">The AST revision pair to use when generating the full delta.</param>
            /// <param name="fullDelta">the delta to be expanded.</param>
            /// <returns>the expanded delta.</returns>
            public static (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) SetUp(
                RevisionPair<XElement> seedAsts,
                RevisionPair<XElement> fullAsts,
                (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) fullDelta)
            {
                if (seedAsts?.Original == null) throw new ArgumentNullException("seedAsts.Original");
                if (seedAsts?.Modified == null) throw new ArgumentNullException("seedAsts.Modified");
                if (fullAsts?.Original == null) throw new ArgumentNullException("fullAsts.Original");
                if (fullAsts?.Modified == null) throw new ArgumentNullException("fullAsts.Modified");
                if (fullDelta.Matches == null) throw new ArgumentNullException("seedDelta.Matches");
                if (fullDelta.Actions == null) throw new ArgumentNullException("seedDelta.Actions");

                RevisionPair<Dictionary<string, XElement>> _seedAstsGlobal;
                RevisionPair<Dictionary<string, XElement>> _fullAsts;
                Dictionary<string, XElement> _oMatches;
                Dictionary<string, XElement> _mMatches;
                Dictionary<string, XElement> _mInserts;
                Dictionary<string, XElement> _oDeletes;
                Dictionary<string, XElement> _oUpdates;
                Dictionary<string, XElement> _oMoves;

                _seedAstsGlobal = new RevisionPair<Dictionary<string, XElement>>
                {
                    Original = seedAsts.Original.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.RmId()),
                    Modified = seedAsts.Modified.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.RmId())
                };
                _fullAsts = new RevisionPair<Dictionary<string, XElement>>
                {
                    Original = fullAsts.Original.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.GtID()),
                    Modified = fullAsts.Modified.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.GtID())
                };
                //foreach (var item in fullDelta.Matches)
                //{
                //    if (!_fullAsts.Original.ContainsKey(item.Attribute("oId").Value))
                //        ;
                //    Debug.Assert(_fullAsts.Original.ContainsKey(item.Attribute("oId").Value));
                //}

                _oMatches = fullDelta.Matches.ToDictionary(m => _fullAsts.Original[m.Attribute("oId").Value].RmId());
                _mMatches = fullDelta.Matches.ToDictionary(m => _fullAsts.Modified[m.Attribute("mId").Value].RmId());
                _mInserts = fullDelta.Actions.Where(a => a.Name.LocalName == "Insert").ToDictionary(m => _fullAsts.Modified[m.Attribute("eId").Value].RmId());
                _oDeletes = fullDelta.Actions.Where(a => a.Name.LocalName == "Delete").ToDictionary(m => _fullAsts.Original[m.Attribute("eId").Value].RmId());
                _oUpdates = fullDelta.Actions.Where(a => a.Name.LocalName == "Update").ToDictionary(m => _fullAsts.Original[m.Attribute("eId").Value].RmId());
                _oMoves = fullDelta.Actions.Where(a => a.Name.LocalName == "Move").ToDictionary(m => _fullAsts.Original[m.Attribute("eId").Value].RmId());

                var _seedDelta = (Matches: new List<XElement>(_oMatches.Count()),
                                  Actions: new List<XElement>(_mInserts.Count + _oUpdates.Count + _oMoves.Count + _oDeletes.Count));
                foreach (var mSeedElement in seedAsts.Modified.BreadthFirstOrder(n => n.Elements()
                                                                  .Where(ne => ne is XNode))
                                                                  .Where(ne => ne.Attribute("GtID")?.Value != null))
                {
                    if (_mInserts.ContainsKey(mSeedElement.RmId()))
                    {
                        _InsertSeedElement(_seedAstsGlobal, _fullAsts, _mMatches, _mInserts, _seedDelta, mSeedElement);
                    }
                    else
                    {
                        var match = _mMatches.ContainsKey(mSeedElement.RmId()) ? _mMatches[mSeedElement.RmId()] : null;
                        if (match != null)
                        {
                            var oRmID = _fullAsts.Original[match.Attribute("oId").Value].RmId();
                            var mRmID = _fullAsts.Modified[match.Attribute("mId").Value].RmId();
                            if (_seedAstsGlobal.Original.ContainsKey(oRmID) &&
                                _seedAstsGlobal.Modified.ContainsKey(mRmID))
                            {
                                var o = _seedAstsGlobal.Original[oRmID];
                                var m = _seedAstsGlobal.Modified[mRmID];
                                _seedDelta.Matches.Add(new XElement("Match",
                                    new XAttribute("oId", o.GtID()),
                                    new XAttribute("oGId", o.RmId()),
                                    new XAttribute("oLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
                                    new XAttribute("mId", m.GtID()),
                                    new XAttribute("mGId", m.RmId()),
                                    new XAttribute("mLb", m.Attribute("kind")?.Value ?? m.Name.LocalName)));
                                Debug.Assert(m.RmId() == mSeedElement.RmId());

                                if (_oUpdates.ContainsKey(o.RmId()))
                                    _seedDelta.Actions.Add(new XElement("Update",
                                        new XAttribute("eId", o.GtID()),
                                        new XAttribute("eGId", o.RmId()),
                                        new XAttribute("eLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
                                        new XAttribute("eVl", "##"),
                                        new XAttribute("val", m.Value)));

                                if (_oMoves.ContainsKey(o.RmId()))
                                {
                                    var mParent = m.Ancestors()
                                        .First(a => _seedAstsGlobal.Modified.ContainsKey(a.RmId()));
                                    _seedDelta.Actions.Add(new XElement("Move",
                                        new XAttribute("eId", o.GtID()),
                                        new XAttribute("eGId", o.RmId()),
                                        new XAttribute("eLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
                                        new XAttribute("eVl", "##"),
                                        new XAttribute("pId", mParent.GtID()),
                                        new XAttribute("pGId", mParent.RmId()),
                                        new XAttribute("pLb",
                                            mParent.Attribute("kind")?.Value ?? mParent.Name.LocalName),
                                        new XAttribute("pos", "-1")));
                                }
                            }
                            else
                            {
                                if (_seedAstsGlobal.Original.ContainsKey(oRmID))
                                    _DeleteSeedElement(_seedDelta, _seedAstsGlobal.Original[oRmID]);
                                if (_seedAstsGlobal.Modified.ContainsKey(mRmID))
                                    _InsertSeedElement(_seedAstsGlobal, _fullAsts, _mMatches,
                                        _mInserts, _seedDelta, _seedAstsGlobal.Modified[mRmID]);
                            }
                        }
                    }
                }

                foreach (var oFullElement in seedAsts.Original.PostOrder(n => n.Elements()
                                                                  .Where(ne => ne is XNode))
                                                                  .Where(ne => ne.Attribute("GtID")?.Value != null))
                {
                    if (_oDeletes.ContainsKey(oFullElement.RmId()))
                    {
                        _DeleteSeedElement(_seedDelta, oFullElement);
                    }
                }

                return _seedDelta;
            }

            private static void _DeleteSeedElement((List<XElement> Matches, List<XElement> Actions) _seedDelta, XElement oFullElement)
            {
                _seedDelta.Actions.Add(new XElement("Delete",
                                            new XAttribute("eId", oFullElement.GtID()),
                                            new XAttribute("eGId", oFullElement.RmId()),
                                            new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                                            new XAttribute("eVl", "##")));
            }

            private static void _InsertSeedElement(RevisionPair<Dictionary<string, XElement>> _seedAstsGlobal, RevisionPair<Dictionary<string, XElement>> _fullAsts, Dictionary<string, XElement> _mMatches, Dictionary<string, XElement> _mInserts, (List<XElement> Matches, List<XElement> Actions) _seedDelta, XElement mSeedElement)
            {
                var m = _seedAstsGlobal.Modified[mSeedElement.RmId()];
                var mParent = m.Ancestors().First(a => _seedAstsGlobal.Modified.ContainsKey(a.RmId()));
                var oParent = _mMatches.ContainsKey(mParent.RmId())
                    ? _seedAstsGlobal.Original[_fullAsts.Original[_mMatches[mParent.RmId()].Attribute("oId").Value].RmId()]
                    : mParent;
                _seedDelta.Actions.Add(new XElement("Insert",
                    new XAttribute("eId", m.GtID()),
                    new XAttribute("eGId", m.RmId()),
                    new XAttribute("eLb", m.Attribute("kind")?.Value ?? m.Name.LocalName),
                    new XAttribute("eVl", "##"),
                    new XAttribute("pId", oParent.GtID()),
                    new XAttribute("pGId", oParent.RmId()),
                    new XAttribute("pLb", oParent.Attribute("kind")?.Value ?? oParent.Name.LocalName),
                    new XAttribute("pos", "-1")));
            }
        }
    }

    public class RepairCommandArgs : IArgumentModel
    {
        //[Argument(Name = "originalPath")]
        //public string OriginalPath { get; set; }

        //[Argument(Name = "modifiedPath")]
        //public string ModifiedPath { get; set; }

        [Argument(Name = "fullDirection")]
        public string FullDirection { get; set; } = "Forward";

        [Argument(Name = "fullFileFormat")]
        public string FullFileFormat { get; set; }

        //[Argument(Name = "seedDirection")]
        //public string SeedDirection { get; set; } = "Forward";

        //[Argument(Name = "seedFileFormat")]
        //public string SeedFileFormat { get; set; }

        [Option(ShortName = "trace")]
        public string Trace { get; set; }

        [Option(ShortName = "name")]
        public List<string> Names { get; set; }

        [Option(ShortName = "approach")]
        public List<string> Approaches { get; set; }

        [Option(ShortName = "direction")]
        public List<string> Directions { get; set; }

        [Option(ShortName = "fileFormat")]
        public List<string> FileFormats { get; set; }

        [Option(ShortName = "onThese")]
        public string OnThese { get; set; }

        [Option(ShortName = "from")]
        public int From { get; set; } = 1;

        [Option(ShortName = "to")]
        public int To { get; set; } = 107;
    }
}
