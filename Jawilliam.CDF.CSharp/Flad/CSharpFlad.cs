using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Jawilliam.CDF.Approach;
using Microsoft.CodeAnalysis.CSharp;
using Jawilliam.CDF.Approach.Impl;
using Jawilliam.CDF.Approach.Annotations.Impl;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;
using Jawilliam.CDF.Approach.Criterions.Impl;
using Jawilliam.CDF.Approach.Choices;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Fully Language-Aware source code Deltas (for C#).
    /// </summary>
    public class CSharpFlad : FladApproach<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <remarks>Sets up common services: <see cref="IAnnotationSetService{TElement, TAnnotation}"/>, <see cref="IMatchingSetService{TElement}"/>.</remarks>
        public CSharpFlad()
        {
            this.Services.Remove((int)ServiceId.OriginalAnnotationSet);
            this.Services.Add((int)ServiceId.OriginalAnnotationSet, new OriginalSetService<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this));

            this.Services.Remove((int)ServiceId.ModifiedAnnotationSet);
            this.Services.Add((int)ServiceId.ModifiedAnnotationSet, new ModifiedSetService<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this));

            this.Services.Add((int)ServiceId.HierarchicalAbstraction, new HierarchicalSyntaxNodeService<Annotation<SyntaxNodeOrToken?>>(this) { Id = (int)ServiceId.HierarchicalAbstraction });
            this.Services.Add((int)ServiceId.TextualAbstraction, new TextualSyntaxNodeService { Id = (int)ServiceId.TextualAbstraction });

            this.Services.Add((int)ServiceId.FullContentHasher, new Md5HashingService<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this, 
                Approach.Annotations.Extensions.GetFullContentHash, 
                Approach.Annotations.Extensions.SetFullContentHash) { Id = (int)ServiceId.FullContentHasher });

            this.Services.Add((int)ServiceId.EditScript, new EditScriptService<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this) { Id = (int)ServiceId.EditScript });
        }

        /// <summary>
        /// Gets the steps to take for detecting the changes of a revision pair.
        /// </summary>
        public override IList<long> Steps => new List<long>
        {
            (long) (CSharpFladStepInfo.Equality | CSharpFladStepInfo.Signature),
            (long) (CSharpFladStepInfo.Equality | CSharpFladStepInfo.Subtree),
            (long) (StepInfo.DifferencingPhase | StepInfo.Subtree),
            (long) (StepInfo.ReportPhase)
        };

        /// <summary>
        /// Stores the value of <see cref="Choices"/>.
        /// </summary>
        private IList<IChoice>  _choices;

        /// <summary>
        /// Gets the choices to iterate for detecting the changes of a revision pair.
        /// </summary>
        public override IList<IChoice> Choices
        {
            get
            {
                return this._choices ?? (this._choices = new List<IChoice>
                                         {
                                             //new CSharpSignatureEqualityChoice(this)
                                             new MatchingDiscoveryChoice<SyntaxNodeOrToken?>(this, new FullContentFingerprintMatcher<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this)),
                                             new MatchingDiscoveryChoice<SyntaxNodeOrToken?>(this, new TieBreakingMatcher<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this)),
                                             new McesDifferencingChoice<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this),
                                             new McesReportChoice<SyntaxNodeOrToken?, Annotation<SyntaxNodeOrToken?>>(this)
                                         }
                );
            }
        }

        /// <summary>
        /// Stores the value of <see cref="LanguageServiceProvider"/>.
        /// </summary>
        private LanguageServiceProvider languageServiceProvider;

        /// <summary>
        /// Gets the C#-specific information for source code change detection. 
        /// </summary>
        public virtual LanguageServiceProvider LanguageServiceProvider => this.languageServiceProvider ?? (this.languageServiceProvider = new LanguageServiceProvider(this));

        /// <summary>
        /// Loads the original and modified versions to compare. 
        /// </summary>
        /// <param name="originalSourceCode">original source code.</param>
        /// <param name="modifiedSourceCode">modified source code.</param>
        /// <returns>returns the loaded versions.</returns>
        public static RevisionPair<SyntaxNodeOrToken?> LoadRevisionPair(string originalSourceCode, string modifiedSourceCode)
        {
            return new RevisionPair<SyntaxNodeOrToken?>
            {
                Original = SyntaxFactory.ParseCompilationUnit(originalSourceCode).SyntaxTree.GetRoot(),
                Modified = SyntaxFactory.ParseCompilationUnit(modifiedSourceCode).SyntaxTree.GetRoot()
            };
        }
    }
}
