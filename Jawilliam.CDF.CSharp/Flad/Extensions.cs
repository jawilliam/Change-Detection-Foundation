using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Shares extensions.
    /// </summary>
    public static class Extensions
    {
        ///// <summary>
        ///// Translates the result to a more understandable report, for example, by translating the numeric labels. 
        ///// </summary>
        ///// <typeparam name="source">Result to translate.</typeparam>
        ///// <returns>Translated result. </returns>
        //public static DetectionResult<SyntaxNode> Translate(this DetectionResult<SyntaxNode> source)
        //{
        //    Debug.Assert(source != null);
        //    return new DetectionResult<SyntaxNode>
        //    {
        //        Original = source.Original,
        //        Modified = source.Modified,
        //        Matches = source.Matches?.Select(m => new MatchDescriptor
        //        {
        //            Original = new ElementVersion { Id = m.Original.Id, Label = TranslateLabel(m.Original.Label), Value = m.Original.Value },
        //            Modified = new ElementVersion { Id = m.Modified.Id, Label = TranslateLabel(m.Modified.Label), Value = m.Modified.Value },
        //            Similarity = m.Similarity,
        //            Distance = m.Distance
        //        }).ToList(),
        //        Actions = source.Actions?.Select<ActionDescriptor, ActionDescriptor>(action =>
        //        {
        //            switch (action.Action)
        //            {
        //                case ActionKind.Update:
        //                    var u = (UpdateOperationDescriptor)action;
        //                    return new UpdateOperationDescriptor
        //                    {
        //                        Element = new ElementVersion { Id = u.Element.Id, Label = TranslateLabel(u.Element.Label), Value = u.Element.Value },
        //                        Value = u.Value
        //                    };
        //                case ActionKind.Insert:
        //                    var i = (InsertOperationDescriptor)action;
        //                    return new InsertOperationDescriptor
        //                    {
        //                        Element = new ElementVersion { Id = i.Element.Id, Label = TranslateLabel(i.Element.Label), Value = i.Element.Value },
        //                        Position = i.Position,
        //                        Parent = new ElementVersion { Id = i.Parent.Id, Label = TranslateLabel(i.Parent.Label), Value = i.Parent.Value }
        //                    };
        //                case ActionKind.Delete:
        //                    var d = (DeleteOperationDescriptor)action;
        //                    return new DeleteOperationDescriptor
        //                    {
        //                        Element = new ElementVersion { Id = d.Element.Id, Label = TranslateLabel(d.Element.Label), Value = d.Element.Value }
        //                    };
        //                case ActionKind.Move:
        //                    var m = (MoveOperationDescriptor)action;
        //                    return new MoveOperationDescriptor
        //                    {
        //                        Element = new ElementVersion { Id = m.Element.Id, Label = TranslateLabel(m.Element.Label), Value = m.Element.Value },
        //                        Position = m.Position,
        //                        Parent = new ElementVersion { Id = m.Parent.Id, Label = TranslateLabel(m.Parent.Label), Value = m.Parent.Value }
        //                    };
        //                case ActionKind.Align:
        //                    var a = (AlignOperationDescriptor)action;
        //                    return new AlignOperationDescriptor
        //                    {
        //                        Element = new ElementVersion { Id = a.Element.Id, Label = TranslateLabel(a.Element.Label), Value = a.Element.Value },
        //                        Position = a.Position
        //                    };
        //                default:
        //                    throw new NotSupportedException();
        //            }
        //        }).ToList(),
        //        Error = source.Error
        //    };
        //}

        /// <summary>
        /// Translates the result to a more understandable report, for example, by translating the numeric labels. 
        /// </summary>
        /// <typeparam name="source">Result to translate.</typeparam>
        /// <returns>Translated result. </returns>
        public static DetectionResult<SyntaxNodeOrToken?> Translate(this DetectionResult<SyntaxNodeOrToken?> source)
        {
            Debug.Assert(source != null);
            return new DetectionResult<SyntaxNodeOrToken?>
            {
                Original = source.Original,
                Modified = source.Modified,
                Matches = source.Matches?.Select(m => new MatchDescriptor
                {
                    Original = new ElementVersion { Id = m.Original.Id, Label = TranslateLabel(m.Original.Label), Value = m.Original.Value },
                    Modified = new ElementVersion { Id = m.Modified.Id, Label = TranslateLabel(m.Modified.Label), Value = m.Modified.Value },
                    Similarity = m.Similarity,
                    Distance = m.Distance
                }).ToList(),
                Actions = source.Actions?.Select<ActionDescriptor, ActionDescriptor>(action =>
                {
                    switch (action.Action)
                    {
                        case ActionKind.Update:
                            var u = (UpdateOperationDescriptor)action;
                            return new UpdateOperationDescriptor
                            {
                                Element = new ElementVersion { Id = u.Element.Id, Label = TranslateLabel(u.Element.Label), Value = u.Element.Value },
                                Value = u.Value
                            };
                        case ActionKind.Insert:
                            var i = (InsertOperationDescriptor)action;
                            return new InsertOperationDescriptor
                            {
                                Element = new ElementVersion { Id = i.Element.Id, Label = TranslateLabel(i.Element.Label), Value = i.Element.Value },
                                Position = i.Position,
                                Parent = new ElementVersion { Id = i.Parent.Id, Label = TranslateLabel(i.Parent.Label), Value = i.Parent.Value }
                            };
                        case ActionKind.Delete:
                            var d = (DeleteOperationDescriptor)action;
                            return new DeleteOperationDescriptor
                            {
                                Element = new ElementVersion { Id = d.Element.Id, Label = TranslateLabel(d.Element.Label), Value = d.Element.Value }
                            };
                        case ActionKind.Move:
                            var m = (MoveOperationDescriptor)action;
                            return new MoveOperationDescriptor
                            {
                                Element = new ElementVersion { Id = m.Element.Id, Label = TranslateLabel(m.Element.Label), Value = m.Element.Value },
                                Position = m.Position,
                                Parent = new ElementVersion { Id = m.Parent.Id, Label = TranslateLabel(m.Parent.Label), Value = m.Parent.Value }
                            };
                        case ActionKind.Align:
                            var a = (AlignOperationDescriptor)action;
                            return new AlignOperationDescriptor
                            {
                                Element = new ElementVersion { Id = a.Element.Id, Label = TranslateLabel(a.Element.Label), Value = a.Element.Value },
                                Position = a.Position
                            };
                        default:
                            throw new NotSupportedException();
                    }
                }).ToList(),
                Error = source.Error
            };
        }

        private static string TranslateLabel(string source)
        {
            return Enum.GetName(typeof(SyntaxKind), int.Parse(source, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
        }

        ///// <summary>
        ///// Gets all the non-abstract properties (i.e., all property belonging to some non-abstract element type).
        ///// </summary>
        ///// <param name="rdsl">The Xml root of the RDSL.</param>
        ///// <returns>all the non-abstract properties</returns>
        //public static IEnumerable<(XObjects.RDSL.Syntax.NodesLocalType.TypeLocalType Type, XObjects.RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType Property)> ConcreteProperties(this XObjects.RDSL.Syntax rdsl)
        //{
        //    return from t in rdsl.Nodes.Type.Where(n => !n.@abstract)
        //           from p in t.Properties?.Property
        //           select (Type: t, Property: p);
        //}

        ///// <summary>
        ///// Gets all the non-abstract expression properties (i.e., all property belonging to some non-abstract element type).
        ///// </summary>
        ///// <param name="rdsl">The Xml root of the RDSL.</param>
        ///// <returns>all the non-abstract properties</returns>
        //public static IEnumerable<(XObjects.RDSL.Syntax.NodesLocalType.TypeLocalType Type, XObjects.RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType Property)> Expressions(this XObjects.RDSL.Syntax rdsl)
        //{
        //    return from p in rdsl.ConcreteProperties()
        //           where p.Property.kind == "Expression"
        //           select p;
        //}
    }
}
