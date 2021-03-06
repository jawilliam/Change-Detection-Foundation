﻿namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Options for identifying, for example, the <see cref="MatchInfo{TElement}.Criterion"/>. 
    /// </summary>
    public enum MatchInfoCriterions : int
    {
        Unknown = 0,
        
        /// <summary>
        /// The matched versions have identical full content.
        /// </summary>
        IdenticalFullHash = 1,

        /// <summary>
        /// The matched versions have identical essential content.
        /// </summary>
        IdenticalEssentialHash = 2,

        /// <summary>
        /// Pairwise matching on identical subtrees.
        /// </summary>
        PairwiseIdenticalSubtree = 3,

        /// <summary>
        /// Pairwise matching because their parents were previously matched.
        /// </summary>
        PairwiseTunneling = 4,

        /// <summary>
        /// Pairwise matching because some of their children were previously matched.
        /// </summary>
        PairwiseBubbling = 5,

        /// <summary>
        /// The matched versions are an original version copied from the modified version and the modified version. They were probably matched during the generation of a insert action (e.g., minimum conforming edit script). 
        /// </summary>
        Insert = 6,

        /// <summary>
        /// The matched versions are the root of the comparing file or fragments (it is required for "Minimun Conforming Edit Script"),
        /// </summary>
        RootsAlwaysMatch = 7,

        Equality = 8,

        NameEquality = 9,

        SignatureEquality = 10,

        Similarity = 11,

        Alias = 12,
    }
}
