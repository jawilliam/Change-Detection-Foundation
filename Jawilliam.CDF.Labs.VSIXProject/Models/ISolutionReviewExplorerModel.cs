using Jawilliam.CDF.Labs.Common.DBModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Defines the <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s model.
    /// </summary>
    public interface ISolutionReviewExplorerModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        string Project { get; set; }

        /// <summary>
        /// Gets or sets the left approach.
        /// </summary>
        ApproachInfo LeftApproach { get; set; }

        /// <summary>
        /// Gets or sets the right approach.
        /// </summary>
        ApproachInfo RightApproach { get; set; }

        /// <summary>
        /// Gets the delta comparison summary to show.
        /// </summary>
        ObservableCollection<DisagreedDeltaDescriptor> DisagreedDeltas { get; }

        /// <summary>
        /// Describes the currently selected delta content.
        /// </summary>
        DisagreedDeltaDescriptor SelectedDisagreedDelta { get; set; }

        /// <summary>
        /// Gets the currently loaded content.
        /// </summary>
        DisagreedDeltaContent LoadedDisagreedDelta { get; set; }
    }
}