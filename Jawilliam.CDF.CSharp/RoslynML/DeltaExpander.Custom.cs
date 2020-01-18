using Jawilliam.CDF.Approach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    /// <summary>
    /// Computes the full delta starting from a seed one.
    /// </summary>
    public partial class DeltaExpander
    {
        /// <summary>
        /// Gets the seed AST revision pair used to generate the delta to be expanded.
        /// </summary>
        public virtual RevisionPair<Dictionary<string, XElement>> SeedAsts { get; internal set; }

        /// <summary>
        /// Gets the seed AST revision pair used to generate the delta to be expanded (but indexed by the global id).
        /// </summary>
        public virtual RevisionPair<Dictionary<string, XElement>> SeedAstsGlobal { get; internal set; }

        /// <summary>
        /// Gets the AST revision pair to use when generating the full delta.
        /// </summary>
        public virtual RevisionPair<Dictionary<string, XElement>> FullAsts { get; internal set; }

        /// <summary>
        /// Gets the delta to be expanded.
        /// </summary>
        public virtual (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) SeedDelta { get; internal set; }

        /// <summary>
        /// Gets the delta being or finally expanded.
        /// </summary>
        public virtual (List<XElement> Matches, List<XElement> Actions) FullDelta { get; internal set; }

        /// <summary>
        /// Gets or sets a dictionary to look for the match info of an original element, in case it is matched.
        /// </summary>
        protected virtual Dictionary<string, XElement> OMatches { get; set; }

        /// <summary>
        /// Gets or sets a dictionary to look for the match info of an original element, in case it has been matched.
        /// </summary>
        protected virtual Dictionary<string, XElement> MMatches { get; set; }

        /// <summary>
        /// Gets or sets a dictionary to look for the insert operation of a (modified) element, in case it has been inserted.
        /// </summary>
        protected virtual Dictionary<string, XElement> MInserts { get; set; }

        /// <summary>
        /// Gets or sets a dictionary to look for the insert operation of a (modified) element, in case it has been inserted.
        /// </summary>
        protected virtual Dictionary<string, XElement> ODeletes { get; set; }

        /// <summary>
        /// Gets or sets a dictionary to look for the insert operation of a (modified) element, in case it has been inserted.
        /// </summary>
        protected virtual Dictionary<string, XElement> OUpdates { get; set; }

        /// <summary>
        /// Gets or sets a dictionary to look for the insert operation of a (modified) element, in case it has been inserted.
        /// </summary>
        protected virtual Dictionary<string, XElement> OMoves { get; set; }

        /// <summary>
        /// Computes the full delta starting from a seed one. 
        /// </summary>
        /// <param name="seedAsts">The seed AST revision pair used to generate the delta to be expanded.</param>
        /// <param name="fullAsts">The AST revision pair to use when generating the full delta.</param>
        /// <param name="seedDelta">the delta to be expanded.</param>
        /// <returns>the expanded delta.</returns>
        public virtual (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) Expand(RevisionPair<XElement> seedAsts, RevisionPair<XElement> fullAsts, (IEnumerable<XElement> Matches, IEnumerable<XElement> Actions) seedDelta)
        {
            if (seedAsts?.Original == null) throw new ArgumentNullException("seedAsts.Original");
            if (seedAsts?.Modified == null) throw new ArgumentNullException("seedAsts.Modified");
            if (fullAsts?.Original == null) throw new ArgumentNullException("fullAsts.Original");
            if (fullAsts?.Modified == null) throw new ArgumentNullException("fullAsts.Modified");
            if (seedDelta.Matches == null) throw new ArgumentNullException("seedDelta.Matches");
            if (seedDelta.Actions == null) throw new ArgumentNullException("seedDelta.Actions");

            try
            {
                this.SeedAsts = new RevisionPair<Dictionary<string, XElement>>
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
                this.SeedAstsGlobal = new RevisionPair<Dictionary<string, XElement>>
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
                this.FullAsts = new RevisionPair<Dictionary<string, XElement>>
                {
                    Original = fullAsts.Original.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        //.Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.RmId()),
                    Modified = fullAsts.Modified.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        //.Where(ne => ne.Attribute("GtID")?.Value != null)
                        .ToDictionary(n => n.RmId())
                };

                this.OMatches = seedDelta.Matches.ToDictionary(m => this.SeedAsts.Original[m.Attribute("oId").Value].RmId());
                this.MMatches = seedDelta.Matches.ToDictionary(m => this.SeedAsts.Modified[m.Attribute("mId").Value].RmId());
                this.MInserts = seedDelta.Actions.Where(a => a.Name.LocalName == "Insert").ToDictionary(m => this.SeedAsts.Modified[m.Attribute("eId").Value].RmId());
                this.ODeletes = seedDelta.Actions.Where(a => a.Name.LocalName == "Delete").ToDictionary(m => this.SeedAsts.Original[m.Attribute("eId").Value].RmId());
                this.OUpdates = seedDelta.Actions.Where(a => a.Name.LocalName == "Update").ToDictionary(m => this.SeedAsts.Original[m.Attribute("eId").Value].RmId());

                this.FullDelta = (new List<XElement>(seedDelta.Matches), new List<XElement>(seedDelta.Actions));

                foreach (var mSeedElement in seedAsts.Modified.PreOrder(n => n.Elements()
                                                              .Where(ne => ne is XNode))
                                                              .Where(ne => ne.Attribute("GtID")?.Value != null))
                {
                    ForEachM(mSeedElement);
                }
                foreach (var oSeedElement in seedAsts.Original.PreOrder(n => n.Elements()
                                                              .Where(ne => ne is XNode))
                                                              .Where(ne => ne.Attribute("GtID")?.Value != null))
                {
                    ForEachO(oSeedElement);
                }

                this.FullDelta = (
                    new List<XElement>(this.FullDelta.Matches), 
                    new List<XElement>(this.FullDelta.Actions.Where(a => 
                        a.Name.LocalName != "Update" ||
                        a.Attribute("expanded")?.Value != null ||
                        this.OUpdates.ContainsKey(this.SeedAsts.Original[a.Attribute("eId").Value].RmId())).ToList())
                );

                return this.FullDelta;
            }
            finally
            {
                this.SeedAsts = null;
                this.SeedAstsGlobal = null;
                this.OMatches = null;
                this.MMatches = null;
                this.MInserts = null;
                this.ODeletes = null;
                this.OUpdates = null;
            }
        }

        private void ForEachO(XElement oSeedElement)
        {
            var oFullElement = this.FullAsts.Original[/*this.SeedAsts.Original[oSeedElement.GtID()]*/oSeedElement.RmId()];
            if (this.ODeletes.ContainsKey(oSeedElement.RmId()))
                this.ResolveDefoliatedChildren(this.UnmatchedOriginal(oFullElement).ToList());
        }

        private void ForEachM(XElement mSeedElement)
        {
            var mFullElement = this.FullAsts.Modified[/*this.SeedAsts.Modified[mSeedElement.GtID()]*/mSeedElement.RmId()];
            if (this.MInserts.ContainsKey(mSeedElement.RmId()))
                this.ResolveDefoliatedChildren(this.UnmatchedModified(mFullElement).ToList());
            else if (this.MMatches.ContainsKey(mSeedElement.RmId()))
            {
                var match = this.MMatches[mSeedElement.RmId()];
                string oId = match.Attribute("oId").Value;
                var oFullElement = match.Attribute("expanded")?.Value != null
                    ? this.FullAsts.Original[match.Attribute("oGId").Value]
                    : this.FullAsts.Original[this.SeedAsts.Original[oId].RmId()];
                this.ResolveDefoliatedChildren(this.Matched(oFullElement, mFullElement).ToList());

                if (mSeedElement.Name.LocalName != "Token" &&
                    mSeedElement.Elements().Count() == 0 &&
                    this.OUpdates.ContainsKey(oFullElement.RmId()) &&
                    this.OMatches.ContainsKey(oFullElement.RmId()) &&
                    this.OMatches[oFullElement.RmId()].Attribute("mId")?.Value == mSeedElement.GtID())
                {
                    var defoliationRemovedDescendants = oFullElement.PostOrder(n => n.Elements()
                       .Where(ne => ne is XNode))
                       .Where(ne => ne != oFullElement && ne.Attribute("GtID")?.Value != null).ToList();

                    if (defoliationRemovedDescendants.Any(drd => this.OUpdates.ContainsKey(drd.RmId())))
                        this.OUpdates.Remove(oFullElement.RmId());
                }                    
            }
        }

        private void ResolveDefoliatedChildren(IEnumerable<XElement> facts)
        {
            foreach (var fact in facts)
            {
                switch (fact.Name.LocalName)
                {
                    case "Insert":
                        //var insertedChild = this.SeedAsts.Modified.ContainsKey(fact.Attribute("eId").Value)
                        //    ? this.SeedAsts.Modified[fact.Attribute("eId").Value]
                        //    : null;
                        if (fact.Attribute("eLb").Value != "Token" && !this.SeedAsts.Modified.ContainsKey(fact.Attribute("eId").Value)) // then it is a defoliated element.
                            this.ForEachM(this.FullAsts.Modified[fact.Attribute("eGId").Value]);
                        break;
                    case "Delete":
                        //var deletedChild = this.FullAsts.Original[this.SeedAsts.Original[fact.Attribute("eId").Value].RmId()];
                        if (fact.Attribute("eLb").Value != "Token" && !this.SeedAsts.Original.ContainsKey(fact.Attribute("eId").Value)) // then it is a defoliated element.
                            this.ForEachO(this.FullAsts.Original[fact.Attribute("eGId").Value]);
                        break;
                    case "Match":
                        //var mChild = this.FullAsts.Modified[this.SeedAsts.Modified[fact.Attribute("mId").Value].RmId()]; 
                        if (fact.Attribute("mLb").Value != "Token" && !this.SeedAsts.Modified.ContainsKey(fact.Attribute("mId").Value))
                            this.ForEachM(this.FullAsts.Modified[fact.Attribute("mGId").Value]);
                        break;
                }
            }
        }

        /// <summary>
        /// Expands an insert action. 
        /// </summary>
        /// <param name="mFullChild">inserted element.</param>
        /// <param name="fullParent">parent of the inserted element.</param>
        /// <returns>The expanded insert action.</returns>
        public virtual XElement InsertIfAvailable(XElement mFullChild, XElement fullParent)
        {
            if (!this.MInserts.ContainsKey(mFullChild.RmId()) && !this.MMatches.ContainsKey(mFullChild.RmId()))
            {
                var insert = new XElement("Insert",
                new XAttribute("eId", mFullChild.GtID()), 
                new XAttribute("eGId", mFullChild.RmId()),
                new XAttribute("eLb", mFullChild.Attribute("kind")?.Value ?? mFullChild.Name.LocalName),
                new XAttribute("eVl", "##"),
                new XAttribute("pId", fullParent.GtID()),
                new XAttribute("pGId", fullParent.RmId()),
                new XAttribute("pLb", fullParent.Attribute("kind")?.Value ?? fullParent.Name.LocalName),
                new XAttribute("pos", "-1"),
                new XAttribute("expanded", true));
                this.MInserts[mFullChild.RmId()] = insert;
                this.FullDelta.Actions.Add(insert);

                //if (!this.SeedAsts.Modified.ContainsKey(this.SeedAstsGlobal.Modified[mFullChild.RmId()].GtID()))
                //    this.SeedAsts.Modified[this.SeedAstsGlobal.Modified[mFullChild.RmId()].GtID()] = this.SeedAstsGlobal.Modified[mFullChild.RmId()];

                return insert;
            }

            return null;
        }

        /// <summary>
        /// Computes the expandable changes starting from an matched element existing in the seed delta. 
        /// </summary>
        /// <param name="oFullElement">The full description associated to the matched original element version.</param>
        /// <param name="mFullElement">The full description associated to the unmatched modified element version.</param>
        /// <returns>The expanded matches and actions, or null if these match cannot happen because some partner is already matched.</returns>
        public virtual XElement MatchIfAvailable(XElement oFullElement, XElement mFullElement)
        {
            if (!this.OMatches.ContainsKey(oFullElement.RmId()) && !this.MMatches.ContainsKey(mFullElement.RmId()))
            {
                var match = new XElement("Match",
                    new XAttribute("oId", oFullElement.GtID()),
                    new XAttribute("oGId", oFullElement.RmId()),
                    new XAttribute("oLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                    new XAttribute("mId", mFullElement.GtID()),
                    new XAttribute("mGId", mFullElement.RmId()),
                    new XAttribute("mLb", mFullElement.Attribute("kind")?.Value ?? mFullElement.Name.LocalName),
                    new XAttribute("expanded", true));
                this.OMatches[oFullElement.RmId()] = match;
                this.MMatches[mFullElement.RmId()] = match;
                this.FullDelta.Matches.Add(match);

                //if (!this.SeedAsts.Original.ContainsKey(oFullElement.RmId()))
                //    this.SeedAsts.Original[oFullElement.RmId()] = oFullElement;
                //if (!this.SeedAsts.Modified.ContainsKey(mFullElement.RmId()))
                //    this.SeedAsts.Modified[mFullElement.RmId()] = mFullElement;

                return match;
            }

            return null;
        }

        /// <summary>
        /// Computes the expandable changes starting from an matched element existing in the seed delta. 
        /// </summary>
        /// <param name="oFullElement">The full description associated to the matched original element version.</param>
        /// <param name="mFullElement">The full description associated to the unmatched modified element version.</param>
        /// <returns>The expanded matches and actions.</returns>
        public virtual XElement UpdateIfAvailable(XElement oFullElement, XElement mFullElement)
        {
            var oMatch = this.OMatches.ContainsKey(oFullElement.RmId())
                ? this.OMatches[oFullElement.RmId()]
                : null;
            if (!this.OUpdates.ContainsKey(oFullElement.RmId()) &&
                oMatch != null &&
                (oMatch.Attribute("expanded")?.Value != null
                    ? oMatch.Attribute("mGId").Value
                    : this.SeedAsts.Modified[oMatch.Attribute("mId").Value].RmId()) == mFullElement.RmId())
            {
                var update = new XElement("Update",
                new XAttribute("eId", oFullElement.GtID()),
                new XAttribute("eGId", oFullElement.RmId()),
                new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                new XAttribute("eVl", "##"),
                new XAttribute("val", mFullElement.Value),
                new XAttribute("expanded", true));
                this.OUpdates[oFullElement.RmId()] = update;
                this.FullDelta.Actions.Add(update);

                return update;
            }

            return null;
        }

        /// <summary>
        /// Expands a delete action. 
        /// </summary>
        /// <param name="oFullChild">deleted element.</param>
        /// <returns>The expanded delete action.</returns>
        public virtual XElement DeleteIfAvailable(XElement oFullChild)
        {
            if (!this.ODeletes.ContainsKey(oFullChild.RmId()) && !this.OMatches.ContainsKey(oFullChild.RmId()))
            {
                var delete = new XElement("Delete",
                new XAttribute("eId", oFullChild.GtID()),
                new XAttribute("eGId", oFullChild.RmId()),
                new XAttribute("eLb", oFullChild.Attribute("kind")?.Value ?? oFullChild.Name.LocalName),
                new XAttribute("eVl", "##"),
                new XAttribute("expanded", true));
                this.ODeletes[oFullChild.RmId()] = delete;
                this.FullDelta.Actions.Add(delete);

                //if (!this.SeedAsts.Original.ContainsKey(oFullChild.RmId()))
                //    this.SeedAsts.Original[oFullChild.RmId()] = oFullChild;

                return delete;
            }

            return null;
        }

        #region NameColon
        #endregion
    }
}
