using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Base;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Implements a same signature-based choice for source code change detection.
    /// </summary>
    public class CSharpSignatureEqualityChoice : Choice<SyntaxNode, SyntaxNode>
    {
        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        public override IList<long> SupportedSteps => new List<long>
        {
            (long)(CSharpFladStepInfo.Equality | CSharpFladStepInfo.Signature)
        };

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        public override void CoreOnStep()
        {
            throw new NotImplementedException();
        }

        //protected virtual void TryToMatch(classde)
    }
}

namespace Jawilliam.CDF.CSharp
{
    public partial class TypeParameterListFormatInfo
    {
        /// <summary>
        /// Determines if two <see cref="TypeParameterListSyntax"/> elements are signature-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool ExactlyEqualSignature(TypeParameterListSyntax original, TypeParameterListSyntax modified)
        {
            if (original.Parameters.Count != modified.Parameters.Count) return false;
            for (int i = 0; i < original.Parameters.Count; i++)
            {
                if(original.Parameters[i].Identifier.ValueText != modified.Parameters[i].Identifier.ValueText)
                    return false;
            }
            return true;
        }
    }
}
