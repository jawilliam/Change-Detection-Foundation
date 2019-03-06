namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the support for managing edit scripts, for example when generating a "Minimum Conforming Edit Script".
    /// </summary>
    /// <typeparam name="TElement">Type of the hashable elements.</typeparam>
    public interface IEditScriptService<TElement> : IService
    {
        /// <summary>
        /// Inserts a copy of a (modified) element in the original parent.
        /// </summary>
        /// <param name="modified">(modified) element whose copy will be inserted.</param>
        /// <param name="position">as the k-th child of,</param>
        /// <param name="parent">the given (original) parent.</param>
        void Insert(TElement modified, int position, TElement parent);

        /// <summary>
        /// Deletes a (original) element from its parent.
        /// </summary>
        /// <param name="original">modified version to insert,</param>
        void Delete(TElement original);

        /// <summary>
        /// Updates the original version of an element, so that it is equal to its modified version.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        void Update(TElement original, TElement modified);

        /// <summary>
        /// Aligns an (original) element under its parent.
        /// </summary>
        /// <param name="original">(original) element to align,</param>
        /// <param name="position">as the k-th child of (its parent).</param>
        void Align(TElement original, int position);

        /// <summary>
        /// Moves an (original) element into a different parent.
        /// </summary>
        /// <param name="original">(original) element to move.</param>
        /// <param name="position">as the k-th child of,</param>
        /// <param name="parent">the given (original) parent.</param>
        void Move(TElement original, int position, TElement parent);

        /// <summary>
        /// Exposes functionalities for hierarchically handling the hierarchical original versions. 
        /// </summary>
        IHierarchicalAbstractionService<TElement> OriginalsHierarchicalAbstraction { get; }

        /// <summary>
        /// Exposes functionalities for hierarchically handling the hierarchical modified versions. 
        /// </summary>
        IHierarchicalAbstractionService<TElement> ModifiedsHierarchicalAbstraction { get; }

        /// <summary>
        /// Initializes the current service for a edit script generation. Unlike the <see cref="IBeginStep"/> or <see cref="IBeginDetection"/>, this is supposed to be invoked by <see cref="IChoice.OnStep"/>. 
        /// </summary>
        void Begin();

        /// <summary>
        /// Finalizes the current service after a edit script generation. Unlike the <see cref="IEndStep"/> or <see cref="IEndDetection"/>, this is supposed to be invoked by <see cref="IChoice.OnStep"/>.
        /// </summary>
        void End();
    }
}
