using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.CSharp
{
    public class SyntaxList<TAnnotation, T> : CSharpSyntaxNode<TAnnotation> where T: CSharpSyntaxNode<TAnnotation>
    {
     //   public SyntaxList(SyntaxKind kind)
     //   {
     //       this.Kind = kind;
     //   }

     //   /// <summary>
     //   /// Gets the kind of this syntax node.
     //   /// </summary>
     //   public sealed override int GetKind()
     //   {
     //       return (int)this.Kind;
     //   }

     //   public readonly SyntaxKind Kind;

     //   private IList<T> _list;

     //   public virtual IList<T> List
     //   {
     //       get { return this._list ?? (this._list = new List<T>()); }
     //       set { this._list = value; }
     //   }

     //   /// <summary>
     //   /// Gets the text of this syntax node.
     //   /// </summary>
     //   /// <param name="textFormatInfo">options ruling and supporting the text format.</param>
     //   /// <returns>The collection of text chunks.</returns>
     //   public override IEnumerable<string> GetText(TextFormatInfo textFormatInfo = null)
     //   {
     //       return this.List.SelectMany(entity => entity.GetText(textFormatInfo));
     //   }

     //   /// <summary>
     //   /// Returns the child nodes.
     //   /// </summary>
     //   /// <returns>Structure to enumerate the child nodes.</returns>
     //   /// <param name="representationFormatInfo">options ruling and supporting the representation format.</param>
     //   /// <returns>The collection of representation chunks.</returns>
     //   public override IEnumerable<ISyntaxEntity> GetChildren(RepresentationFormatInfo representationFormatInfo = null)
     //   {
     //       switch (representationFormatInfo?.Kind ?? RepresentationFormatKind.Fine)
     //       {
     //           case RepresentationFormatKind.Fine:
     //           case RepresentationFormatKind.Coarse:
     //           case RepresentationFormatKind.Full:
     //               return this.List;
     //           case RepresentationFormatKind.Tokens:
     //               return new T[0];
     //           default: throw new ArgumentOutOfRangeException(nameof(representationFormatInfo));
     //       }
     //   }

     //   /// <summary>
     //   /// Creates a new object that is a copy of the current instance.
     //   /// </summary>
     //   /// <returns>
     //   /// A new object that is a copy of this instance.
     //   /// </returns>
     //   /// <filterpriority>2</filterpriority>
     //   public override object Clone()
     //   {
     //       var result = new SyntaxList<TAnnotation, T>(this.Kind);
     //       result.Copy(this);
     //       return result;
     //   }

     //   /// <summary>
     //   /// Inserts one node as the k-child.
     //   /// </summary>
     //   /// <param name="thisNode">The node to be inserted.</param>
     //   /// <param name="asTheKChild">The k-child index where to insert the <paramref name="thisNode"/>.</param>
    	///// <param name="representationFormatInfo">options ruling and supporting the representation format.</param>
    	///// <param name="offset">the reference index to locate the target child.</param>
     //   public virtual bool Insert(T thisNode, int asTheKChild, ref int offset, RepresentationFormatInfo representationFormatInfo = null)
     //   {
     //       switch (representationFormatInfo?.Kind ?? RepresentationFormatKind.Fine)
     //       {
     //           case RepresentationFormatKind.Fine:
     //           case RepresentationFormatKind.Coarse:
     //               this.List.Insert(asTheKChild, thisNode);
     //               return true;
     //           case RepresentationFormatKind.Full:
     //               this.List.Insert(asTheKChild, thisNode);
     //               return true;
     //           default: throw new ArgumentOutOfRangeException(nameof(representationFormatInfo));
     //       }
     //   }

     //   /// <summary>
     //   /// Inserts one node as the k-child.
     //   /// </summary>
     //   /// <param name="thisNode">The node to be inserted.</param>
     //   /// <param name="asTheKChild">The k-child index where to insert the <paramref name="thisNode"/>.</param>
     //   /// <param name="representationFormatInfo">options ruling and supporting the representation format.</param>
     //   public virtual void Insert(T thisNode, int asTheKChild, RepresentationFormatInfo representationFormatInfo = null)
     //   {
     //       int offset = 0;
     //       if (!this.Insert(thisNode, asTheKChild, ref offset, representationFormatInfo))
     //           throw new ApplicationException("Bad managed insert.");
     //   }

     //   /// <summary>
     //   /// Deletes one node from its parent.
     //   /// </summary>
     //   /// <param name="thisNode">The node to be deleted.</param>
     //   public virtual void Delete(T thisNode)
     //   {
     //       this.List?.Remove(thisNode);
     //   }

     //   /// <summary>
    	///// Copies the value from the given node.
    	///// </summary>
    	///// <param name="node">the node to copy the value from.</param>
    	//public virtual void Copy<TK>(Microsoft.CodeAnalysis.SyntaxList<TK> node) where TK : SyntaxNode
     //   {
     //       this.List = node.Select(s => (T)this.Converter.Visit(s)).ToList();
     //   }

     //   /// <summary>
     //   /// Copies the value from the given node.
     //   /// </summary>
     //   /// <param name="node">the node to copy the value from.</param>
     //   public virtual void Copy(SyntaxList<TAnnotation, T> node)
     //   {
     //       this.List = node.List?.Select(s => (T)s.Clone()).ToList();
     //   }
    }

    //public partial class MutableCSharpSyntax<TAnnotation>
    //{
    //    /// <summary>
    //    /// Called when the visitor visits a GenericNameSyntax node.
    //    /// </summary>
    //    public virtual CSharpSyntaxNode<TAnnotation> Visit<T, TSyntax>(Microsoft.CodeAnalysis.SyntaxList<T> node) where T : SyntaxNode where TSyntax : CSharpSyntaxNode<TAnnotation>
    //    {
    //        var result = new SyntaxList<TAnnotation, TSyntax>(SyntaxKind.List);
    //        var oldConverter = result.Converter;
    //        try
    //        {
    //            result.Converter = this;
    //            result.Copy(node);
    //        }
    //        finally
    //        {
    //            result.Converter = oldConverter;
    //        }

    //        return result;
    //    }
    //}
}
