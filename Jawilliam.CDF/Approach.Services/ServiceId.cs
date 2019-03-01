namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Options of Id for identifying some services. 
    /// </summary>
    public enum ServiceId : int
    {
        /// <summary>
        /// The annotation set of the original elements.
        /// </summary>
        OriginalAnnotationSet = 1010,

        /// <summary>
        /// The annotation set of the modified elements.
        /// </summary>
        ModifiedAnnotationSet = 1020,

        /// <summary>
        /// Allows to compute full content hashes.
        /// </summary>
        FullContentHasher = 1030,

        /// <summary>
        /// Allows to compute relevant content hashes.
        /// </summary>
        EssentialContentHasher = 1040,

        /// <summary>
        /// Functionalities related to the matching set.
        /// </summary>
        MatchingSet = 1050,

        /// <summary>
        /// Supports the hierarchical handling of the elements.
        /// </summary>
        HierarchicalAbstraction = 1060,

        /// <summary>
        /// Supports the textual handling of the elements.
        /// </summary>
        TextualAbstraction = 1070,
    }
}
