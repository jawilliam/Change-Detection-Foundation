using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.CSharp
{
    public partial class SyntaxToken<TAnnotation> /*: Annotationable<TAnnotation>, ISyntaxEntity*/
    {
        ///// <summary>
        ///// Gets or sets the value text.
        ///// </summary>
        //public virtual string Text { get; set; }

        ///// <summary>
        ///// Gets or sets the kind of this syntax node.
        ///// </summary>
        //public SyntaxKind Kind { get; set; }

        //public SyntaxToken(SyntaxKind kind)
        //{
        //    this.Kind = kind;
        //}

        ///// <summary>
        ///// Copies the value from the given token.
        ///// </summary>
        ///// <param name="token">the token to copy the value from.</param>
        //public virtual void Copy(SyntaxToken<TAnnotation> token)
        //{
        //    this.Text = token.Text;
        //    this.Kind = token.Kind;
        //}

        ///// <summary>
        ///// Copies the value from the given token.
        ///// </summary>
        ///// <param name="token">the token to copy the value from.</param>
        //public virtual void Copy(Microsoft.CodeAnalysis.SyntaxToken token)
        //{
        //    this.Text = token.ValueText;
        //    this.Kind = token.Kind();
        //}

        ///// <summary>
        ///// Creates a new object that is a copy of the current instance.
        ///// </summary>
        ///// <returns>
        ///// A new object that is a copy of this instance.
        ///// </returns>
        ///// <filterpriority>2</filterpriority>
        //public virtual object Clone()
        //{
        //    var newToken = new SyntaxToken<TAnnotation>(this.Kind);
        //    newToken.Copy(this);
        //    return newToken;
        //}

        ///// <summary>
        ///// Gets the kind of this syntax node.
        ///// </summary>
        //int ISyntaxEntity.GetKind()
        //{
        //    return (int)this.Kind;
        //}

        ///// <summary>
        ///// Gets the text of this syntax node.
        ///// </summary>
        ///// <param name="textFormatInfo">options ruling and supporting the text format.</param>
        ///// <returns>The collection of text chunks.</returns>
        //IEnumerable<string> ISyntaxEntity.GetText(TextFormatInfo textFormatInfo)
        //{
        //    yield return Text;
        //}

        ///// <summary>
        ///// Returns the child nodes.
        ///// </summary>
        ///// <returns>Structure to enumerate the child nodes.</returns>
        ///// <param name="representationFormatInfo">options ruling and supporting the representation format.</param>
        ///// <returns>The collection of representation chunks.</returns>
        //IEnumerable<ISyntaxEntity> ISyntaxEntity.GetChildren(RepresentationFormatInfo representationFormatInfo)
        //{
        //    yield break;
        //}

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
        //    if (((ISyntaxEntity)this).GetKind() != other.GetKind()) return false;
        //    return this.Text == other.GetFullText();
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
        //}
    }
}
