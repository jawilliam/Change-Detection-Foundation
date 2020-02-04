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

                //var seedCounterpart = new
                //{
                //    FileFormat = (FileFormatKind)Enum.Parse(typeof(FileFormatKind), args.SeedFileFormat),
                //    Direction = args.SeedDirection
                //};

                var analyzer = new FileRevisionPairAnalyzer { MillisecondsTimeout = 600000 };
                var loader = new RoslynML();
                var selector = new RoslynMLPruneSelector();

                (string project, Guid frpId)[] frpPerProjects = null;
                if (args.OnThese != null)
                {
                    frpPerProjects = System.IO.File.ReadAllLines(args.OnThese).Skip(1)
                        .Select<string, (string project, Guid frpId)>(delegate(string line, int i)
                        {
                            var values = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (values == null || values.Length != 2)
                                throw new ApplicationException($"Bad formed entry: line {i}.");

                            return (values[1], Guid.Parse(values[0]));
                        }).ToArray();
                }

                var expander = new DeltaExpander();
                foreach (var project in Projects.Skip(args.From - 1).Take(args.To - (args.From - 1)))
                {
                    foreach (var configuration in configurations)
                    {
                        var dbRepository = new GitRepository(project.Name) { Name = project.Name };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                        var deltaIds = (from d in dbRepository.Deltas
                                        where d.Report == null && d.Approach == configuration.Approach
                                        select d.Id).ToList();

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

                            //var seedOriginal = seedCounterpart.Direction == "Forward"
                            //        ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == seedCounterpart.FileFormat &&
                            //                                                               ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id)
                            //        : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == seedCounterpart.FileFormat &&
                            //                                                               ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);
                            //var seedModified = seedCounterpart.Direction == "Forward"
                            //        ? dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == seedCounterpart.FileFormat &&
                            //                                                               ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id)
                            //        : dbRepository.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == seedCounterpart.FileFormat &&
                            //                                                               ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);

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
                            //var xSeedOriginal = XElement.Load(new StringReader(seedOriginal.XmlTree));
                            //var xSeedModified = XElement.Load(new StringReader(seedModified.XmlTree));
                            var xConfigurationOriginal = XElement.Load(new StringReader(configurationOriginal.XmlTree));
                            var xÇonfigurationModified = XElement.Load(new StringReader(configurationModified.XmlTree));
                            var xSeedOriginal = XElement.Load(new StringReader(configurationOriginal.XmlTree));
                            loader.Prune(xSeedOriginal, selector.PruneSelector);
                            loader.Defoliate(xSeedOriginal);
                            var xSeedModified = XElement.Load(new StringReader(configurationModified.XmlTree));
                            loader.Prune(xSeedModified, selector.PruneSelector);
                            loader.Defoliate(xSeedModified);

                            var expandedApproach = configuration.Approach + 1000;
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
                                var fullDelta = this.SetUp(prunedAsts, originalAsts,
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
                                dbRepository.Flush(true); ///TODO: run it first, save it later.
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
            private (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) SetUp(
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

                RevisionPair<Dictionary<string, XElement>> _seedAsts;
                RevisionPair<Dictionary<string, XElement>> _seedAstsGlobal;
                RevisionPair<Dictionary<string, XElement>> _fullAsts;
                RevisionPair<Dictionary<string, XElement>> _fullAstsGlobal;
                //RevisionPair<Dictionary<string, XElement>> _fullAstsGlobal;
                //(IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) _seedDelta;
                //(List<XElement> Matches, List<XElement> Actions) _fullDelta;
                Dictionary<string, XElement> _oMatches;
                Dictionary<string, XElement> _mMatches;
                Dictionary<string, XElement> _mInserts;
                Dictionary<string, XElement> _oDeletes;
                Dictionary<string, XElement> _oUpdates;
                Dictionary<string, XElement> _oMoves;

                //try
                //{
                _seedAsts = new RevisionPair<Dictionary<string, XElement>>
                {
                    Original = seedAsts.Original.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.GtID()),
                    Modified = seedAsts.Modified.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.GtID())
                };
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
                _fullAstsGlobal = new RevisionPair<Dictionary<string, XElement>>
                {
                    Original = fullAsts.Original.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.RmId()),
                    Modified = fullAsts.Modified.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.RmId())
                };
                //_fullAstsGlobal = new RevisionPair<Dictionary<string, XElement>>
                //{
                //    Original = fullAsts.Original.PostOrder(n => n.Elements()
                //        .Where(ne => ne is XNode))
                //        //.Where(ne => ne.Attribute("GtID")?.Value != null)
                //        .ToDictionary(n => n.RmId()),
                //    Modified = fullAsts.Modified.PostOrder(n => n.Elements()
                //        .Where(ne => ne is XNode))
                //        //.Where(ne => ne.Attribute("GtID")?.Value != null)
                //        .ToDictionary(n => n.RmId())
                //};

                _oMatches = fullDelta.Matches.ToDictionary(m => _fullAsts.Original[m.Attribute("oId").Value].RmId());
                _mMatches = fullDelta.Matches.ToDictionary(m => _fullAsts.Modified[m.Attribute("mId").Value].RmId());
                _mInserts = fullDelta.Actions.Where(a => a.Name.LocalName == "Insert").ToDictionary(m => _fullAsts.Modified[m.Attribute("eId").Value].RmId());
                _oDeletes = fullDelta.Actions.Where(a => a.Name.LocalName == "Delete").ToDictionary(m => _fullAsts.Original[m.Attribute("eId").Value].RmId());
                _oUpdates = fullDelta.Actions.Where(a => a.Name.LocalName == "Update").ToDictionary(m => _fullAsts.Original[m.Attribute("eId").Value].RmId());
                _oMoves = fullDelta.Actions.Where(a => a.Name.LocalName == "Move").ToDictionary(m => _fullAsts.Original[m.Attribute("eId").Value].RmId());

                var _seedDelta = (Matches: new List<XElement>(_oMatches.Count()),
                                  Actions: new List<XElement>(_mInserts.Count + _oUpdates.Count + _oMoves.Count + _oDeletes.Count));
                foreach (var mSeedElement in seedAsts.Modified.PreOrder(n => n.Elements()
                                                                  .Where(ne => ne is XNode))
                                                                  .Where(ne => ne.Attribute("GtID")?.Value != null))
                {
                    if (_mInserts.ContainsKey(mSeedElement.RmId()))
                    {
                        var insert = _mInserts[mSeedElement.RmId()];
                        var m = _seedAstsGlobal.Modified[mSeedElement.RmId()];
                        var mParent = m.Ancestors().First(a => _seedAstsGlobal.Modified.ContainsKey(a.RmId()));
                        var oParent = _mMatches.ContainsKey(mParent.RmId()) ? _mMatches[mParent.RmId()] : mParent;
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
                    else
                    {
                        var match = _mMatches[mSeedElement.RmId()];
                        var o = _seedAstsGlobal.Original[_fullAsts.Original[match.Attribute("oId").Value].RmId()];
                        var m = _seedAstsGlobal.Modified[_fullAsts.Modified[match.Attribute("mId").Value].RmId()];
                        _seedDelta.Matches.Add(new XElement("Match",
                            new XAttribute("oId", o.GtID()),
                            new XAttribute("oGId", o.RmId()),
                            new XAttribute("oLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
                            new XAttribute("mId", m.GtID()),
                            new XAttribute("mGId", m.RmId()),
                            new XAttribute("mLb", m.Attribute("kind")?.Value ?? m.Name.LocalName),
                            new XAttribute("expanded", true)));
                        Debug.Assert(m.RmId() == mSeedElement.RmId());

                        if (_oUpdates.ContainsKey(o.RmId()))
                            _seedDelta.Actions.Add(new XElement("Update",
                                new XAttribute("eId", o.GtID()),
                                new XAttribute("eGId", o.RmId()),
                                new XAttribute("eLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
                                new XAttribute("eVl", "##"),
                                new XAttribute("val", m.Value),
                                new XAttribute("expanded", true)));

                        if (_oMoves.ContainsKey(o.RmId()))
                        {
                            var oParent = o.Ancestors().First(a => _seedAstsGlobal.Original.ContainsKey(a.RmId()));
                            var mParent = _oMatches[oParent.RmId()];
                            _seedDelta.Actions.Add(new XElement("Move",
                                new XAttribute("eId", o.GtID()),
                                new XAttribute("eGId", o.RmId()),
                                new XAttribute("eLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
                                new XAttribute("eVl", "##"),
                                new XAttribute("pId", mParent.GtID()),
                                new XAttribute("pGId", mParent.RmId()),
                                new XAttribute("pLb", mParent.Attribute("kind")?.Value ?? mParent.Name.LocalName),
                                new XAttribute("pos", "-1")));
                        }
                    }
                }

                foreach (var oFullElement in seedAsts.Original.PreOrder(n => n.Elements()
                                                                  .Where(ne => ne is XNode))
                                                                  .Where(ne => ne.Attribute("GtID")?.Value != null))
                {
                    if (_oDeletes.ContainsKey(oFullElement.RmId()))
                    {
                        _seedDelta.Actions.Add(new XElement("Delete",
                            new XAttribute("eId", oFullElement.GtID()),
                            new XAttribute("eGId", oFullElement.RmId()),
                            new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                            new XAttribute("eVl", "##")));
                    }
                }

                return _seedDelta;
                //}
            }

            ///// <summary>
            ///// Computes the full delta starting from a seed one. 
            ///// </summary>
            ///// <param name="seedAsts">The seed AST revision pair used to generate the delta to be expanded.</param>
            ///// <param name="fullAsts">The AST revision pair to use when generating the full delta.</param>
            ///// <param name="fullDelta">the delta to be expanded.</param>
            ///// <returns>the expanded delta.</returns>
            //private (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) SetUp(
            //    RevisionPair<XElement> seedAsts,
            //    RevisionPair<XElement> fullAsts,
            //    (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) fullDelta)
            //{
            //    if (seedAsts?.Original == null) throw new ArgumentNullException("seedAsts.Original");
            //    if (seedAsts?.Modified == null) throw new ArgumentNullException("seedAsts.Modified");
            //    if (fullAsts?.Original == null) throw new ArgumentNullException("fullAsts.Original");
            //    if (fullAsts?.Modified == null) throw new ArgumentNullException("fullAsts.Modified");
            //    if (fullDelta.Matches == null) throw new ArgumentNullException("seedDelta.Matches");
            //    if (fullDelta.Actions == null) throw new ArgumentNullException("seedDelta.Actions");

            //    RevisionPair<Dictionary<string, XElement>> _seedAsts;
            //    RevisionPair<Dictionary<string, XElement>> _seedAstsGlobal;
            //    RevisionPair<Dictionary<string, XElement>> _fullAsts;
            //    RevisionPair<Dictionary<string, XElement>> _fullAstsGlobal;
            //    //(IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) _seedDelta;
            //    //(List<XElement> Matches, List<XElement> Actions) _fullDelta;
            //    Dictionary<string, XElement> _oMatches;
            //    Dictionary<string, XElement> _mMatches;
            //    Dictionary<string, XElement> _mInserts;
            //    Dictionary<string, XElement> _oDeletes;
            //    Dictionary<string, XElement> _oUpdates;
            //    Dictionary<string, XElement> _oMoves;

            //    //try
            //    //{
            //    _seedAsts = new RevisionPair<Dictionary<string, XElement>>
            //    {
            //        Original = seedAsts.Original.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            .Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.GtID()),
            //        Modified = seedAsts.Modified.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            .Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.GtID())
            //    };
            //    _seedAstsGlobal = new RevisionPair<Dictionary<string, XElement>>
            //    {
            //        Original = seedAsts.Original.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            .Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.RmId()),
            //        Modified = seedAsts.Modified.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            .Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.RmId())
            //    };
            //    _fullAsts = new RevisionPair<Dictionary<string, XElement>>
            //    {
            //        Original = fullAsts.Original.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            .Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.GtID()),
            //        Modified = fullAsts.Modified.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            .Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.GtID())
            //    };
            //    _fullAstsGlobal = new RevisionPair<Dictionary<string, XElement>>
            //    {
            //        Original = fullAsts.Original.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            //.Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.RmId()),
            //        Modified = fullAsts.Modified.PostOrder(n => n.Elements()
            //            .Where(ne => ne is XNode))
            //            //.Where(ne => ne.Attribute("GtID")?.Value != null)
            //            .ToDictionary(n => n.RmId())
            //    };

            //    _oMatches = fullDelta.Matches.ToDictionary(m => _seedAsts.Original[m.Attribute("oId").Value].RmId());
            //    _mMatches = fullDelta.Matches.ToDictionary(m => _seedAsts.Modified[m.Attribute("mId").Value].RmId());
            //    _mInserts = fullDelta.Actions.Where(a => a.Name.LocalName == "Insert").ToDictionary(m => _seedAsts.Modified[m.Attribute("eId").Value].RmId());
            //    _oDeletes = fullDelta.Actions.Where(a => a.Name.LocalName == "Delete").ToDictionary(m => _seedAsts.Original[m.Attribute("eId").Value].RmId());
            //    _oUpdates = fullDelta.Actions.Where(a => a.Name.LocalName == "Update").ToDictionary(m => _seedAsts.Original[m.Attribute("eId").Value].RmId());
            //    _oMoves = fullDelta.Actions.Where(a => a.Name.LocalName == "Move").ToDictionary(m => _seedAsts.Original[m.Attribute("eId").Value].RmId());

            //    foreach (var mFullElement in seedAsts.Modified.PreOrder(n => n.Elements()
            //                                                  .Where(ne => ne is XNode))
            //                                                  .Where(ne => ne.Attribute("GtID")?.Value != null))
            //    {
            //        if (_mMatches.ContainsKey(mFullElement.RmId()))
            //        {
            //            var match = _mMatches[mFullElement.RmId()];
            //            var o = _fullAstsGlobal.Original[_fullAsts.Original[match.Attribute("oId").Value].RmId()];
            //            var m = _fullAstsGlobal.Modified[_fullAsts.Modified[match.Attribute("mId").Value].RmId()];
            //            Debug.Assert(mFullElement.RmId() == o.RmId());

            //            _oMatches.Remove(o.RmId());
            //            if (_oUpdates.ContainsKey(o.RmId()))
            //                _oUpdates.Remove(o.RmId());
            //            if (_oMoves.ContainsKey(o.RmId()))
            //                _oMoves.Remove(o.RmId());

            //            _oDeletes.Add(o.RmId(),
            //                new XElement("Delete",
            //                    new XAttribute("eId", o.GtID()),
            //                    new XAttribute("eLb", o.Attribute("kind")?.Value ?? o.Name.LocalName),
            //                    new XAttribute("eVl", "##"),
            //                    new XAttribute("toRepair", true)));

            //            _mInserts.Add(m.RmId(),
            //                new XElement("Insert",
            //                    new XAttribute("eId", m.GtID()),
            //                    new XAttribute("eLb", m.Attribute("kind")?.Value ?? m.Name.LocalName),
            //                    new XAttribute("eVl", "##"),
            //                    new XAttribute("pId", m.GtID()),
            //                    new XAttribute("pLb", m.Attribute("kind")?.Value ?? m.Name.LocalName),
            //                    new XAttribute("pos", "-1"),
            //                    new XAttribute("toRepair", true)));
            //        }
            //    }
            //    foreach (var oFullElement in fullAsts.Original.PreOrder(n => n.Elements()
            //                                                  .Where(ne => ne is XNode))
            //                                                  .Where(ne => ne.Attribute("GtID")?.Value != null))
            //    {
            //        if (_oMatches.ContainsKey(oFullElement.RmId()))
            //        {
            //            var match = _oMatches[oFullElement.RmId()];
            //            var o = _fullAstsGlobal.Original[_fullAsts.Original[match.Attribute("oId").Value].RmId()];
            //            var m = _fullAstsGlobal.Modified[_fullAsts.Modified[match.Attribute("mId").Value].RmId()];

            //            _oMatches.Remove(oFullElement.RmId());
            //            if (_oUpdates.ContainsKey(oFullElement.RmId()))
            //                _oUpdates.Remove(oFullElement.RmId());
            //            if (_oMoves.ContainsKey(oFullElement.RmId()))
            //                _oMoves.Remove(oFullElement.RmId());

            //            _oDeletes.Add(oFullElement.RmId(),
            //                new XElement("Delete",
            //                    new XAttribute("eId", oFullElement.GtID()),
            //                    new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
            //                    new XAttribute("eVl", "##"),
            //                    new XAttribute("toRepair", true)));

            //            _mInserts.Add(m.RmId(),
            //                new XElement("Insert",
            //                    new XAttribute("eId", m.GtID()),
            //                    new XAttribute("eLb", m.Attribute("kind")?.Value ?? m.Name.LocalName),
            //                    new XAttribute("eVl", "##"),
            //                    new XAttribute("pId", m.GtID()),
            //                    new XAttribute("pLb", m.Attribute("kind")?.Value ?? m.Name.LocalName),
            //                    new XAttribute("pos", "-1"),
            //                    new XAttribute("toRepair", true)));
            //        }
            //    }

            //    var _fullDelta = (Matches: new List<XElement>(_oMatches.Count()),
            //                      Actions: new List<XElement>(_mInserts.Count + _oUpdates.Count + _oMoves.Count + _oDeletes.Count));
            //    foreach (var mFullElement in fullAsts.Modified.PreOrder(n => n.Elements()
            //                                                      .Where(ne => ne is XNode))
            //                                                      .Where(ne => ne.Attribute("GtID")?.Value != null))
            //    {
            //        if (_mInserts.ContainsKey(mFullElement.RmId()))
            //        {
            //            _fullDelta.Actions.Add(_mInserts[mFullElement.RmId()]);
            //        }
            //        else
            //        {
            //            var match = _mMatches[mFullElement.RmId()];
            //            var o = _fullAstsGlobal.Original[_fullAsts.Original[match.Attribute("oId").Value].RmId()];
            //            var m = _fullAstsGlobal.Modified[_fullAsts.Modified[match.Attribute("mId").Value].RmId()];
            //            _fullDelta.Matches.Add(_mMatches[mFullElement.RmId()]);

            //            if (_oUpdates.ContainsKey(o.RmId()))
            //                _fullDelta.Actions.Add(_oUpdates[o.RmId()]);

            //            if (_oMoves.ContainsKey(o.RmId()))
            //                _fullDelta.Actions.Add(_oMoves[o.RmId()]);
            //        }
            //    }

            //    foreach (var oFullElement in fullAsts.Original.PreOrder(n => n.Elements()
            //                                                      .Where(ne => ne is XNode))
            //                                                      .Where(ne => ne.Attribute("GtID")?.Value != null))
            //    {
            //        if (_oDeletes.ContainsKey(oFullElement.RmId()))
            //        {
            //            _fullDelta.Actions.Add(_oDeletes[oFullElement.RmId()]);
            //        }
            //    }

            //    return _fullDelta;
            //    //}
            //}
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
