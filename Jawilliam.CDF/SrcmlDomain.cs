using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Contains shared methods for resolving domain concerns of a source code represented in SrcML's ASTs.
    /// </summary>
    public static class SrcmlDomain
    {
        /// <summary>
        /// Determines if the source node represents a name of a element type.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <param name="name">the expected label of the ancestor of interest.</param>
        /// <returns></returns>
        private static bool IsNameOf<T>(T source, Func<T, T> parent, Func<T, string> label, string name)
        {
            Debug.Assert(parent != null);
            Debug.Assert(label != null);
            return label(source) == "name" && parent(source) != null && label(parent(source)) == name;
        }

        /// <summary>
        /// Determines if the source node represents a name of a variable declaration.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a variable declaration. False otherwise.</returns>
        public static bool IsVariableDeclarationName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "decl");
        }

        /// <summary>
        /// Determines if the source node represents a name of a function declaration.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a function declaration. False otherwise.</returns>
        public static bool IsFunctionDefinitionName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "function");
        }

        /// <summary>
        /// Determines if the source node represents a name of a namespace.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a namespace. False otherwise.</returns>
        public static bool IsNamespaceName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "namespace");
        }

        /// <summary>
        /// Determines if the source node represents a name of a using directive.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a using directive. False otherwise.</returns>
        public static bool IsUsingDirectiveName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "using");
        }

        /// <summary>
        /// Determines if the source node represents a name of a class.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a class. False otherwise.</returns>
        public static bool IsClassName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "class");
        }

        /// <summary>
        /// Determines if the source node represents a name of a struct.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a struct. False otherwise.</returns>
        public static bool IsStructName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "struct");
        }

        /// <summary>
        /// Determines if the source node represents a name of a interface.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a interface. False otherwise.</returns>
        public static bool IsInterfaceName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "interface");
        }

        /// <summary>
        /// Determines if the source node represents a name of a property.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a property. False otherwise.</returns>
        public static bool IsPropertyName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "property");
        }

        /// <summary>
        /// Determines if the source node represents a name of a constructor.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a constructor. False otherwise.</returns>
        public static bool IsConstructorName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "constructor");
        }

        /// <summary>
        /// Determines if the source node represents a name of a destructor.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a destructor. False otherwise.</returns>
        public static bool IsDestructorName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "destructor");
        }

        /// <summary>
        /// Determines if the source node represents a name of a enum.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a enum. False otherwise.</returns>
        public static bool IsEnumName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "enum");
        }

        /// <summary>
        /// Determines if the source node represents a name of a enum value.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="parent">the how to access the parent of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <returns>True if the source node represents a name of a enum value. False otherwise.</returns>
        public static bool IsEnumValueName<T>(this T source, Func<T, T> parent, Func<T, string> label)
        {
            return IsNameOf(source, parent, label, "decl") && 
                   label(parent(parent(source))) == "block" &&
                   label(parent(parent(parent(source)))) == "enum";
        }

        /// <summary>
        /// Returns the name of a given element.
        /// </summary>
        /// <typeparam name="T">type of the node representing the elements.</typeparam>
        /// <param name="source">the node to check.</param>
        /// <param name="children">the how to access the children of each element.</param>
        /// <param name="label">the how to access the label of each element.</param>
        /// <param name="value">the how to access the value of each element.</param>
        /// <returns>if the given name has a child labeled "name" it returns the resulting name, otherwise it returns null.</returns>
        public static string NameOf<T>(this T source, Func<T, IEnumerable<T>> children, Func<T, string> label, Func<T, string> value)
        {
            Debug.Assert(children != null);
            Debug.Assert(label != null);
            Debug.Assert(value != null);

            var name = children(source).SingleOrDefault(c => label(c) == "name");
            if (name == null) return null;

            var nameComposition = (children(name) ?? new T[0]).ToList();
            return !nameComposition.Any() ? value(name) : nameComposition.Aggregate("", (s, nc) => s + value(nc));
        }
    }
}
