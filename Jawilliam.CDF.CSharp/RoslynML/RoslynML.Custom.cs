using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    partial class RoslynML
    {
        /// <summary>
        /// Loads the content given as a full path or a textual content.
        /// </summary>
        /// <param name="pathOrContent">full path or textual content</param>
        /// <param name="path">informs if the content is given as a full path or textual content.</param>
        /// <returns>XML-like representation of the Roslyn-based AST.</returns>
        public virtual XElement Load(string pathOrContent, bool path = true)
        {
            string content = path ? System.IO.File.ReadAllText(pathOrContent) : pathOrContent;
            var ast = SyntaxFactory.ParseCompilationUnit(content).SyntaxTree.GetRoot();
            return this.Visit(ast);
        }

        /// <summary>
        /// Loads the content given as a full path or a textual content.
        /// </summary>
        /// <param name="pathOrContent">full path or textual content</param>
        /// <param name="path">informs if the content is given as a full path or textual content.</param>
        /// <param name="includeTrivia">informs whether the trivia should be included, or not.</param>
        /// <returns>XML-like representation of the Roslyn-based AST.</returns>
        public virtual XElement GetTree(string pathOrContent, bool path = true, bool includeTrivia = false)
        {
            var xElement = this.Load(pathOrContent, path);

            int roslynId = 0, gumTreefiedId = 0;
            this.SetRoslynMLIDs(xElement, ref roslynId);
            this.SetGumTreefiedIDs(xElement, ref gumTreefiedId);

            if (includeTrivia)
            {
                foreach (var xItem in xElement.DescendantNodesAndSelf().OfType<XElement>())
                {
                    var annotation = xItem.Annotation(typeof((XElement[], XElement[])));
                    if (annotation != null)
                    {
                        var (leadingTrivia, trailingTrivia) = ((XElement[], XElement[]))annotation;

                        foreach (var lt in leadingTrivia)
                        {
                            XElement xLocation = xItem;
                            while (!xLocation.ElementsBeforeSelf().OfType<XElement>().Any() &&
                                   ((xLocation.Parent?.Name.LocalName.EndsWith("List") ?? false) ||
                                    (xLocation.Parent?.Name.LocalName.StartsWith("List_of_") ?? false)))
                            {
                                this.FixListTrivia(xLocation.Parent);
                                xLocation = xLocation.Parent;
                            }
                            xLocation.AddBeforeSelf(lt);
                            this.SetRoslynMLIDs(lt, ref roslynId);
                            this.SetGumTreefiedIDs(lt, ref gumTreefiedId);
                        }

                        foreach (var tt in trailingTrivia)
                        {
                            XElement xLocation = xItem;
                            while (!xLocation.ElementsAfterSelf().OfType<XElement>().Any() &&
                                   ((xLocation.Parent?.Name.LocalName.EndsWith("List") ?? false) ||
                                    (xLocation.Parent?.Name.LocalName.StartsWith("List_of_") ?? false)))
                            {
                                this.FixListTrivia(xLocation.Parent);
                                xLocation = xLocation.Parent;
                            }
                            xLocation.AddAfterSelf(tt);
                            this.SetRoslynMLIDs(tt, ref roslynId);
                            this.SetGumTreefiedIDs(tt, ref gumTreefiedId);
                        }

                        xItem.RemoveAnnotations(typeof(((XElement, SyntaxNode)?[], (XElement, SyntaxNode)?[])));

                        leadingTrivia.ToArray()
                            .Where(lt => lt.Name.LocalName == "CommentTrivia")
                            .ForEach(this.FixCommentTrivia);
                        trailingTrivia.ToArray()
                            .Where(tt => tt.Name.LocalName == "CommentTrivia")
                            .ForEach(this.FixCommentTrivia);
                    }
                }
            }

            return xElement;
        }

        private XNode GetTriviaParentElement(XNode xElement, SyntaxNode parent)
        {
            var ancestors = xElement.Ancestors();

            var label = parent.Kind().ToString();
            string startLine = (parent.GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
            string startColumn = (parent.GetLocation().GetLineSpan().StartLinePosition.Character + 1).ToString(CultureInfo.InvariantCulture);
            string endLine = (parent.GetLocation().GetLineSpan().EndLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
            string endColumn = (parent.GetLocation().GetLineSpan().EndLinePosition.Character).ToString(CultureInfo.InvariantCulture);

            XNode last = xElement;
            foreach (var a in ancestors)
            {
                if ((a.Attribute("kind")?.Value ?? a.Name.LocalName) == label &&
                   a.Attribute("startLine").Value == startLine &&
                   a.Attribute("startColumn").Value == startColumn &&
                   a.Attribute("endLine").Value == endLine &&
                   a.Attribute("endColumn").Value == endColumn)
                    break;
                last = a;
            }

            return last;
        }

        /// <summary>
        /// Converts an XML-like AST representation to the XML-like AST representation internally expected by GumTree.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual XElement Gumtreefy(XElement source)
        {
            return this.CoreGumtreefy(source).Single();
        }

        private IEnumerable<XElement> CoreGumtreefy(XElement source)
        {
            if (source.Name.LocalName.Contains("_of_") || source.Name.LocalName == "TokenList")
            {
                foreach (var child in source.Elements())
                {
                    var rChildren = this.CoreGumtreefy(child).ToArray();
                    foreach (var rChild in rChildren)
                    {
                        yield return rChild;
                    }
                }
                yield break;
            } 

            var result = new XElement("tree");

            var kindAtt = source.Attribute("kind");
            var kind = kindAtt != null ? kindAtt.Value : source.Name.LocalName;
            var kindVal = (SyntaxKind)Enum.Parse(typeof(SyntaxKind), kind);

            result.Add(new XAttribute("type", ((int)kindVal).ToString(CultureInfo.InvariantCulture)));
            result.Add(new XAttribute("typeLabel", kind));

            if (source.Name.LocalName == "Token" || !source.Elements().Any())
                result.Add(new XAttribute("label", source.Value ?? ""));

            var startLineAtt = source.Attribute("startLine");
            if (startLineAtt != null)
                result.Add(new XAttribute("line_before", startLineAtt.Value));

            var startColumnAtt = source.Attribute("startColumn");
            if (startColumnAtt != null)
                result.Add(new XAttribute("col_before", startColumnAtt.Value));

            var endLineAtt = source.Attribute("endLine");
            if (endLineAtt != null)
                result.Add(new XAttribute("line_after", endLineAtt.Value));

            var endColumnAtt = source.Attribute("endColumn");
            if (endColumnAtt != null)
                result.Add(new XAttribute("col_after", endColumnAtt.Value));

            var posAtt = source.Attribute("pos");
            if (posAtt != null)
                result.Add(posAtt);

            var lengthAtt = source.Attribute("length");
            if (lengthAtt != null)
                result.Add(lengthAtt);

            foreach (var child in source.Elements())
            {
                result.Add(this.CoreGumtreefy(child).ToArray());
            }

            yield return result;
        }

        /// <summary>
        /// Sets the ID for all elements in the AST.
        /// </summary>
        /// <param name="root">AST root.</param>
        public virtual void SetRoslynMLIDs(XElement root)
        {
            int i = 0;
            this.SetRoslynMLIDs(root, ref i);
        }

        /// <summary>
        /// Sets the ID for all elements in the AST, starting from a given id.
        /// </summary>
        /// <param name="root">AST root.</param>
        /// <param name="id">the next available id.</param>
        public virtual void SetRoslynMLIDs(XElement root, ref int id)
        {
            foreach (var item in root.PostOrder(n => n.Elements()))
            {
                item.Add(new XAttribute("RmID", id++.ToString(CultureInfo.InvariantCulture)));
            }
        }

        /// <summary>
        /// Sets the ID for elements used for GumTree's AST.
        /// </summary>
        /// <param name="root">AST root.</param>
        public virtual void SetGumTreefiedIDs(XElement root)
        {
            int i = 0;
            this.SetGumTreefiedIDs(root, ref i);
        }

        /// <summary>
        /// Sets the ID for elements used for GumTree's AST, starting from a given id.
        /// </summary>
        /// <param name="root">AST root.</param>
        /// <param name="id">the next available id.</param>
        public virtual void SetGumTreefiedIDs(XElement root, ref int id)
        {
            foreach (var item in root.PostOrder(n => n.Elements()).Where(n => !n.Name.LocalName.Contains("_of_") && n.Name.LocalName != "TokenList"))
            {
                item.Add(new XAttribute("GtID", id++.ToString(CultureInfo.InvariantCulture)));
            }
        }

        /// <summary>
        /// Removes from the tree those elements that do not satisfy a given filter.
        /// </summary>
        /// <param name="source">tree root.</param>
        /// <param name="selector">predicate to determine what element types remain (true) or not (false).</param>
        public virtual void Prune(XElement source, Func<XElement, bool> selector)
        {
            foreach (var item in source.Elements().ToList())
            {
                if (!selector(item))
                    item.Remove();
                else
                    this.Prune(item, selector);
            }
        }

        /// <summary>
        /// Converts an XML-like AST representation internally expected by GumTree to an equivalent <see cref="ElementTree"/>.
        /// </summary>
        /// <param name="source">XML-like AST representation internally expected by GumTree</param>
        /// <param name="RmIDOrGtID">if true, the loaded id will be the attribute RmID, otherwise it will be the GtID one.</param>
        /// <returns>the equivalent representation according to the <see cref="ElementTree"/> format.</returns>
        public virtual ElementTree AsGumtreefiedElementTree(XElement source, bool RmIDOrGtID = true)
        {
            var eSource = new ElementTree()
            {
                Root = new ElementVersion
                {
                    Id = RmIDOrGtID ? source.Attribute("RmID")?.Value : source.Attribute("GtID")?.Value,
                    GlobalId = !RmIDOrGtID ? source.Attribute("RmID")?.Value : source.Attribute("GtID")?.Value,
                    Label = (source.Attribute("typeLabel")?.Value ?? source.Attribute("kind")?.Value) ?? source.Name.LocalName,
                    Value = source.Attribute("label")?.Value ?? (source.Elements().Count() == 0 ? source.Value : null)
                }
            };

            var eChildren = new List<ElementTree>(source.Elements().Count());
            foreach (var item in source.Elements())
            {
                var eItem = this.AsGumtreefiedElementTree(item, RmIDOrGtID);
                eChildren.Add(eItem);
                eItem.Parent = eSource;
            }

            eSource.Children = eChildren;
            return eSource;
        }

        private void FixListTrivia(XElement list)
        {
            var firstChild = list.Elements().FirstOrDefault(/*c => !c.Name.LocalName.EndsWith("Trivia")*/);
            if (firstChild != null)
            {
                var annotation = firstChild.Annotation(typeof((XElement[], XElement[])));
                if (annotation != null)
                {
                    var (leadingTrivia, trailingTrivia) = ((XElement[], XElement[]))annotation;
                    if (leadingTrivia.Any())
                    {
                        var (lt, tt) = ((XElement[], XElement[]))(list.Annotation(typeof((XElement[], XElement[]))) ?? (new XElement[0], new XElement[0]));
                        list.RemoveAnnotations(typeof((XElement[], XElement[])));
                        list.AddAnnotation((lt.Union(leadingTrivia).ToArray(), tt));

                        firstChild.RemoveAnnotations(typeof((XElement[], XElement[])));
                        firstChild.AddAnnotation((new XElement[0], trailingTrivia));
                    }
                }
            }

            var lastChild = list.Elements().LastOrDefault(/*c => !c.Name.LocalName.EndsWith("Trivia")*/);
            if (lastChild != null)
            {
                var annotation = lastChild.Annotation(typeof((XElement[], XElement[])));
                if (annotation != null)
                {
                    var (leadingTrivia, trailingTrivia) = ((XElement[], XElement[]))annotation;
                    if (trailingTrivia.Any())
                    {
                        var (lt, tt) = ((XElement[], XElement[]))(list.Annotation(typeof((XElement[], XElement[]))) ?? (new XElement[0], new XElement[0]));
                        list.RemoveAnnotations(typeof((XElement[], XElement[])));
                        list.AddAnnotation((lt, tt.Union(trailingTrivia).ToArray()));

                        lastChild.RemoveAnnotations(typeof((XElement[], XElement[])));
                        lastChild.AddAnnotation((leadingTrivia, new XElement[0]));
                    }
                }
            }
        }

        private void FixCommentTrivia(XElement comment)
        {
            int startLine = int.Parse(comment.Attribute("startLine").Value, CultureInfo.InvariantCulture);
            int startColumn = int.Parse(comment.Attribute("startColumn").Value, CultureInfo.InvariantCulture);
            int endLine = int.Parse(comment.Attribute("endLine").Value, CultureInfo.InvariantCulture);
            int endColumn = int.Parse(comment.Attribute("endColumn").Value, CultureInfo.InvariantCulture);

            var context = comment.Ancestors().FirstOrDefault(delegate(XElement a)
            {
                if (a.Name.LocalName == "CompilationUnit")
                    return true;

                if (a.Name.LocalName.EndsWith("List") || a.Name.LocalName.StartsWith("List_of_") ||
                    a.Name.LocalName.EndsWith("SeparatedList") || a.Name.LocalName.StartsWith("SeparatedList_of_") ||
                    a.Name.LocalName.EndsWith("TokenList"))
                    return false;

                int xStartLine = int.Parse(a.Attribute("startLine").Value, CultureInfo.InvariantCulture);
                int xStartColumn = int.Parse(a.Attribute("startColumn").Value, CultureInfo.InvariantCulture);
                int xEndLine = int.Parse(a.Attribute("endLine").Value, CultureInfo.InvariantCulture);
                int xEndColumn = int.Parse(a.Attribute("endColumn").Value, CultureInfo.InvariantCulture);

                return (xStartLine < startLine || (xStartLine == startLine && xStartColumn < startColumn)) &&
                       (endLine < xEndLine || (endLine == xEndLine && endColumn < xEndColumn));
            });

            var rightSibling = context?.DescendantsAndSelf().FirstOrDefault(delegate(XElement a)
            {
                if (a.Name.LocalName.EndsWith("List") || a.Name.LocalName.StartsWith("List_of_") ||
                    a.Name.LocalName.EndsWith("SeparatedList") || a.Name.LocalName.StartsWith("SeparatedList_of_") ||
                    a.Name.LocalName.EndsWith("TokenList") || 
                    a.Attribute("startLine") == null ||
                    a.Attribute("startColumn") == null ||
                    a.Attribute("endLine") == null ||
                    a.Attribute("endColumn") == null)
                    return false;

                int xStartLine = int.Parse(a.Attribute("startLine").Value, CultureInfo.InvariantCulture);
                int xStartColumn = int.Parse(a.Attribute("startColumn").Value, CultureInfo.InvariantCulture);
                int xEndLine = int.Parse(a.Attribute("endLine").Value, CultureInfo.InvariantCulture);
                int xEndColumn = int.Parse(a.Attribute("endColumn").Value, CultureInfo.InvariantCulture);

                return (xStartLine > endLine || (xStartLine == endLine && xStartColumn > endColumn));
            }) /*?? (context.Elements().FirstOrDefault())*/;

            if (rightSibling?.Name.LocalName == "CompilationUnit")
                rightSibling = rightSibling.Elements().FirstOrDefault(e => e.Name.LocalName != "CommentTrivia");

            if (rightSibling != null)
            {
                comment.Remove();
                rightSibling.AddBeforeSelf(comment);
            }
        }
    }
}
