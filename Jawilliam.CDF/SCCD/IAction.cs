using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Describes a lower-level change.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Gets or sets the specific type of current action.
        /// </summary>
        int Kind { get; set; }
    }

    /// <summary>
    /// Describes the possible action types.
    /// </summary>
    public enum ActionTaxonomy : int
    {

    }
}
