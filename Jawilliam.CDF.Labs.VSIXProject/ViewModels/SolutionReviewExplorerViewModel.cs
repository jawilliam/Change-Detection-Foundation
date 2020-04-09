using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Jawilliam.CDF.Labs.Common.DBModel;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using Jawilliam.CDF.Labs.VSIXProject.Services;
using Jawilliam.CDF.Labs.VSIXProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.VSIXProject.ViewModels
{
    /// <summary>
    /// Represents a <see cref="SolutionReviewExplorer"/>'s model.
    /// </summary>
    public class SolutionReviewExplorerViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes the instance with a given model and service.
        /// </summary>
        /// <param name="model">given model.</param>
        /// <param name="service">given service.</param>
        public SolutionReviewExplorerViewModel(ISolutionReviewExplorerModel model, ISolutionReviewExplorerService service)
        {
            this.Model = model ?? throw new ArgumentNullException(nameof(model));
            model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == ObservableObject.GetPropertyName(() => this.Model.Project) ||
                    e.PropertyName == ObservableObject.GetPropertyName(() => this.Model.LeftApproach) ||
                    e.PropertyName == ObservableObject.GetPropertyName(() => this.Model.RightApproach))
                {
                    this.Model.DisagreedDeltas.Clear();
                    this.ListDisagreedDeltasCommand.RaiseCanExecuteChanged();
                }
            };
            this.Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [PreferredConstructor]
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        public SolutionReviewExplorerViewModel() : this(SimpleIoc.Default.GetInstance<ISolutionReviewExplorerModel>(),
                                                        SimpleIoc.Default.GetInstance<ISolutionReviewExplorerService>())
        {
        }

        /// <summary>
        /// Returns the project names.
        /// </summary>
        public virtual IEnumerable<string> Projects 
        {
            get { return GitRepository.Projects.Select(p => p.Name); }
        }

        /// <summary>
        /// Gets the approach options.
        /// </summary>
        public virtual List<KeyValuePair<string, ChangeDetectionApproaches>> Approaches
        {
            get
            {
                return new List<KeyValuePair<string, ChangeDetectionApproaches>>
                {
                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | r-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynML),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | r-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.NativeGTtreefiedRoslynML),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | r-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynML),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | r-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynML),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | r-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithIncludeTrivia),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | r-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithIncludeTrivia),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | r-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithIncludeTrivia),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | r-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithIncludeTrivia),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | p-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | p-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | p-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | p-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | p-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | p-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.NativeGTtreefiedRoslynMLAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("C* | p-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("C | p-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | r-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruning),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | r-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruning),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | r-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruning),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | r-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruning),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | r-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | r-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | r-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | r-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | p-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | p-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | p-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | p-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | p-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | p-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("D* | p-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("D | p-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling),

                    new KeyValuePair<string, ChangeDetectionApproaches>("E | r-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | r-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | r-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | r-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | p-Labeling | e-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | p-Labeling | e-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | p-Labeling | i-Trivia | FW",
                        ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling),
                    new KeyValuePair<string, ChangeDetectionApproaches>("E | p-Labeling | i-Trivia | BW",
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling)
                };
            }
        }

        /// <summary>
        /// Gets or sets the attached model.
        /// </summary>
        public virtual ISolutionReviewExplorerModel Model { get; private set; }

        /// <summary>
        /// Gets or sets the attached service.
        /// </summary>
        public virtual ISolutionReviewExplorerService Service { get; private set; }

        /// <summary>
        /// Gets or sets the attached passive view.
        /// </summary>
        public virtual ISolutionReviewExplorerPassiveView PassiveView { get; set; }

        #region ListDisagreedDeltasCommand

        /// <summary>
        /// Backing field for <see cref="ListDisagreedDeltasCommand"/>.
        /// </summary>
        private RelayCommand _listDisagreedDeltasCommand;

        /// <summary>
        /// Command to refresh the delta comparisons to show.
        /// </summary>
        public virtual RelayCommand ListDisagreedDeltasCommand
        {
            get 
            {
                return this._listDisagreedDeltasCommand ?? 
                    (this._listDisagreedDeltasCommand = new RelayCommand(ExecuteListDisagreedDeltasCommand, CanExecuteListDisagreedDeltasCommand));
            }
        }

        /// <summary>
        /// Execute logic for <see cref="ListDisagreedDeltasCommand"/>.
        /// </summary>
        public virtual void ExecuteListDisagreedDeltasCommand()
        {
            this.Model.DisagreedDeltas.Clear();
            var dComparisons = this.Service.GetDisagreedDeltas(this.Model.Project, this.Model.LeftApproach, this.Model.RightApproach);
            dComparisons.ToList().ForEach(dc => Model.DisagreedDeltas.Add(dc));
        }

        /// <summary>
        /// CanExecute logic for <see cref="ListDisagreedDeltasCommand"/>.
        /// </summary>
        public virtual bool CanExecuteListDisagreedDeltasCommand()
        {
            return this.Model.Project != null &&
                   this.Model.LeftApproach != ChangeDetectionApproaches.Manually &&
                   this.Model.RightApproach != ChangeDetectionApproaches.Manually;
        }

        #endregion

        #region LoadSelectedDisagreedDeltaCommand

        /// <summary>
        /// Backing field for <see cref="LoadSelectedDisagreedDeltaCommand"/>.
        /// </summary>
        private RelayCommand _loadSelectedDisagreedDeltaCommand;

        /// <summary>
        /// Command to refresh the delta comparisons to show.
        /// </summary>
        public virtual RelayCommand LoadSelectedDisagreedDeltaCommand
        {
            get
            {
                return this._loadSelectedDisagreedDeltaCommand ??
                    (this._loadSelectedDisagreedDeltaCommand = new RelayCommand(ExecuteLoadSelectedDisagreedDeltaCommand, CanExecuteLoadSelectedDisagreedDeltaCommand));
            }
        }

        /// <summary>
        /// Execute logic for <see cref="LoadSelectedDisagreedDeltaCommand"/>.
        /// </summary>
        public virtual void ExecuteLoadSelectedDisagreedDeltaCommand()
        {
            this.Model.DisagreedDeltas.Clear();
            var dComparisons = this.Service.GetDisagreedDeltas(this.Model.Project, this.Model.LeftApproach, this.Model.RightApproach);
            dComparisons.ToList().ForEach(dc => Model.DisagreedDeltas.Add(dc));
        }

        /// <summary>
        /// CanExecute logic for <see cref="LoadSelectedDisagreedDeltaCommand"/>.
        /// </summary>
        public virtual bool CanExecuteLoadSelectedDisagreedDeltaCommand()
        {
            return false;
        }

        #endregion

        /// <summary>
        /// Informs if a review is in progress.
        /// </summary>
        public virtual bool OnReview { get; protected set; }

        #region StartReviewCommand

        /// <summary>
        /// Backing field for <see cref="StartReviewCommand"/>.
        /// </summary>
        private RelayCommand _startReviewCommand;

        /// <summary>
        /// Command to refresh the delta comparisons to show.
        /// </summary>
        public virtual RelayCommand StartReviewCommand
        {
            get
            {
                return this._startReviewCommand ??
                    (this._startReviewCommand = new RelayCommand(ExecuteStartReviewCommand, CanExecuteStartReviewCommand));
            }
        }

        /// <summary>
        /// Execute logic for <see cref="StartReviewCommand"/>.
        /// </summary>
        public virtual void ExecuteStartReviewCommand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// CanExecute logic for <see cref="StartReviewCommand"/>.
        /// </summary>
        public virtual bool CanExecuteStartReviewCommand()
        {
            return this.Model.SelectedDisagreedDelta != null && !this.OnReview;
        }

        #endregion

        #region EndReviewCommand

        /// <summary>
        /// Backing field for <see cref="EndReviewCommand"/>.
        /// </summary>
        private RelayCommand _endReviewCommand;

        /// <summary>
        /// Command to refresh the delta comparisons to show.
        /// </summary>
        public virtual RelayCommand EndReviewCommand
        {
            get
            {
                return this._endReviewCommand ??
                    (this._endReviewCommand = new RelayCommand(ExecuteEndReviewCommand, CanExecuteEndReviewCommand));
            }
        }

        /// <summary>
        /// Execute logic for <see cref="EndReviewCommand"/>.
        /// </summary>
        public virtual void ExecuteEndReviewCommand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// CanExecute logic for <see cref="EndReviewCommand"/>.
        /// </summary>
        public virtual bool CanExecuteEndReviewCommand()
        {
            return false;
        }

        #endregion
    }
}
