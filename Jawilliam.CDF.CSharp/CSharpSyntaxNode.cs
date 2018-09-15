using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.CSharp
{
    using System;
    using System.Collections.Generic;

    public abstract partial class CSharpSyntaxNode<TAnnotation> /*: Annotationable<TAnnotation>, ISyntaxEntity*/
    {
        ///// <summary>
        ///// Gets or sets the logic to convert <see cref="Microsoft.CodeAnalysis.SyntaxToken"/>
        ///// </summary>
        //public virtual MutableCSharpSyntax<TAnnotation> Converter { get; set; }

        ///// <summary>
        ///// Gets the text of this syntax node.
        ///// </summary>
        ///// <param name="textFormatInfo">options ruling and supporting the text format.</param>
        ///// <returns>The collection of text chunks.</returns>
        //public abstract IEnumerable<string> GetText(TextFormatInfo textFormatInfo = null);

        ///// <summary>
        ///// Returns the child nodes.
        ///// </summary>
        ///// <returns>Structure to enumerate the child nodes.</returns>
        ///// <param name="representationFormatInfo">options ruling and supporting the representation format.</param>
        ///// <returns>The collection of representation chunks.</returns>
        //public abstract IEnumerable<ISyntaxEntity> GetChildren(RepresentationFormatInfo representationFormatInfo = null);

        ///// <summary>
        ///// Creates a new object that is a copy of the current instance.
        ///// </summary>
        ///// <returns>
        ///// A new object that is a copy of this instance.
        ///// </returns>
        ///// <filterpriority>2</filterpriority>
        //public abstract object Clone();

        ///// <summary>
        ///// Gets the kind of this syntax node.
        ///// </summary>
        //public abstract int GetKind();

        ///// <summary>
        ///// Gets whether or not current type is a token element syntax.
        ///// </summary>
        //public virtual bool IsTokenElementSyntax => false;

        ///// <summary>
        ///// Indicates whether the current object is equal to another object of the same type.
        ///// </summary>
        ///// <returns>
        ///// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        ///// </returns>
        ///// <param name="other">An object to compare with this object.</param>
        //public virtual bool Equals(ISyntaxEntity other)
        //{
        //    if (other == null || this.GetType() != other.GetType()) return false;
        //    if (this.GetKind() != other.GetKind()) return false;
        //    return this.GetFullText() == other.GetFullText();
        //}

        ///// <summary>
        ///// Determines whether the specified object is equal to the current object.
        ///// </summary>
        ///// <returns>
        ///// true if the specified object  is equal to the current object; otherwise, false.
        ///// </returns>
        ///// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || this.GetType() != obj.GetType()) return false;
        //    return this.Equals((ISyntaxEntity)obj);
        //}

        ///// <summary>
        ///// Serves as the default hash function. 
        ///// </summary>
        ///// <returns>
        ///// A hash code for the current object.
        ///// </returns>
        ///// <filterpriority>2</filterpriority>
        //public override int GetHashCode()
        //{
        //    const int b = 378551;
        //    int a = 63689;
        //    int hash = 0;

        //    // If it overflows then just wrap around
        //    unchecked
        //    {
        //        hash = hash * a + ((ISyntaxEntity)this).GetKind().GetHashCode();
        //        a = a * b;
        //        hash = hash * a + this.GetFullText().GetHashCode();
        //    }

        //    return hash;
        //}

        ///// <summary>
        ///// Produces the descendant nodes, in pre-order, of current instance and the proper current node in context of matching experimentation.
        ///// </summary>
        ///// <param name="partner">element version with which to be finally compared the current instance (the original) with.</param>
        ///// <param name="asOriginal">describes the role of current instance into the pair of versions to be compared (true: original, false: modified).</param>
        ///// <param name="info">information ruling the matching criterion.</param>
        ///// <param name="descendInto">function to determine whether or not to descend into the children of a given element.</param>
        ///// <returns>The descendants and self in pre-order.</returns>
        //public virtual IEnumerable<ISyntaxEntity> GetDescendantsAndSelf(ISyntaxEntity partner, bool asOriginal, IMatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity> info, Func<ISyntaxEntity, bool> descendInto = null)
        //{
        //    yield return this;
        //    foreach (var syntaxEntity in this.GetChildren(EntryExtensions.FullRepresentationFormatInfo))
        //    {
        //        var descentantOrChild = syntaxEntity.GetDescendantsAndSelf(null, asOriginal, info, descendInto);
        //        foreach (var d in descentantOrChild) yield return d;
        //    }
        //}
    }

    ///// <summary>
    ///// Implements the logic to decompose elements in tokens to be compared in terms of matching.
    ///// </summary>
    //public class CSharpSyntaxNodeMatchingProvider<TAnnotation> : MatchingProvider<ISyntaxEntity, ISyntaxEntity>
    //{
    //    /// <summary>
    //    /// Configurates a <see cref="IMatchingCriterionInfo{Word,Token}"/> based on the configuration described by <see cref="IMatchingFormatProvider"/>. 
    //    /// </summary>
    //    /// <param name="configurationInfo">describes the configuration to set into the matching criterion.</param>
    //    /// <param name="into">the matching criterion where set the given configuration.</param>
    //    public virtual void ConfigurateInto(IMatchingFormatProvider configurationInfo, MatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity> into)
    //    {
    //        NGramsSimetric<ISyntaxEntity> ngram;
    //        switch (configurationInfo.GramSize)
    //        {
    //            case GramKind.Unigram: ngram = new NGramsSimetric<ISyntaxEntity>(1);break;
    //            case GramKind.Bigram: ngram = new NGramsSimetric<ISyntaxEntity>(2);break;
    //            case GramKind.Trigram:ngram = new NGramsSimetric<ISyntaxEntity>(3);break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }

    //        switch (configurationInfo.Metric)
    //        {
    //            case MetricKind.NGram: ngram.InternalSimetric = new NGramsSimetric<ISyntaxEntity>.DefaultSimetric(); break;
    //            case MetricKind.SimpleMatchingCoefficient: ngram.InternalSimetric = new SimpleMatchingCoefficientSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.RogersTanimoto: ngram.InternalSimetric = new RogersTanimotoSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Jaccard: ngram.InternalSimetric = new JaccardSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Dice: ngram.InternalSimetric = new DiceCoefficientSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Cosine: ngram.InternalSimetric = new CosineSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.NormalizedCanberra: ngram.InternalSimetric = new CanberraSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Ruzicka: ngram.InternalSimetric = new RuzickaSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.EuclideanDistance: ngram.InternalSimetric = new EuclideanDistanceSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.BlockDistance: ngram.InternalSimetric = new BlockDistanceSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Czekanowski: ngram.InternalSimetric = new CzekanowskiSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Motyka: ngram.InternalSimetric = new MotykaSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.BaroniUrbaniBuser: ngram.InternalSimetric = new BaroniUrbaniBuser2Simetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.Levenshtein: ngram.InternalSimetric = new LevenshteinSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.LongestCommonSubsequence: ngram.InternalSimetric = new LongestCommonSubsequenceSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.OverlapCoefficient: ngram.InternalSimetric = new OverlapCoefficientSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.Jaro: ngram.InternalSimetric = new JaroSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.JaroWinkler: ngram.InternalSimetric = new JaroWinklerSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.ChapmanLengthDeviation: ngram.InternalSimetric = new ChapmanLengthDeviation<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.ChapmanMeanLength: ngram.InternalSimetric = new ChapmanMeanLength<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.MongeElkanMax: ngram.InternalSimetric = new MongeElkanMaxSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.MongeElkanAvg: ngram.InternalSimetric = new MongeElkanAvgSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.NeedlemanWunsch: ngram.InternalSimetric = new NeedlemanWunschSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.SmithWaterman: ngram.InternalSimetric = new SmithWatermanSimetric<NGram<ISyntaxEntity>>(); break;
    //            case MetricKind.SoergelDistance: ngram.InternalSimetric = new SoergelDistanceSimetric<NGram<ISyntaxEntity>> { GetComponents = VectorComponents.ByTermFrequency }; break;
    //            case MetricKind.ChawatheMatchingCriterion2: ngram.InternalSimetric = new ChawatheMatchingCriterion2Simetric<NGram<ISyntaxEntity>>(); break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }

    //        into.Metric = ngram;
    //        into.TokenKind = configurationInfo.Word == WordKind.Text ? MatchingTokenKind.Text : MatchingTokenKind.Term;
    //    }

    //    /// <summary>
    //    /// Gets two token sequences, to be compared in terms of matching, produced from two element respectively.
    //    /// </summary>
    //    /// <param name="original">original element version to be finally compared.</param>
    //    /// <param name="modified">modified element version to be finally compared.</param>
    //    /// <param name="info">information ruling the matching criterion.</param>
    //    /// <param name="originalTokens">the resulting sequence produced from the original element.</param>
    //    /// <param name="modifiedTokens">the resulting sequence produced from the modified element.</param>
    //    /// <returns>true if makes sense compare the both given elements, false otherwise.</returns>
    //    public override bool GetTokens(ISyntaxEntity original, ISyntaxEntity modified, IMatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity> info, out IEnumerable<ISyntaxEntity> originalTokens, out IEnumerable<ISyntaxEntity> modifiedTokens)
    //    {
    //        if (info == null) throw new ArgumentNullException(nameof(info));

    //        switch (info.TokenKind)
    //        {
    //            case MatchingTokenKind.Text:
    //                this.GetTextTokens(original, modified, info, out originalTokens, out modifiedTokens);
    //                break;
    //            case MatchingTokenKind.Term:
    //                this.GetTermTokens(original, modified, info, out originalTokens, out modifiedTokens);
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }

    //        return true;
    //    }

    //    private void GetTermTokens(ISyntaxEntity original, ISyntaxEntity modified, IMatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity> info, out IEnumerable<ISyntaxEntity> originalTokens, out IEnumerable<ISyntaxEntity> modifiedTokens)
    //    {
    //        originalTokens = original.GetDescendantsAndSelf(modified, true, info, entity => !entity.IsTokenElementSyntax).Where(entity => entity != original && entity.IsTokenElementSyntax);
    //        modifiedTokens = modified.GetDescendantsAndSelf(original, false, info, entity => !entity.IsTokenElementSyntax).Where(entity => entity != modified && entity.IsTokenElementSyntax);
    //    }

    //    private void GetTextTokens(ISyntaxEntity original, ISyntaxEntity modified, IMatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity> info, out IEnumerable<ISyntaxEntity> originalTokens, out IEnumerable<ISyntaxEntity> modifiedTokens)
    //    {
    //        this.GetTermTokens(original, modified, info, out originalTokens, out modifiedTokens);

    //        var originalTokensArray = originalTokens as ISyntaxEntity[] ?? originalTokens.ToArray();
    //        var modifiedTokensArray = modifiedTokens as ISyntaxEntity[] ?? modifiedTokens.ToArray();

    //        StringBuilder originalText = new StringBuilder(originalTokensArray.Length), modifiedText = new StringBuilder(modifiedTokensArray.Length);
    //        foreach (var syntaxEntity in originalTokensArray)
    //        {
    //            originalText.Append( /*" " + */syntaxEntity.GetFullText());
    //        }
    //        foreach (var syntaxEntity in modifiedTokensArray)
    //        {
    //            modifiedText.Append( /*" " + */syntaxEntity.GetFullText());
    //        }

    //        originalTokens = originalText.ToString().TrimStart(' ').Select(c => new SyntaxToken<TAnnotation>(SyntaxKind.StringLiteralToken) {Text = c.ToString()}).ToArray();
    //        modifiedTokens = modifiedText.ToString().TrimStart(' ').Select(c => new SyntaxToken<TAnnotation>(SyntaxKind.StringLiteralToken) {Text = c.ToString()}).ToArray();
    //    }

    //    ///// <summary>
    //    ///// Gets or sets whether or not a given token must be considered.
    //    ///// </summary>
    //    //public static bool ConsiderPropertyInLikeVariableDeclarations(ISyntaxEntity original, ISyntaxEntity modified, IMatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity>,  ) { get; set; }
    //}

    //partial class MutableCSharpSyntax<TAnnotation> : Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor<CSharpSyntaxNode<TAnnotation>>
    //{
    //}

    //partial class CSharpSyntaxMatchingProvider<TAnnotation> : Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor<CSharpSyntaxNode<TAnnotation>>
    //{
    //    /// <summary>
    //    /// Gets two term token sequences, to be compared in terms of matching, produced from two element respectively.
    //    /// </summary>
    //    /// <param name="original">original element version to be finally compared.</param>
    //    /// <param name="modified">modified element version to be finally compared.</param>
    //    /// <param name="info">information ruling the matching criterion.</param>
    //    /// <param name="originalTokens">the resulting sequence produced from the original element.</param>
    //    /// <param name="modifiedTokens">the resulting sequence produced from the modified element.</param>
    //    protected virtual void GetTermTokens(ISyntaxEntity original, ISyntaxEntity modified, IMatchingCriterionInfo<ISyntaxEntity, ISyntaxEntity> info, out IEnumerable<ISyntaxEntity> originalTokens, out IEnumerable<ISyntaxEntity> modifiedTokens)
    //    {
    //        var originalField = (BaseFieldDeclarationSyntax<TAnnotation>)original;
    //        var modifiedField = (BaseFieldDeclarationSyntax<TAnnotation>)modified;

    //        IList<ISyntaxEntity> originalChildren = new List<ISyntaxEntity>(), modifiedChildren = new List<ISyntaxEntity>();
    //        if (info.OmitProperties == null || !info.OmitProperties.Contains("AttributeLists"))
    //        {
    //            originalChildren.Add(originalField.AttributeLists);
    //            modifiedChildren.Add(modifiedField.AttributeLists);
    //        }
    //        if (info.OmitProperties == null || !info.OmitProperties.Contains("Modifiers"))
    //        {
    //            originalChildren.Add(originalField.Modifiers);
    //            modifiedChildren.Add(modifiedField.Modifiers);
    //        }
    //        if (info.OmitProperties == null || !info.OmitProperties.Contains("Initializer"))
    //        {
    //            // TODO: verify must be single declarations.
    //            if (info.IntersectProperties == null || !info.IntersectProperties.Contains("Initializer") ||
    //                (originalField.Declaration.Variables.List[0].Initializer != null &&
    //                 modifiedField.Declaration.Variables.List[0].Initializer != null))
    //            {
    //                originalChildren.Add(originalField.Declaration.Variables.List[0].Initializer);
    //                modifiedChildren.Add(modifiedField.Declaration.Variables.List[0].Initializer);
    //            }
    //        }

    //        originalTokens = originalChildren.SelectMany(t => t.PreOrderTokens(EntryExtensions.FullRepresentationFormatInfo)).ToArray();
    //        modifiedTokens = modifiedChildren.SelectMany(t => t.PreOrderTokens(EntryExtensions.FullRepresentationFormatInfo)).ToArray();
    //    }
    //}
}
