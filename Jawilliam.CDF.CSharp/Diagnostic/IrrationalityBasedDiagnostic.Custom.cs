using Jawilliam.CDF.Approach;
using Jawilliam.CDF.CSharp.RoslynML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.Diagnostic
{
    partial class IrrationalityBasedDiagnostic
    {
        /// <summary>
        /// Gets or sets the AST revision pair used to generate the delta to be examined.
        /// </summary>
        protected virtual RevisionPair<Dictionary<string, XElement>> AstRevisionPair { get; set; }

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

        public virtual IEnumerable<XElement> Diagnose(RevisionPair<XElement> _astRevisionPair, IEnumerable<XElement> matches, IEnumerable<XElement> actions)
        {
            if (_astRevisionPair?.Original == null) throw new ArgumentNullException("_astRevisionPair?.Original");
            if (_astRevisionPair?.Modified == null) throw new ArgumentNullException("_astRevisionPair?.Modified");
            if (matches == null) throw new ArgumentNullException(nameof(matches));
            if (actions == null) throw new ArgumentNullException(nameof(actions));

            try
            {
                var oElements = _astRevisionPair?.Original.PostOrder(n => n.Elements().Where(ne => ne is XNode)).ToDictionary(n => n.GtID());
                var mElements = _astRevisionPair?.Modified.PostOrder(n => n.Elements().Where(ne => ne is XNode)).ToDictionary(n => n.GtID());
                this.AstRevisionPair = new RevisionPair<Dictionary<string, XElement>> { Original = oElements, Modified = mElements };

                this.OMatches = matches.ToDictionary(m => m.Attribute("oId").Value);
                this.MMatches = matches.ToDictionary(m => m.Attribute("mId").Value);
                this.MInserts = actions.Where(a => a.Name.LocalName == "Insert").ToDictionary(m => m.Attribute("eId").Value);
                this.ODeletes = actions.Where(a => a.Name.LocalName == "Delete").ToDictionary(m => m.Attribute("eId").Value);
                this.OUpdates = actions.Where(a => a.Name.LocalName == "Update").ToDictionary(m => m.Attribute("eId").Value);
                this.OMoves = actions.Where(a => a.Name.LocalName == "Move").ToDictionary(m => m.Attribute("eId").Value);

                foreach (var action in actions)
                {
                    switch (action.Name.LocalName)
                    {
                        case "Insert":
                            var m = this.AstRevisionPair.Modified[action.Attribute("eId").Value];
                            foreach (var i in this.Inserted(m, int.Parse(action.Attribute("pos").Value, CultureInfo.InvariantCulture), m.Parent))
                                yield return i;
                            break;
                        case "Delete":
                            var o = this.AstRevisionPair.Original[action.Attribute("eId").Value];
                            foreach (var i in this.Deleted(o, o.Parent))
                                yield return i;
                            break;
                        case "Update":
                            o = this.AstRevisionPair.Original[action.Attribute("eId").Value];
                            var mId = this.OMatches[action.Attribute("eId").Value].Attribute("mId").Value;
                            foreach (var i in this.Updated(o, this.AstRevisionPair.Modified[mId]))
                                yield return i;
                            break;
                        case "Move":
                            o = this.AstRevisionPair.Original[action.Attribute("eId").Value];
                            mId = this.OMatches[action.Attribute("eId").Value].Attribute("pId").Value;
                            foreach (var i in this.Moved(o, o.Parent, int.Parse(action.Attribute("pos").Value, CultureInfo.InvariantCulture), 
                                this.AstRevisionPair.Modified[mId]))
                                yield return i;
                            break;
                        default:
                            throw new ArgumentException($"Unsupported operation {action.Name.LocalName}");
                    }
                }
            }
            finally
            {
                this.AstRevisionPair = null;
                this.OMatches = null;
                this.MMatches = null;
                this.MInserts = null;
                this.ODeletes = null;
                this.OUpdates = null;
                this.OMoves = null;
            }
        }

        #region FirstActionIffSecondAction

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="FirstActionIffSecondAction(XElement, XElement, string, string, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">first action name.</param>
        /// <param name="secondAction">second action name.</param>
        /// <param name="firstActionInfo">input or output for the action associated to first element.</param>
        /// <param name="secondActionInfo">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="FirstActionIffSecondAction(XElement, XElement, string, string, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="FirstActionIffSecondActionCore(XElement, XElement, string, string, ref XElement, ref XElement)"/> is not executed and <see cref="FirstActionIffSecondAction(XElement, XElement, string, string, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void FirstActionIffSecondActionBefore(XElement first, XElement second, string firstAction, string secondAction, ref XElement firstActionInfo, ref XElement secondActionInfo, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="FirstActionIffSecondActionCore(XElement, XElement, string, string, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">first action name.</param>
        /// <param name="secondAction">second action name.</param>
        /// <param name="firstActionInfo">input or output for the action associated to first element.</param>
        /// <param name="secondActionInfo">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="FirstActionIffSecondActionCore(XElement, XElement, string, string, ref XElement, ref XElement)"/>.</param>
        partial void FirstActionIffSecondActionAfter(XElement first, XElement second, string firstAction, string secondAction, ref XElement firstActionInfo, ref XElement secondActionInfo, ref IEnumerable<XElement> result);

        /// <summary>
        /// Tests that first element is deleted if and only if second element was deleted.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">first action name.</param>
        /// <param name="secondAction">second action name.</param>
        /// <param name="firstActionInfo">input or output for the action associated to first element.</param>
        /// <param name="secondActionInfo">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="FirstActionIffSecondAction(XElement, XElement, string, string, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> FirstActionIffSecondActionCore(XElement first, XElement second, string firstAction, string secondAction, ref XElement firstActionInfo, ref XElement secondActionInfo)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            firstActionInfo = firstActionInfo ?? (this.ODeletes.ContainsKey(first.Attribute("eId").Value) ? this.ODeletes[first.Attribute("eId").Value] : null);
            secondActionInfo = secondActionInfo ?? (this.ODeletes.ContainsKey(second.Attribute("eId").Value) ? this.ODeletes[second.Attribute("eId").Value] : null);

            if ((firstActionInfo?.Name.LocalName == firstAction && secondActionInfo?.Name.LocalName != secondAction) ||
                (secondActionInfo?.Name.LocalName == secondAction && firstActionInfo?.Name.LocalName != firstAction))
                return new[] { new XElement("Irrationality",
                                new XAttribute("rule", $"First{firstAction}IffSecond{secondAction}"),
                                firstActionInfo ?? new XElement("NONE"),
                                secondActionInfo ?? new XElement("NONE"))};

            return new XElement[0];
        }

        /// <summary>
        /// Tests that first element is deleted if and only if second element was deleted.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">first action name.</param>
        /// <param name="secondAction">second action name.</param>
        /// <param name="firstActionInfo">input or output for the action associated to first element.</param>
        /// <param name="secondActionInfo">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> FirstActionIffSecondAction(XElement first, XElement second, string firstAction, string secondAction, ref XElement firstActionInfo, ref XElement secondActionInfo)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            FirstActionIffSecondActionBefore(first, second, firstAction, secondAction, ref firstActionInfo, ref secondActionInfo, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.FirstActionIffSecondActionCore(first, second, firstAction, secondAction, ref firstActionInfo, ref secondActionInfo);
            FirstActionIffSecondActionAfter(first, second, firstAction, secondAction, ref firstActionInfo, ref secondActionInfo, ref result);
            return result;
        }

        #endregion

        #region DeleteFirstIffDeleteSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeleteFirstIffDeleteSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeleteFirstIffDeleteSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeleteFirstIffDeleteSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeleteFirstIffDeleteSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void DeleteFirstIffDeleteSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result);

        /// <summary>
        /// Tests that first element is deleted if and only if second element was deleted.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> DeleteFirstIffDeleteSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            firstAction = firstAction ?? (this.ODeletes.ContainsKey(first.Attribute("eId").Value) ? this.ODeletes[first.Attribute("eId").Value] : null);
            secondAction = secondAction ?? (this.ODeletes.ContainsKey(second.Attribute("eId").Value) ? this.ODeletes[second.Attribute("eId").Value] : null);

            if ((firstAction?.Name.LocalName == "Delete" && secondAction?.Name.LocalName != "Delete") ||
                (secondAction?.Name.LocalName == "Delete" && firstAction?.Name.LocalName != "Delete"))
                return new[] { new XElement("Irrationality", 
                                new XAttribute("rule", "DeleteFirstIffDeleteSecond"),
                                firstAction ?? new XElement("NONE"),
                                secondAction ?? new XElement("NONE"))};

            return new XElement[0];
        }

        /// <summary>
        /// Tests that first element is deleted if and only if second element was deleted.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> DeleteFirstIffDeleteSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            DeleteFirstIffDeleteSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.DeleteFirstIffDeleteSecondCore(first, second, ref firstAction, ref secondAction);
            DeleteFirstIffDeleteSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        #region InsertFirstIffInsertSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="InsertFirstIffInsertSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void InsertFirstIffInsertSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="InsertFirstIffInsertSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertFirstIffInsertSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void InsertFirstIffInsertSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> InsertFirstIffInsertSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            firstAction = firstAction ?? (this.MInserts.ContainsKey(first.Attribute("eId").Value) ? this.MInserts[first.Attribute("eId").Value] : null);
            secondAction = secondAction ?? (this.MInserts.ContainsKey(second.Attribute("eId").Value) ? this.MInserts[second.Attribute("eId").Value] : null);

            if ((firstAction?.Name.LocalName == "Insert" && secondAction?.Name.LocalName != "Insert") ||
                (secondAction?.Name.LocalName == "Insert" && firstAction?.Name.LocalName != "Insert"))
                return new[] { new XElement("Irrationality",
                                new XAttribute("rule", "InsertFirstIffInsertSecond"),
                                firstAction ?? new XElement("NONE"),
                                secondAction ?? new XElement("NONE"))};

            return new XElement[0];
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> InsertFirstIffInsertSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            InsertFirstIffInsertSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.InsertFirstIffInsertSecondCore(first, second, ref firstAction, ref secondAction);
            InsertFirstIffInsertSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        #region MoveFirstIffMoveSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MoveFirstIffMoveSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MoveFirstIffMoveSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MoveFirstIffMoveSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MoveFirstIffMoveSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void MoveFirstIffMoveSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> MoveFirstIffMoveSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return new XElement[0];
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> MoveFirstIffMoveSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            MoveFirstIffMoveSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MoveFirstIffMoveSecondCore(first, second, ref firstAction, ref secondAction);
            MoveFirstIffMoveSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        #region MatchFirstIffMatchSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MatchFirstIffMatchSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MatchFirstIffMatchSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MatchFirstIffMatchSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="MatchFirstIffMatchSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MatchFirstIffMatchSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MatchFirstIffMatchSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MatchFirstIffMatchSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void MatchFirstIffMatchSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MatchFirstIffMatchSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> MatchFirstIffMatchSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return new XElement[0];
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> MatchFirstIffMatchSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            MatchFirstIffMatchSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MatchFirstIffMatchSecondCore(first, second, ref firstAction, ref secondAction);
            MatchFirstIffMatchSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        #region SingleLineCommentTrivia

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="InsertedFromSingleLineCommentTrivia(XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertedFromSingleLineCommentTrivia(XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="InsertedFromSingleLineCommentTriviaCore(XElement, int, XElement)"/> is not executed and <see cref="InsertedFromSingleLineCommentTrivia(XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void InsertedFromSingleLineCommentTriviaBefore(XElement property, int position, XElement parent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="InsertedFromSingleLineCommentTriviaCore(XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertedFromSingleLineCommentTriviaCore(XElement, int, XElement)"/>.</param>
        partial void InsertedFromSingleLineCommentTriviaAfter(XElement property, int position, XElement parent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes an insert action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="InsertedFromSingleLineCommentTrivia(XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> InsertedFromSingleLineCommentTriviaCore(XElement property, int position, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes an insert action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> InsertedFromSingleLineCommentTrivia(XElement property, int position, XElement parent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            InsertedFromSingleLineCommentTriviaBefore(property, position, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.InsertedFromSingleLineCommentTriviaCore(property, position, parent);
            InsertedFromSingleLineCommentTriviaAfter(property, position, parent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSingleLineCommentTriviaCore(XElement, XElement)"/> is not executed and <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSingleLineCommentTriviaBefore(XElement property, XElement parent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSingleLineCommentTriviaCore(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSingleLineCommentTriviaCore(XElement, XElement)"/>.</param>
        partial void DeletedFromSingleLineCommentTriviaAfter(XElement property, XElement parent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> DeletedFromSingleLineCommentTriviaCore(XElement property, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> DeletedFromSingleLineCommentTrivia(XElement property, XElement parent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            DeletedFromSingleLineCommentTriviaBefore(property, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.DeletedFromSingleLineCommentTriviaCore(property, parent);
            DeletedFromSingleLineCommentTriviaAfter(property, parent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="UpdatedFromSingleLineCommentTrivia(XElement, XElement)"/>.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="UpdatedFromSingleLineCommentTrivia(XElement, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="UpdatedFromSingleLineCommentTriviaCore(XElement, XElement)"/> is not executed and <see cref="UpdatedFromSingleLineCommentTrivia(XElement, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void UpdatedFromSingleLineCommentTriviaBefore(XElement oldElement, XElement newElement, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="UpdatedFromSingleLineCommentTriviaCore(XElement, XElement)"/>.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="UpdatedFromSingleLineCommentTriviaCore(XElement, XElement)"/>.</param>
        partial void UpdatedFromSingleLineCommentTriviaAfter(XElement oldElement, XElement newElement, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes an update action.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="UpdatedFromSingleLineCommentTrivia(XElement, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> UpdatedFromSingleLineCommentTriviaCore(XElement oldElement, XElement newElement)
        {
            if (oldElement == null) throw new ArgumentNullException(nameof(oldElement));
            if (newElement == null) throw new ArgumentNullException(nameof(newElement));

            yield break;
        }

        /// <summary>
        /// Analyzes an update action.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> UpdatedFromSingleLineCommentTrivia(XElement oldElement, XElement newElement)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            UpdatedFromSingleLineCommentTriviaBefore(oldElement, newElement, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.UpdatedFromSingleLineCommentTriviaCore(oldElement, newElement);
            UpdatedFromSingleLineCommentTriviaAfter(oldElement, newElement, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MovedFromSingleLineCommentTrivia(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MovedFromSingleLineCommentTrivia(XElement, XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MovedFromSingleLineCommentTriviaCore(XElement, XElement, int, XElement)"/> is not executed and <see cref="MovedFromSingleLineCommentTrivia(XElement, XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MovedFromSingleLineCommentTriviaBefore(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MovedFromSingleLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MovedFromSingleLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.</param>
        partial void MovedFromSingleLineCommentTriviaAfter(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MovedFromSingleLineCommentTrivia(XElement, XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> MovedFromSingleLineCommentTriviaCore(XElement property, XElement oldParent, int position, XElement newParent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> MovedFromSingleLineCommentTrivia(XElement property, XElement oldParent, int position, XElement newParent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            MovedFromSingleLineCommentTriviaBefore(property, oldParent, position, newParent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MovedFromSingleLineCommentTriviaCore(property, oldParent, position, newParent);
            MovedFromSingleLineCommentTriviaAfter(property, oldParent, position, newParent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MatchedSingleLineCommentTrivia(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MatchedSingleLineCommentTrivia(XElement, XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MatchedSingleLineCommentTriviaCore(XElement, XElement, int, XElement)"/> is not executed and <see cref="MatchedSingleLineCommentTrivia(XElement, XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MatchedSingleLineCommentTriviaBefore(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MatchedSingleLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MatchedSingleLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.</param>
        partial void MatchedSingleLineCommentTriviaAfter(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MatchedSingleLineCommentTrivia(XElement, XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> MatchedSingleLineCommentTriviaCore(XElement property, XElement oldParent, int position, XElement newParent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> MatchedSingleLineCommentTrivia(XElement property, XElement oldParent, int position, XElement newParent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            MatchedSingleLineCommentTriviaBefore(property, oldParent, position, newParent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MatchedSingleLineCommentTriviaCore(property, oldParent, position, newParent);
            MatchedSingleLineCommentTriviaAfter(property, oldParent, position, newParent, ref result);
            return result;
        }

        #endregion

        #region MultiLineCommentTrivia

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="InsertedFromMultiLineCommentTriviaCore(XElement, int, XElement)"/> is not executed and <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void InsertedFromMultiLineCommentTriviaBefore(XElement property, int position, XElement parent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="InsertedFromMultiLineCommentTriviaCore(XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertedFromMultiLineCommentTriviaCore(XElement, int, XElement)"/>.</param>
        partial void InsertedFromMultiLineCommentTriviaAfter(XElement property, int position, XElement parent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes an insert action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> InsertedFromMultiLineCommentTriviaCore(XElement property, int position, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes an insert action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> InsertedFromMultiLineCommentTrivia(XElement property, int position, XElement parent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            InsertedFromMultiLineCommentTriviaBefore(property, position, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.InsertedFromMultiLineCommentTriviaCore(property, position, parent);
            InsertedFromMultiLineCommentTriviaAfter(property, position, parent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromMultiLineCommentTriviaCore(XElement, XElement)"/> is not executed and <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromMultiLineCommentTriviaBefore(XElement property, XElement parent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromMultiLineCommentTriviaCore(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMultiLineCommentTriviaCore(XElement, XElement)"/>.</param>
        partial void DeletedFromMultiLineCommentTriviaAfter(XElement property, XElement parent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> DeletedFromMultiLineCommentTriviaCore(XElement property, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> DeletedFromMultiLineCommentTrivia(XElement property, XElement parent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            DeletedFromMultiLineCommentTriviaBefore(property, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.DeletedFromMultiLineCommentTriviaCore(property, parent);
            DeletedFromMultiLineCommentTriviaAfter(property, parent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="UpdatedFromMultiLineCommentTrivia(XElement, XElement)"/>.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="UpdatedFromMultiLineCommentTrivia(XElement, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="UpdatedFromMultiLineCommentTriviaCore(XElement, XElement)"/> is not executed and <see cref="UpdatedFromMultiLineCommentTrivia(XElement, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void UpdatedFromMultiLineCommentTriviaBefore(XElement oldElement, XElement newElement, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="UpdatedFromMultiLineCommentTriviaCore(XElement, XElement)"/>.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="UpdatedFromMultiLineCommentTriviaCore(XElement, XElement)"/>.</param>
        partial void UpdatedFromMultiLineCommentTriviaAfter(XElement oldElement, XElement newElement, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes an update action.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="UpdatedFromMultiLineCommentTrivia(XElement, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> UpdatedFromMultiLineCommentTriviaCore(XElement oldElement, XElement newElement)
        {
            if (oldElement == null) throw new ArgumentNullException(nameof(oldElement));
            if (newElement == null) throw new ArgumentNullException(nameof(newElement));

            yield break;
        }

        /// <summary>
        /// Analyzes an update action.
        /// </summary>
        /// <param name="oldElement">original element.</param>
        /// <param name="newElement">modified element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> UpdatedFromMultiLineCommentTrivia(XElement oldElement, XElement newElement)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            UpdatedFromMultiLineCommentTriviaBefore(oldElement, newElement, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.UpdatedFromMultiLineCommentTriviaCore(oldElement, newElement);
            UpdatedFromMultiLineCommentTriviaAfter(oldElement, newElement, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MovedFromMultiLineCommentTrivia(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MovedFromMultiLineCommentTrivia(XElement, XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MovedFromMultiLineCommentTriviaCore(XElement, XElement, int, XElement)"/> is not executed and <see cref="MovedFromMultiLineCommentTrivia(XElement, XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MovedFromMultiLineCommentTriviaBefore(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MovedFromMultiLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MovedFromMultiLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.</param>
        partial void MovedFromMultiLineCommentTriviaAfter(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MovedFromMultiLineCommentTrivia(XElement, XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> MovedFromMultiLineCommentTriviaCore(XElement property, XElement oldParent, int position, XElement newParent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> MovedFromMultiLineCommentTrivia(XElement property, XElement oldParent, int position, XElement newParent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            MovedFromMultiLineCommentTriviaBefore(property, oldParent, position, newParent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MovedFromMultiLineCommentTriviaCore(property, oldParent, position, newParent);
            MovedFromMultiLineCommentTriviaAfter(property, oldParent, position, newParent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MatchedMultiLineCommentTrivia(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MatchedMultiLineCommentTrivia(XElement, XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MatchedMultiLineCommentTriviaCore(XElement, XElement, int, XElement)"/> is not executed and <see cref="MatchedMultiLineCommentTrivia(XElement, XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MatchedMultiLineCommentTriviaBefore(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MatchedMultiLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MatchedMultiLineCommentTriviaCore(XElement, XElement, int, XElement)"/>.</param>
        partial void MatchedMultiLineCommentTriviaAfter(XElement property, XElement oldParent, int position, XElement newParent, ref IEnumerable<XElement> result);

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MatchedMultiLineCommentTrivia(XElement, XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<XElement> MatchedMultiLineCommentTriviaCore(XElement property, XElement oldParent, int position, XElement newParent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a move action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where the property would move.</param>
        /// <param name="oldParent">original parent element.</param>
        /// <param name="newParent">modified parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<XElement> MatchedMultiLineCommentTrivia(XElement property, XElement oldParent, int position, XElement newParent)
        {
            IEnumerable<XElement> result = null;
            var ignoreCore = false;
            MatchedMultiLineCommentTriviaBefore(property, oldParent, position, newParent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MatchedMultiLineCommentTriviaCore(property, oldParent, position, newParent);
            MatchedMultiLineCommentTriviaAfter(property, oldParent, position, newParent, ref result);
            return result;
        }

        #endregion
    }
}
