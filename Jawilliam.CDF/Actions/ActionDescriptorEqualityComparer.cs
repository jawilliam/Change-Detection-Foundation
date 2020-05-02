using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Defines methods to support the comparison of <see cref="ActionDescriptor"/> objects for equality.
    /// </summary>
    public class ActionDescriptorEqualityComparer : IEqualityComparer<ActionDescriptor>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <see cref="MatchDescriptor"/> to compare.</param>
        /// <param name="y">The second object of type <see cref="MatchDescriptor"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public virtual bool Equals(ActionDescriptor x, ActionDescriptor y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.Action != y.Action)
                return false;

            switch (x, y)
            {
                case (InsertOperationDescriptor xi, InsertOperationDescriptor yi):
                    return xi.Parent?.Id == yi.Parent?.Id && 
                           xi.Element.Id == yi.Element.Id &&
                           xi.Position == yi.Position;
                case (DeleteOperationDescriptor xi, DeleteOperationDescriptor yi):
                    return xi.Element.Id == yi.Element.Id;
                case (UpdateOperationDescriptor xi, UpdateOperationDescriptor yi):
                    return xi.Element.Id == yi.Element.Id && xi.Value == yi.Value;
                case (MoveOperationDescriptor xi, MoveOperationDescriptor yi):
                    return xi.Parent?.Id == yi.Parent?.Id &&
                           xi.Element.Id == yi.Element.Id &&
                           xi.Position == yi.Position;
                default:
                    throw new InvalidDataException();
            }
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The Object for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public virtual int GetHashCode(ActionDescriptor obj)
        {
            int hCode;
            switch (obj)
            {
                case InsertOperationDescriptor xi:
                    hCode = (xi.Parent?.Id ?? "").GetHashCode() ^ xi.Element.Id.GetHashCode() ^ xi.Position;
                    break;
                case DeleteOperationDescriptor xi:
                    hCode = xi.Element.Id.GetHashCode();
                    break;
                case UpdateOperationDescriptor xi:
                    hCode = xi.Element.Id.GetHashCode() ^ xi.Value.GetHashCode();
                    break;
                case MoveOperationDescriptor xi:
                    hCode = xi.Parent.Id.GetHashCode() ^ xi.Element.Id.GetHashCode() ^ xi.Position;
                    break;
                default:
                    throw new InvalidDataException();
            }            
            return hCode.GetHashCode();
        }
    }
}
