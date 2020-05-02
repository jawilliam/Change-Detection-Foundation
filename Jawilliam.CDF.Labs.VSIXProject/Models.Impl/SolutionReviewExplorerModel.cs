using GalaSoft.MvvmLight;
using Jawilliam.CDF.Labs.Common.DBModel;
using System.Collections.ObjectModel;

namespace Jawilliam.CDF.Labs.VSIXProject.Models.Impl
{
    /// <summary>
    /// Represents the <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s model.
    /// </summary>
    public class SolutionReviewExplorerModel : ObservableObject, ISolutionReviewExplorerModel
    {
        /// <summary>
        /// Backign field for <see cref="Project"/>.
        /// </summary>
        private string _project;

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public virtual string Project
        {
            get { return this._project; }
            set
            {
                this._project = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Backign field for <see cref="LeftApproach"/>.
        /// </summary>
        private ApproachInfo _leftApproach;

        /// <summary>
        /// Gets or sets the left approach.
        /// </summary>
        public virtual ApproachInfo LeftApproach
        {
            get { return this._leftApproach; }
            set
            {
                this._leftApproach = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Backing field for <see cref="RightApproach"/>.
        /// </summary>
        private ApproachInfo _rightApproach;

        /// <summary>
        /// Gets or sets the right approach.
        /// </summary>
        public virtual ApproachInfo RightApproach
        {
            get { return this._rightApproach; }
            set
            {
                this._rightApproach = value;
                this.RaisePropertyChanged();
            }
        }
        
        /// <summary>
        /// Gets the delta comparison summary to show.
        /// </summary>
        public virtual ObservableCollection<DisagreedDeltaDescriptor> DisagreedDeltas { get; } = new ObservableCollection<DisagreedDeltaDescriptor>();

        /// <summary>
        /// Backing field for <see cref="SelectedDisagreedDelta"/>.
        /// </summary>
        private DisagreedDeltaDescriptor _selectedDisagreedDelta;

        /// <summary>
        /// Describes the currently selected delta content.
        /// </summary>
        public virtual DisagreedDeltaDescriptor SelectedDisagreedDelta
        {
            get { return this._selectedDisagreedDelta; }
            set
            {
                this._selectedDisagreedDelta = value;
                this.RaisePropertyChanged();
                this.LoadedDisagreedDelta = null;
            }
        }

        /// <summary>
        /// Backing field for <see cref="LoadedDisagreedDelta"/>.
        /// </summary>
        private DisagreedDeltaContent _loadedDisagreedDelta;

        /// <summary>
        /// Gets the currently loaded content.
        /// </summary>
        public virtual DisagreedDeltaContent LoadedDisagreedDelta
        {
            get { return this._loadedDisagreedDelta; }
            set
            {
                this._loadedDisagreedDelta = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
