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
        private ChangeDetectionApproaches _leftApproach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynML;

        /// <summary>
        /// Gets or sets the left approach.
        /// </summary>
        public virtual ChangeDetectionApproaches LeftApproach
        {
            get { return this._leftApproach; }
            set
            {
                this._leftApproach = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Backign field for <see cref="RightApproach"/>.
        /// </summary>
        private ChangeDetectionApproaches _rightApproach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynML;

        /// <summary>
        /// Gets or sets the right approach.
        /// </summary>
        public virtual ChangeDetectionApproaches RightApproach
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
        public virtual ObservableCollection<DeltaComparisonDescriptor> DeltaComparisons { get; } = new ObservableCollection<DeltaComparisonDescriptor>();
    }
}
