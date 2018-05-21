using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Defines a delta.
    /// </summary>
    /// <typeparam name="TDocument">Type of the document.</typeparam>
    /// <typeparam name="TChange">Type of the changes.</typeparam>
    /// <typeparam name="TRelation">Type of the relations.</typeparam>
    public interface IDelta<TDocument, TChange, TRelation> : IDocument<TChange, TRelation> where TChange : IChange<TDocument> where TRelation : IChangeRelation
    {
    }
}