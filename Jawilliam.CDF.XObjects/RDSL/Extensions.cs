using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.XObjects.RDSL
{
    /// <summary>
    /// Shares extensions related with the RDSL type system (i.e., <see cref="Syntax"/>).
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Informs if the given property is an enumeration property.
        /// </summary>
        /// <param name="property">property of interest.</param>
        /// <returns>true if the given property is an enumeration property, otherwise it returns false.</returns>
        public static bool Enumeration(this RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType property)
        {
            return (property.Options?.Kind.Count ?? 0) > 0;
        }

        /// <summary>
        /// Informs if the given property is a labeling enumeration property.
        /// </summary>
        /// <param name="property">property of interest.</param>
        /// <returns>true if the given property is a labeling enumeration property, otherwise it returns false.</returns>
        public static bool Labeling(this RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType property)
        {
            return property.Enumeration() && property.Options.labeling;
        }

        /// <summary>
        /// Informs if the given element type is a symbolic one.
        /// </summary>
        /// <param name="type">type of interest.</param>
        /// <returns>true if the given element type is a symbolic one, otherwise it returns false.</returns>
        public static bool Symbolic(this RDSL.Syntax.NodesLocalType.TypeLocalType type)
        {
            return type.Properties?.Property?.All(p => p.symbolic) ?? false;
        }

        ///// <summary>
        ///// Informs if the given element type is a symbolic one.
        ///// </summary>
        ///// <param name="type">type of interest.</param>
        ///// <returns>true if the given element type is a symbolic one, otherwise it returns false.</returns>
        //public static bool Collection(this RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType property, )
        //{
        //    return type.Properties.Property.Any(pi => type.Properties.Property.All(pj => pi == pj || pj.readOnly));
        //}

        ///// <summary>
        ///// Informs if the element property is a collection one.
        ///// </summary>
        ///// <param name="property">property of interest.</param>
        ///// <param name="getPropertyInfo">gets the <see cref="PropertyInfo"/> corresponding to a given element property, or null if no one exists.</param>
        ///// <param name="getElementType">gets the element type corresponding to a given <see cref="Type"/>, or null if no one exists.</param>
        ///// <param name="getTypeInfo">gets the <see cref="Type"/> corresponding to a given element type.</param>
        ///// <returns>true if if the element property is a collection one, otherwise it returns false.</returns>
        //public static bool Collection(this Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType propertyType,
        //    Syntax.NodesLocalType.TypeLocalType type,
        //    //Func<Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType, PropertyInfo> getPropertyInfo,
        //    Func<Type, Syntax.NodesLocalType.TypeLocalType> getElementType,
        //    Func<Syntax.NodesLocalType.TypeLocalType, Type> getTypeInfo)
        //{
        //    if (propertyType.kind == "Token")
        //        return false;

        //    var propertyInfo = getTypeInfo(type).GetProperty(propertyType.name);
        //    if (propertyInfo.PropertyType == typeof(SyntaxTokenList))
        //        return true;

        //    if (propertyInfo.PropertyType.IsGenericType)
        //    {
        //        var genericTypeDefinition = propertyInfo.PropertyType.GetGenericTypeDefinition();
        //        if (typeof(SyntaxList<>) == genericTypeDefinition || typeof(SeparatedSyntaxList<>) == genericTypeDefinition)
        //            return true;
        //    }

        //    var elementType = getElementType(propertyInfo.PropertyType);
        //    return elementType != null ? elementType.Collection(getElementType, getTypeInfo) : false;
        //}

        ///// <summary>
        ///// Informs if the given element type is a collection one.
        ///// </summary>
        ///// <param name="type">type of interest.</param>
        ///// <param name="getPropertyInfo">gets the <see cref="PropertyInfo"/> corresponding to a given element property.</param>
        ///// <param name="getElementType">gets the element type corresponding to a given <see cref="Type"/>, or null if no one exists.</param>
        ///// <param name="getTypeInfo">gets the <see cref="Type"/> corresponding to a given element type, or null if no one exists.</param>
        ///// <returns>true if the given element type is a collection one, otherwise it returns false.</returns>
        //public static bool Collection(this Syntax.NodesLocalType.TypeLocalType type, 
        //    //Func<Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType, PropertyInfo> getPropertyInfo,
        //    Func<Type, Syntax.NodesLocalType.TypeLocalType> getElementType,
        //    Func<Syntax.NodesLocalType.TypeLocalType, Type> getTypeInfo)
        //{
        //    if(type.name == "VariableDeclarationSyntax")
        //        return true;

        //    var nonReadOnlyProperties = type.Properties?.Property?.Where(p => !p.readOnly).ToList();
        //    if (nonReadOnlyProperties.Count != 1)
        //        return false;

        //    return nonReadOnlyProperties.Single().Collection(type, getElementType, getTypeInfo);
        //}

        ///// <summary>
        ///// Informs if the given property is a token.
        ///// </summary>
        ///// <param name="property">property of interest.</param>
        ///// <returns>true if the given property is a token, otherwise it returns false.</returns>
        //public static bool ReadOnly(this RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType property)
        //{
        //    return property.kind == "Token";
        //}

        ///// <summary>
        ///// Informs if the given property is a token.
        ///// </summary>
        ///// <param name="property">property of interest.</param>
        ///// <returns>true if the given property is a token, otherwise it returns false.</returns>
        //public static bool Token(this RDSL.Syntax.NodesLocalType.TypeLocalType.PropertiesLocalType.PropertyLocalType property)
        //{
        //    return property.kind == "Token";
        //}
    }
}
