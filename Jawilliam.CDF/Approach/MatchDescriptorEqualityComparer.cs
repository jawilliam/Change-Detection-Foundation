using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines methods to support the comparison of <see cref="MatchDescriptor"/> objects for equality.
    /// </summary>
    public class MatchDescriptorEqualityComparer : IEqualityComparer<MatchDescriptor>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <see cref="MatchDescriptor"/> to compare.</param>
        /// <param name="y">The second object of type <see cref="MatchDescriptor"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public virtual bool Equals(MatchDescriptor x, MatchDescriptor y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.Original.Id == y.Original.Id && x.Modified.Id == y.Modified.Id)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The Object for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public virtual int GetHashCode(MatchDescriptor obj)
        {
            int hCode = obj.Original.Id.GetHashCode() ^ obj.Modified.Id.GetHashCode();
            return hCode.GetHashCode();
        }
    }
}
