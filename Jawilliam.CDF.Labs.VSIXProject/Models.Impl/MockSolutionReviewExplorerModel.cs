using System;
using System.Collections.ObjectModel;

namespace Jawilliam.CDF.Labs.VSIXProject.Models.Impl
{
    /// <summary>
    /// Represents the <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s model.
    /// </summary>
    public class MockSolutionReviewExplorerModel : SolutionReviewExplorerModel
    {
        /// <summary>
        /// Gets the delta comparison summary to show.
        /// </summary>
        public override ObservableCollection<DisagreedDeltaDescriptor> DisagreedDeltas { get; } = new ObservableCollection<DisagreedDeltaDescriptor>()
        {
            new DisagreedDeltaDescriptor { Index = 1, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 4, LrMismatches = 2, RlMismatches = 0 },
            new DisagreedDeltaDescriptor { Index = 2, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 6, LrMismatches = 2, RlMismatches = 4 },
            new DisagreedDeltaDescriptor { Index = 3, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 14, LrMismatches = 3, RlMismatches = 11 },
            new DisagreedDeltaDescriptor { Index = 4, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 17, LrMismatches = 12, RlMismatches = 5 }
        };
    }
}
