using System;

namespace Jawilliam.CDF.Approach.Matching.CSharp
{
    /// <summary>
    /// Contains options to match two method declarations. 
    /// </summary>
    [Flags]
    public enum MethodDeclarationMatchingOptions
    {
        None = 0,

        /// <summary>
        /// The path of the full name, i.e., namespace and container types.
        /// </summary>
        Path = 1,

        /// <summary>
        /// Whether or not the explicit name must be assumed, e.g., the one including the explicit interface specifier.
        /// </summary>
        ExplicitInterfaceSpecifier = 2,

        /// <summary>
        /// The name of the element, i.e., the name of the method.
        /// </summary>
        Name = 4,

        /// <summary>
        /// Whether or not taking the type parameters into consideration.
        /// </summary>
        TypeParameters = 8,

        /// <summary>
        /// Whether or not taking the parameter list into consideration.
        /// </summary>
        Parameters = 16,

        /// <summary>
        /// All the global-key components must match: <see cref="Path"/>, <see cref="DeclaringTypeName"/>, <see cref="ExplicitInterfaceSpecifier"/>, <see cref="TypeParameters"/>, <see cref="Name"/>, and <see cref="Parameters"/>.
        /// </summary>
        GlobalKey = DeclaringTypeName | Path | ExplicitInterfaceSpecifier | TypeParameters | Name | Parameters,

        /// <summary>
        /// All the relative-key components must match: <see cref="DeclaringTypeName"/>, <see cref="ExplicitInterfaceSpecifier"/>, <see cref="TypeParameters"/>, <see cref="Name"/>, and <see cref="Parameters"/>.
        /// </summary>
        RelativeKey = DeclaringTypeName | ExplicitInterfaceSpecifier | TypeParameters | Name | Parameters,

        /// <summary>
        /// All the local-key components must match: <see cref="ExplicitInterfaceSpecifier"/>, <see cref="TypeParameters"/>, <see cref="Name"/>, and <see cref="Parameters"/>.
        /// </summary>
        LocalKey = ExplicitInterfaceSpecifier | TypeParameters | Name | Parameters,

        /// <summary>
        /// The name of the declaring type, e.g., the name of the class declaring the method of interest.
        /// </summary>
        DeclaringTypeName = 32,
        //,Name, Signature, Type, Global, Explicit,  
    }
}