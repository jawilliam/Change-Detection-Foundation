using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Stores the matches.
    /// </summary>
    /// <typeparam name="T">Type of the elements.</typeparam>
    public class MatchingInfo<T>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="matchesCapacity">Initial capacity for <see cref="OriginalMatches"/> and <see cref="ModifiedMatches"/>.</param>
        public MatchingInfo(int matchesCapacity)
        {
            this._originalMatches = new Dictionary<T, HashSet<T>>(matchesCapacity);
            this._modifiedMatches = new Dictionary<T, HashSet<T>>(matchesCapacity);
        }

        /// <summary>
        /// Initializes the instance.
        /// </summary>
        public MatchingInfo() { }

        /// <summary>
        /// Stores the value of <see cref="OriginalMatches"/>.
        /// </summary>
        Dictionary<T, HashSet<T>> _originalMatches;

        /// <summary>
        /// Gets or sets the matches per original element. 
        /// </summary>
        public virtual Dictionary<T, HashSet<T>> OriginalMatches
        {
            get { return this._originalMatches ?? (this._originalMatches = new Dictionary<T, HashSet<T>>()); }
            set { this._originalMatches = value; }
        }

        /// <summary>
        /// Stores the value of <see cref="ModifiedMatches"/>.
        /// </summary>
        Dictionary<T, HashSet<T>> _modifiedMatches;

        /// <summary>
        /// Gets or sets the matches per modified element. 
        /// </summary>
        public virtual Dictionary<T, HashSet<T>> ModifiedMatches
        {
            get { return this._modifiedMatches ?? (this._modifiedMatches = new Dictionary<T, HashSet<T>>()); }
            set { this._modifiedMatches = value; }
        }

        /// <summary>
        /// Adds a match both in the <see cref="OriginalMatches"/> and in the <see cref="ModifiedMatches"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        public virtual void AddMatch(T original, T modified)
        {
            // Sets the match for the original.
            HashSet<T> partners = null;
            if (this.OriginalMatches.ContainsKey(original))
                partners = this.OriginalMatches[original];
            else
            {
                partners = new HashSet<T>();
                this.OriginalMatches.Add(original, partners);
            }

            if (!partners.Contains(modified))
                partners.Add(modified);

            // Sets the match for the modified.
            if (this.ModifiedMatches.ContainsKey(modified))
                partners = this.ModifiedMatches[modified];
            else
            {
                partners = new HashSet<T>();
                this.ModifiedMatches.Add(modified, partners);
            }

            if (!partners.Contains(original))
                partners.Add(original);
        }

        /// <summary>
        /// Removes a match both in the <see cref="OriginalMatches"/> and in the <see cref="ModifiedMatches"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        public virtual void RemoveMatch(T original, T modified)
        {
            // Removes the match for the original.
            HashSet<T> partners = null;
            if (this.OriginalMatches.ContainsKey(original))
                partners = this.OriginalMatches[original];
            else
            {
                partners = new HashSet<T>();
                this.OriginalMatches.Add(original, partners);
            }

            if (partners.Contains(modified))
                partners.Remove(modified);

            // Removes the match for the modified.
            if (this.ModifiedMatches.ContainsKey(modified))
                partners = this.ModifiedMatches[modified];
            else
            {
                partners = new HashSet<T>();
                this.ModifiedMatches.Add(modified, partners);
            }

            if (partners.Contains(original))
                partners.Remove(original);
        }

        /// <summary>
        /// Clears all the stored information.
        /// </summary>
        public virtual void Clear()
        {
            this.OriginalMatches.Clear();
            this.ModifiedMatches.Clear();
        }
    }
}
