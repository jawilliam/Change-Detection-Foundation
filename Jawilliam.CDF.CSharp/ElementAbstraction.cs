//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;

//namespace Jawilliam.CDF.CSharp
//{
//    public class Componentizer : CSharpSyntaxVisitor<ElementAbstraction<>>

//    /// <summary>
//    /// Represents the abstraction of an element type.
//    /// </summary>
//    /// <typeparam name="TComponents"></typeparam>
//    /// <typeparam name="TElement"></typeparam>
//    public abstract class ElementAbstraction<TComponents, TElement> : DynamicObject where TElement : SyntaxNode
//    {
//        /// <summary>
//        /// Gets 
//        /// </summary>
//        protected TElement Element { get; set; }

//        public override IEnumerable<string> GetDynamicMemberNames()
//        {
//            return Enum.GetNames(typeof(TComponents));
//        }

//        public override bool TryGetMember(GetMemberBinder binder, out object result)
//        {
//            return this.TryGetMember((TComponents)Enum.Parse(typeof(TComponents), binder.Name), out result);
//            //return base.TryGetMember(binder, out result);
//        }

//        public abstract bool TryGetMember(TComponents name, out object result);
//    }

//    public enum MethodDeclarationComponents
//    {
//        DeclaringPath, DeclaringName, ReturnType, ExplicitInterfaceSpecifier, Name, TypeParameters,
//        ParameterNames, ParameterTypes, ParameterList
//    }

//    public class MethodDeclaration : ElementAbstraction<MethodDeclarationComponents, MethodDeclarationSyntax>
//    {
//        public override bool TryGetMember(MethodDeclarationComponents name, out object result)
//        {
//            switch (name)
//            {
//                case MethodDeclarationComponents.DeclaringPath:
//                    result = this.Element.Ancestors()
//                    .Where(a => a.Kind() == SyntaxKind.NamespaceDeclaration ||
//                                a.Kind() == SyntaxKind.ClassDeclaration ||
//                                a.Kind() == SyntaxKind.StructDeclaration ||
//                                a.Kind() == SyntaxKind.InterfaceDeclaration)
//                    .Aggregate("", (s, a) => s + (s == "" ? "" : ".") + (a.Kind() == SyntaxKind.NamespaceDeclaration
//                        ? ((NamespaceDeclarationSyntax)a).Name.ToFullString()
//                        : ((TypeDeclarationSyntax)a).Identifier.ValueText +
//                          ((TypeDeclarationSyntax)a).TypeParameterList?.ToFullString() ?? "")).Replace("\r\n", "");
//                    return true;
//                case MethodDeclarationComponents.DeclaringName:
//                    break;
//                case MethodDeclarationComponents.ReturnType:
//                    break;
//                case MethodDeclarationComponents.ExplicitInterfaceSpecifier:
//                    break;
//                case MethodDeclarationComponents.Name:
//                    break;
//                case MethodDeclarationComponents.TypeParameters:
//                    break;
//                case MethodDeclarationComponents.ParameterNames:
//                    break;
//                case MethodDeclarationComponents.ParameterTypes:
//                    break;
//                case MethodDeclarationComponents.ParameterList:
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
//            }
//        }
//    }
//}
