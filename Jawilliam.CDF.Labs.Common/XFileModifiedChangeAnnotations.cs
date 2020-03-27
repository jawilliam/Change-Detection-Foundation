using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Contains the XML annotations for a file version content summary.
    /// </summary>
    [Serializable]
    [XmlRoot("Annotations")]
    public class XFileModifiedChangeAnnotations : XmlColumn
    {
        /// <summary>
        /// Gets or sets whether or not the related content registers source code changes.
        /// </summary>
        [XmlAttribute("sourceCodeChanges")]
        public virtual bool SourceCodeChanges { get; set; }

        /// <summary>
        /// Gets or sets whether or not the related content registers only comment changes.
        /// </summary>
        [XmlAttribute("onlyCommentChanges")]
        public virtual bool OnlyCommentChanges { get; set; }

        /// <summary>
        /// Gets or sets all the review notes.
        /// </summary>
        [XmlArray("Reviews")]
        [XmlArrayItem("Note")]
        public virtual ReviewNote[] ReviewNotes { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XFileModifiedChangeAnnotations Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XFileModifiedChangeAnnotations>(text ?? "<Annotations/>", encoding);
        }

        /// <summary>
        /// Contains the types of review notes.
        /// </summary>
        public enum ReviewNoteKind
        {
            /// <summary>
            /// Denotes a case that is not clear if it is good or bad. 
            /// </summary>
            Unclear = 0,

            /// <summary>
            /// Denotes a good case that can be still improved.
            /// </summary>
            GoodBut = 1,

            /// <summary>
            /// Denotes a good case, e.g., where a good behavior was observed.
            /// </summary>
            Good = 2,

            /// <summary>
            /// Denotes a good case, e.g., where a bad behavior was observed
            /// </summary>
            Bad = 3,

            /// <summary>
            /// Denotes an interesting note.
            /// </summary>
            Attention = 4,

            /// <summary>
            /// Denotes a found case that is non-relevant.
            /// </summary>
            Found = 5
        }

        /// <summary>
        /// Represents a note taken in a review.
        /// </summary>
        public class ReviewNote
        {
            /// <summary>
            /// Gets or sets a value to identifying a set of related notes.
            /// </summary>
            [XmlAttribute("review")]
            public virtual string Review { get; set; }

            /// <summary>
            /// Gets or sets a value to identifying a set of related reviews.
            /// </summary>
            [XmlAttribute("kind")]
            //[XmlIgnore]
            public virtual ReviewNoteKind Kind { get; set; }

            /// <summary>
            /// Gets or sets a title for the note.
            /// </summary>
            [XmlAttribute("title")]
            public virtual string Title { get; set; }

            /// <summary>
            /// Gets or sets a comment for the note.
            /// </summary>
            [XmlAttribute("text")]
            public virtual string Text { get; set; }

            /// <summary>
            /// Creates a note describing well-detected but bad-structured comment changes. 
            /// </summary>
            /// <param name="review">the review for the created note</param>
            /// <param name="text">the text for the created note.</param>
            /// <returns>A "good but" note titled "Well-detected comment changes, but they are not well-structured". </returns>
            public static ReviewNote WellDetectedButBadStructuredComments(string review = null, string text = null)
            {
                return new ReviewNote
                {
                    Kind = ReviewNoteKind.GoodBut,
                    Review = review,
                    Title = "Well-detected comment changes, but they are not well-structured",
                    Text = text,
                };
            }

            /// <summary>
            /// Creates a note describing bad moved element changes. 
            /// </summary>
            /// <param name="review">the review for the created note</param>
            /// <param name="text">the text for the created note.</param>
            /// <returns>A "bad" note titled "Bad moved element". </returns>
            public static ReviewNote BadMovedElements(string review = null, string text = null)
            {
                return new ReviewNote
                {
                    Kind = ReviewNoteKind.Bad,
                    Review = review,
                    Title = "Bad moved element",
                    Text = text
                };
            }

            /// <summary>
            /// Creates a note describing an example of structure differencing versus text differencing. 
            /// </summary>
            /// <param name="review">the review for the created note</param>
            /// <param name="text">the text for the created note.</param>
            /// <returns>A "attention" note titled "Example of structured diff vs. text diff (fails)". </returns>
            public static ReviewNote StructuredDiffVsTextDiff(string review = null, string text = null)
            {
                return new ReviewNote
                {
                    Kind = ReviewNoteKind.Attention,
                    Review = review,
                    Title = "Example of structured diff vs. text diff (fails)",
                    Text = text
                };
            }
        }
    }
}
