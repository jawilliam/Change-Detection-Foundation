namespace Jawilliam.CDF.Approach.GumTree
{
    /// <summary>
    /// Represents the arguments for a console call to a native GumTree snapshot.
    /// </summary>
    public class InteropArgs : RevisionPair<string>
    {
        /// <summary>
        /// Initializes the instance with default values for the element file paths.
        /// </summary>
        public InteropArgs()
        {
            this.Original = @"E:\SourceCode\OriginalAbstractBoardGame.cs";
            this.Modified = @"E:\SourceCode\ModifiedAbstractBoardGame.cs";
        }

        /// <summary>
        /// Gets or sets the path of the native GumTree's snapshot. 
        /// </summary>
        public virtual string GumTreePath { get; set; } = @"E:\SourceCode\gumtree-20170525-2.1.0-SNAPSHOT";

        /// <summary>
        /// Gets or sets command options for the native GumTree. 
        /// </summary>
        public virtual string Options { get; set; }
    }
}