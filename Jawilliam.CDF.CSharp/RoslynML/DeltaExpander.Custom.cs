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
                this.FullAsts = new RevisionPair<Dictionary<string, XElement>>
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

                this.OMatches = seedDelta.Matches.ToDictionary(m => m.Attribute("oId").Value);
                this.MMatches = seedDelta.Matches.ToDictionary(m => m.Attribute("mId").Value);
                this.MInserts = seedDelta.Actions.Where(a => a.Name.LocalName == "Insert").ToDictionary(m => m.Attribute("eId").Value);
                this.ODeletes = seedDelta.Actions.Where(a => a.Name.LocalName == "Delete").ToDictionary(m => m.Attribute("eId").Value);
                this.OUpdates = seedDelta.Actions.Where(a => a.Name.LocalName == "Update").ToDictionary(m => m.Attribute("eId").Value);

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
                        this.OUpdates.ContainsKey(a.Attribute("eId").Value)).ToList())
                );

                return this.FullDelta;
            }
            finally
            {
                this.SeedAsts = null;
                this.OMatches = null;
                this.MMatches = null;
                this.MInserts = null;
                this.ODeletes = null;
                this.OUpdates = null;
            }
        }

        private void ForEachO(XElement oSeedElement)
        {
            var oFullElement = this.FullAsts.Original[oSeedElement.GtID()];
            if (this.ODeletes.ContainsKey(oFullElement.GtID()))
                this.ResolveDefoliatedChildren(this.UnmatchedOriginal(oFullElement).ToList());
        }

        private void ForEachM(XElement mSeedElement)
        {
            var mFullElement = this.FullAsts.Modified[mSeedElement.GtID()];
            if (this.MInserts.ContainsKey(mFullElement.GtID()))
                this.ResolveDefoliatedChildren(this.UnmatchedModified(mFullElement).ToList());
            else if (this.MMatches.ContainsKey(mFullElement.GtID()))
            {
                var match = this.MMatches[mFullElement.GtID()];
                var oFullElement = this.FullAsts.Original[match.Attribute("oId").Value];
                this.ResolveDefoliatedChildren(this.Matched(oFullElement, mFullElement).ToList());

                if (mSeedElement.Name.LocalName != "Token" &&
                    mSeedElement.Elements().Count() == 0 &&
                    this.OUpdates.ContainsKey(oFullElement.GtID()) &&
                    this.OMatches.ContainsKey(oFullElement.GtID()) &&
                    this.OMatches[oFullElement.GtID()].Attribute("mId")?.Value == mFullElement.GtID())
                {
                    var defoliationRemovedDescendants = oFullElement.PostOrder(n => n.Elements()
                       .Where(ne => ne is XNode))
                       .Where(ne => ne != oFullElement && ne.Attribute("GtID")?.Value != null).ToList();

                    if (defoliationRemovedDescendants.Any(drd => this.OUpdates.ContainsKey(drd.GtID())))
                        this.OUpdates.Remove(oFullElement.GtID());
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
                        var insertedChild = this.FullAsts.Modified[fact.Attribute("eId").Value];
                        if (insertedChild.Name.LocalName != "Token" && !this.SeedAsts.Modified.ContainsKey(insertedChild.GtID())) // then it is a defoliated element.
                            this.ForEachM(insertedChild);
                        break;
                    case "Delete":
                        var deletedChild = this.FullAsts.Original[fact.Attribute("eId").Value];
                        if (deletedChild.Name.LocalName != "Token" && !this.SeedAsts.Original.ContainsKey(deletedChild.GtID())) // then it is a defoliated element.
                            this.ForEachO(deletedChild);
                        break;
                    case "Match":
                        var mChild = this.FullAsts.Modified[fact.Attribute("mId").Value]; 
                        if (mChild.Name.LocalName != "Token" && !this.SeedAsts.Modified.ContainsKey(mChild.GtID()))
                            this.ForEachM(mChild);
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
            if (!this.MInserts.ContainsKey(mFullChild.GtID()) && !this.MMatches.ContainsKey(mFullChild.GtID()))
            {
                var insert = new XElement("Insert",
                new XAttribute("eId", mFullChild.GtID()),
                new XAttribute("eLb", mFullChild.Attribute("kind")?.Value ?? mFullChild.Name.LocalName),
                new XAttribute("eVl", "##"),
                new XAttribute("pId", fullParent.GtID()),
                new XAttribute("pLb", fullParent.Attribute("kind")?.Value ?? fullParent.Name.LocalName),
                new XAttribute("pos", "-1"),
                new XAttribute("expanded", true));
                this.MInserts[mFullChild.GtID()] = insert;
                this.FullDelta.Actions.Add(insert);

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
            if (!this.OMatches.ContainsKey(oFullElement.GtID()) && !this.MMatches.ContainsKey(mFullElement.GtID()))
            {
                var match = new XElement("Match",
                    new XAttribute("oId", oFullElement.GtID()),
                    new XAttribute("oLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                    new XAttribute("mId", mFullElement.GtID()),
                    new XAttribute("mLb", mFullElement.Attribute("kind")?.Value ?? mFullElement.Name.LocalName),
                    new XAttribute("expanded", true));
                this.OMatches[oFullElement.GtID()] = match;
                this.MMatches[mFullElement.GtID()] = match;
                if (this.ODeletes.ContainsKey(oFullElement.GtID()))
                    this.ODeletes.Remove(oFullElement.GtID());
                if (this.MInserts.ContainsKey(mFullElement.GtID()))
                    this.MInserts.Remove(mFullElement.GtID());
                this.FullDelta.Matches.Add(match);

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
            if (!this.OUpdates.ContainsKey(oFullElement.GtID()) && 
                this.OMatches.ContainsKey(oFullElement.GtID()) &&
                this.OMatches[oFullElement.GtID()].Attribute("mId")?.Value == mFullElement.GtID())
            {
                var update = new XElement("Update",
                new XAttribute("eId", oFullElement.GtID()),
                new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
                new XAttribute("eVl", "##"),
                new XAttribute("val", mFullElement.Value),
                new XAttribute("expanded", true));
                this.OUpdates[oFullElement.GtID()] = update;
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
            if (!this.ODeletes.ContainsKey(oFullChild.GtID()) && !this.OMatches.ContainsKey(oFullChild.GtID()))
            {
                var delete = new XElement("Delete",
                new XAttribute("eId", oFullChild.GtID()),
                new XAttribute("eLb", oFullChild.Attribute("kind")?.Value ?? oFullChild.Name.LocalName),
                new XAttribute("eVl", "##"),
                new XAttribute("expanded", true));
                this.ODeletes[oFullChild.GtID()] = delete;
                this.FullDelta.Actions.Add(delete);

                return delete;
            }

            return null;
        }

        #region NameColon
        #endregion
    }
}
