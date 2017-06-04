namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Contains the kinds of the actions that can result from a change detection.
    /// </summary>
    public enum ActionKind
    {
        /// <summary>
        /// None action.
        /// </summary>
        None = 0,

        /// <summary>
        /// Update.
        /// </summary>
        Update = 1,

        /// <summary>
        /// Insert.
        /// </summary>
        Insert = 2,

        /// <summary>
        /// Delete.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// Move.
        /// </summary>
        Move = 4,

        /// <summary>
        /// Align.
        /// </summary>
        Align = 5
    }
}