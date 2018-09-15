using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.CSharp
{
    public class SyntaxTokenList<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
        public virtual SyntaxToken<TAnnotation> Separator { get; set; }
        private IList<SyntaxToken<TAnnotation>> _list;
        private SyntaxKind _kind;

        public SyntaxTokenList(SyntaxKind kind)
        {
            this._kind = kind;
        }

     //   /// <summary>
     //   /// Gets the kind of this syntax node.
     //   /// </summary>
     //   public sealed override int GetKind()
     //   {
     //       return (int)this._kind;
     //   }

     //   public virtual IList<SyntaxToken<TAnnotation>> List
     //   {
     //       get { return this._list ?? (this._list = new List<SyntaxToken<TAnnotation>>()); }
     //       set { this._list = value; }
     //   }

     //   /// <summary>
     //   /// Gets the text of this syntax node.
     //   /// </summary>
     //   /// <param name="textFormatInfo">options ruling and supporting the text format.</param>
     //   /// <returns>The collection of text chunks.</returns>
     //   public override IEnumerable<string> GetText(TextFormatInfo textFormatInfo = null)
     //   {
     //       var last = this.List.LastOrDefault();
     //       return this.List.Select(entity => entity.Text + (entity != last ? (this.Separator?.Text ?? "") : ""));
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
     //               return this.List;
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
     //       var result = new SyntaxTokenList<TAnnotation>(this._kind);
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
     //   public virtual bool Insert(ISyntaxEntity thisNode, int asTheKChild, ref int offset, RepresentationFormatInfo representationFormatInfo = null)
     //   {
     //       switch (representationFormatInfo?.Kind ?? RepresentationFormatKind.Fine)
     //       {
     //           case RepresentationFormatKind.Fine:
     //           case RepresentationFormatKind.Coarse:
     //           case RepresentationFormatKind.Tokens:
     //           case RepresentationFormatKind.Full:
     //               this.List.Insert(asTheKChild, (SyntaxToken<TAnnotation>)thisNode);
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
     //   public virtual void Insert(ISyntaxEntity thisNode, int asTheKChild, RepresentationFormatInfo representationFormatInfo = null)
     //   {
     //       int offset = 0;
     //       if (!this.Insert((SyntaxToken<TAnnotation>)thisNode, asTheKChild, ref offset, representationFormatInfo))
     //           throw new ApplicationException("Bad managed insert.");
     //   }

     //   /// <summary>
     //   /// Deletes one node from its parent.
     //   /// </summary>
     //   /// <param name="thisNode">The node to be deleted.</param>
     //   public virtual void Delete(ISyntaxEntity thisNode)
     //   {
     //       this.List?.Remove((SyntaxToken<TAnnotation>)thisNode);
     //   }

     //   /// <summary>
    	///// Copies the value from the given node.
    	///// </summary>
    	///// <param name="node">the node to copy the value from.</param>
    	//public virtual void Copy(SyntaxTokenList node)
     //   {
     //       this.List = node.Select(s => new SyntaxToken<TAnnotation>(s.Kind()) { Text = s.Text }).ToList();
     //   }

     //   /// <summary>
     //   /// Copies the value from the given node.
     //   /// </summary>
     //   /// <param name="node">the node to copy the value from.</param>
     //   public virtual void Copy(SyntaxTokenList<TAnnotation> node)
     //   {
     //       this.List = node.List?.Select(s => (SyntaxToken<TAnnotation>)s.Clone()).ToList();
     //       this.Separator = node.Separator;
     //       this._kind = node._kind;
     //   }
    }

    //public partial class MutableCSharpSyntax<TAnnotation>
    //{
    //    /// <summary>
    //    /// Called when the visitor visits a GenericNameSyntax node.
    //    /// </summary>
    //    public virtual CSharpSyntaxNode<TAnnotation> Visit(Microsoft.CodeAnalysis.SyntaxTokenList node)
    //    {
    //        var result = new SyntaxTokenList<TAnnotation>(SyntaxKind.List);
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
