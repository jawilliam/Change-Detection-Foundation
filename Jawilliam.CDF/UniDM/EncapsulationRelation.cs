using System.Collections.Generic;

namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Links a container change to all changes it was generated from.
    /// </summary>
    /// <typeparam name="TChange">Type of the related changes.</typeparam>
    public abstract class EncapsulationRelation<TChange> : IChangeRelation
    {
        /// <summary>
        /// Gets or sets the type of the relation.
        /// </summary>
        public virtual int Kind { get; set; }

        /// <summary>
        /// Gets or sets the container change.
        /// </summary>
        public virtual TChange Container { get; set; }

        /// <summary>
        /// Field to store the <see cref="Changes"/> property value.
        /// </summary>
        private IList<TChange> _changes;

        /// <summary>
        /// Gets or sets the aggregated changes.
        /// </summary>
        public virtual IList<TChange> Changes
        {
            get { return this._changes ?? (this._changes = new List<TChange>()); }
            set { this._changes = value; }
        }
    }

    /// <summary>
    /// Aggregates instances of the same change operating on contiguous elements of the document.
    /// </summary>
    /// <typeparam name="TChange">Type of the related changes.</typeparam>
    public class GroupingRelation<TChange> : EncapsulationRelation<TChange> { }

    /// <summary>
    /// Attachs a more precise meaning to the aggregated changes.
    /// </summary>
    /// <typeparam name="TChange">Type of the related changes.</typeparam>
    public class MeaningfulRelation<TChange> : EncapsulationRelation<TChange> { }

    /// <summary>
    /// Aggregates aggregate all changes applied to the same document structure, and organize them in a way that resemble that structure or the way users modified it.
    /// </summary>
    /// <typeparam name="TChange">Type of the related changes.</typeparam>
    public class StructuralRelation<TChange> : EncapsulationRelation<TChange> { }
}
