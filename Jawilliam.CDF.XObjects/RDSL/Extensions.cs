using System;
using System.Collections.Generic;
using System.Linq;
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
