using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Base;
using Jawilliam.CDF.Domain;
using Jawilliam.CDF.Approach.Flad;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Fully Language-Aware source code Deltas (for C#).
    /// </summary>
    public class CSharpFlad : FladApproach<SyntaxNode, SyntaxNode>
    {
        /// <summary>
        /// Gets the steps to take for detecting the changes of a revision pair.
        /// </summary>
        public override IList<long> Steps => new List<long>
        {
            (long) (CSharpFladStepInfo.Equality | CSharpFladStepInfo.Signature)
        };

        /// <summary>
        /// Stores the value of <see cref="Choices"/>.
        /// </summary>
        private IList<IChoice<SyntaxNode, SyntaxNode>>  _choices = new List<IChoice<SyntaxNode, SyntaxNode>>
        {
            new CSharpSignatureEqualityChoice()
        };

        /// <summary>
        /// Gets the choices to iterate for detecting the changes of a revision pair.
        /// </summary>
        public override IList<IChoice<SyntaxNode, SyntaxNode>> Choices => this._choices;

        /// <summary>
        /// Stores the value of <see cref="LanguageServiceProvider"/>.
        /// </summary>
        private LanguageServiceProvider languageServiceProvider;

        /// <summary>
        /// Gets the C#-specific information for source code change detection. 
        /// </summary>
        public virtual LanguageServiceProvider LanguageServiceProvider => this.languageServiceProvider ?? (this.languageServiceProvider = new LanguageServiceProvider(this));        
    }
}
