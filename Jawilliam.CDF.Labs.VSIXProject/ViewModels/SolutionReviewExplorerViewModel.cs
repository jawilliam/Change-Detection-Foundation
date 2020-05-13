using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Labs.Common.DBModel;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using Jawilliam.CDF.Labs.VSIXProject.Properties;
using Jawilliam.CDF.Labs.VSIXProject.Services;
using Jawilliam.CDF.Labs.VSIXProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Jawilliam.CDF.CSharp.RoslynML;
using System.Xml.Linq;
using System.IO;
using System.Text;
using Jawilliam.CDF.Actions;

namespace Jawilliam.CDF.Labs.VSIXProject.ViewModels
{

    /// <summary>
    /// Represents a <see cref="SolutionReviewExplorer"/>'s model.
    /// </summary>
    public class SolutionReviewExplorerViewModel : ViewModelBase
    {
        private bool _onReview;

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
                    this.ListDisagreedDeltasCommand?.RaiseCanExecuteChanged();
                    this.LoadSelectedDisagreedDeltaCommand?.RaiseCanExecuteChanged();
                }

                if (e.PropertyName == ObservableObject.GetPropertyName(() => this.Model.SelectedDisagreedDelta))
                {
                    this.LoadSelectedDisagreedDeltaCommand?.RaiseCanExecuteChanged();
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
        public virtual List<ApproachInfo> Approaches
        {
            get
            {
                return new List<ApproachInfo>
                {
                    new ApproachInfo { Title = "C* | default-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynML, 
                        Forward = true, FileFormat = (FileFormatKind)5 },
                    new ApproachInfo { Title = "C | default-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynML, 
                        Forward = true, FileFormat = (FileFormatKind)5 },

                    new ApproachInfo { Title = "C* | default-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynML, 
                        Forward = false, FileFormat = (FileFormatKind)5 },
                    new ApproachInfo { Title = "C | default-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynML, 
                        Forward = false, FileFormat = (FileFormatKind)5 },

                    new ApproachInfo { Title = "C* | default-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithIncludeTrivia, 
                        Forward = true, FileFormat = (FileFormatKind)20 },
                    new ApproachInfo { Title = "C | default-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithIncludeTrivia, 
                        Forward = true, FileFormat = (FileFormatKind)20 },

                    new ApproachInfo { Title = "C* | default-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithIncludeTrivia, 
                        Forward = false, FileFormat = (FileFormatKind)20 },
                    new ApproachInfo { Title = "C | default-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithIncludeTrivia, 
                        Forward = false, FileFormat = (FileFormatKind)20 },

                    new ApproachInfo { Title = "C* | relaxed-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)20 },
                    new ApproachInfo { Title = "C | relaxed-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)20 },

                    new ApproachInfo { Title = "C* | relaxed-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)20 },
                    new ApproachInfo { Title = "C | relaxed-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLWithIncludeTriviaAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)20 },

                    new ApproachInfo { Title = "C* | relaxed-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)5 },
                    new ApproachInfo { Title = "C | relaxed-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.NativeGTtreefiedRoslynMLAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)5 },

                    new ApproachInfo { Title = "C* | relaxed-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)5 },
                    new ApproachInfo { Title = "C | relaxed-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.InverseNativeGTtreefiedRoslynMLAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)5 },

                    new ApproachInfo { Title = "D* | default-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruning, 
                        Forward = true, FileFormat = (FileFormatKind)12 },
                    new ApproachInfo { Title = "D | default-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruning, 
                        Forward = true, FileFormat = (FileFormatKind)12 },

                    new ApproachInfo { Title = "D* | default-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruning, 
                        Forward = false, FileFormat = (FileFormatKind)12 },
                    new ApproachInfo { Title = "D | default-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruning, 
                        Forward = false, FileFormat = (FileFormatKind)12 },

                    new ApproachInfo { Title = "D* | default-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia, 
                        Forward = true, FileFormat = (FileFormatKind)28 },
                    new ApproachInfo { Title = "D | default-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia, 
                        Forward = true, FileFormat = (FileFormatKind)28 },

                    new ApproachInfo { Title = "D* | default-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia, 
                        Forward = false, FileFormat = (FileFormatKind)28 },
                    new ApproachInfo { Title = "D | default-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTrivia, 
                        Forward = false, FileFormat = (FileFormatKind)28 },

                    new ApproachInfo { Title = "D* | relaxed-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)12 },
                    new ApproachInfo { Title = "D | relaxed-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)12 },

                    new ApproachInfo { Title = "D* | relaxed-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)12 },
                    new ApproachInfo { Title = "D | relaxed-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)12 },

                    new ApproachInfo { Title = "D* | relaxed-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.RepairedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)28 },
                    new ApproachInfo { Title = "D | relaxed-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)28 },

                    new ApproachInfo { Title = "D* | relaxed-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.RepairedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)28 },
                    new ApproachInfo { Title = "D | relaxed-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningAndIncludeTriviaAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)28 },

                    new ApproachInfo { Title = "E | default-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1, 
                        Forward = true, FileFormat = (FileFormatKind)44 },
                    new ApproachInfo { Title = "E | default-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1, 
                        Forward = false, FileFormat = (FileFormatKind)44 },
                    new ApproachInfo { Title = "E | default-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia, 
                        Forward = true, FileFormat = (FileFormatKind)60 },
                    new ApproachInfo { Title = "E | default-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTrivia, 
                        Forward = false, FileFormat = (FileFormatKind)60 },
                    new ApproachInfo { Title = "E | relaxed-Labeling | e-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)44 },
                    new ApproachInfo { Title = "E | relaxed-Labeling | e-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)44 },
                    new ApproachInfo { Title = "E | relaxed-Labeling | i-Trivia | FW",
                        Approach = ChangeDetectionApproaches.ExpandedNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling, 
                        Forward = true, FileFormat = (FileFormatKind)60 },
                    new ApproachInfo { Title = "E | relaxed-Labeling | i-Trivia | BW",
                        Approach = ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruningDefoliationMinH1AndIncludeTriviaAndPermissiveLabeling, 
                        Forward = false, FileFormat = (FileFormatKind)60 }
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
            var dComparisons = this.Service.GetDisagreedDeltas(this.Model.Project, this.Model.LeftApproach.Approach, this.Model.RightApproach.Approach);
            dComparisons.ToList().ForEach(dc => Model.DisagreedDeltas.Add(dc));
        }

        /// <summary>
        /// CanExecute logic for <see cref="ListDisagreedDeltasCommand"/>.
        /// </summary>
        public virtual bool CanExecuteListDisagreedDeltasCommand()
        {
            return this.Model?.Project != null &&
                   this.Model?.LeftApproach?.Approach != ChangeDetectionApproaches.Manually &&
                   this.Model?.RightApproach?.Approach != ChangeDetectionApproaches.Manually;
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
            this.Model?.LoadedDisagreedDelta?.DisagreedMatches.ForEach(disagreedMatch =>
            {
                disagreedMatch.PropertyChanged -= this.DisagreedMatchPropertyChanged;
            });

            this.Model.LoadedDisagreedDelta = this.Service.LoadDisagreedDelta(this.Model.Project,
                this.Model.SelectedDisagreedDelta.LeftId,
                this.Model.SelectedDisagreedDelta.RightId,
                this.Model.LeftApproach);

            this.Model?.LoadedDisagreedDelta?.DisagreedMatches.ForEach(disagreedMatch =>
            {
                disagreedMatch.PropertyChanged += this.DisagreedMatchPropertyChanged;
            });

            System.IO.File.WriteAllText(Settings.Default.OriginalFilePath, this.Model.LoadedDisagreedDelta.ContentVersionPair.Item1.SourceCode);
            System.IO.File.WriteAllText(Settings.Default.ModifiedFilePath, this.Model.LoadedDisagreedDelta.ContentVersionPair.Item2.SourceCode);

            System.IO.File.WriteAllText(Settings.Default.FullOriginalAstPath, this.Model.LoadedDisagreedDelta.FullAsts.Original.ToString());
            System.IO.File.WriteAllText(Settings.Default.FullModifiedAstPath, this.Model.LoadedDisagreedDelta.FullAsts.Modified.ToString());

            var dr = (DetectionResult)this.Model.LoadedDisagreedDelta.Review.DetectionResult;
            System.IO.File.WriteAllText(Settings.Default.RatedMatching, dr.WriteXmlColumn());
            this.RaisePropertyChanged(ObservableObject.GetPropertyName(() => this.Review));
            this.SubmitReviewCommand?.RaiseCanExecuteChanged();
            //System.IO.File.WriteAllText(Settings.Default.RatedDifferencing, this.Model.LoadedDisagreedDelta.FullAsts.Item2.ToString());
        }

        /// <summary>
        /// CanExecute logic for <see cref="LoadSelectedDisagreedDeltaCommand"/>.
        /// </summary>
        public virtual bool CanExecuteLoadSelectedDisagreedDeltaCommand()
        {
            return //!this.OnReview && 
                   this.Model.Project != null &&
                   this.Model.SelectedDisagreedDelta != null &&
                   this.Model.SelectedDisagreedDelta.LeftId != null &&
                   this.Model.SelectedDisagreedDelta.RightId != null;
        }

        #endregion

        ///// <summary>
        ///// Informs if a review is in progress.
        ///// </summary>
        //public virtual bool OnReview
        //{
        //    get => this._onReview;
        //    set 
        //    {
        //        this._onReview = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        #region SubmitReviewCommand

        /// <summary>
        /// Backing field for <see cref="SubmitReviewCommand"/>.
        /// </summary>
        private RelayCommand _submitReviewCommand;

        /// <summary>
        /// Command to refresh the delta comparisons to show.
        /// </summary>
        public virtual RelayCommand SubmitReviewCommand
        {
            get
            {
                return this._submitReviewCommand ??
                    (this._submitReviewCommand = new RelayCommand(ExecuteSubmitReviewCommand, CanExecuteSubmitReviewCommand));
            }
        }

        /// <summary>
        /// Execute logic for <see cref="SubmitReviewCommand"/>.
        /// </summary>
        public virtual void ExecuteSubmitReviewCommand()
        {
            this.Service.SubmitReview(this.Model.Project, this.Model.LoadedDisagreedDelta.Review);
        }

        /// <summary>
        /// CanExecute logic for <see cref="SubmitReviewCommand"/>.
        /// </summary>
        public virtual bool CanExecuteSubmitReviewCommand()
        {
            return this.Model.SelectedDisagreedDelta != null && 
                //this.OnReview &&
                this.Model.LoadedDisagreedDelta?.Review != null &&
                Model.LoadedDisagreedDelta.DisagreedMatches.Any(rm => rm.Reviewed || rm.ReviewedModified || rm.ReviewedOriginal);
        }

        

        #endregion

        //#region EndReviewCommand

        ///// <summary>
        ///// Backing field for <see cref="EndReviewCommand"/>.
        ///// </summary>
        //private RelayCommand _endReviewCommand;

        ///// <summary>
        ///// Command to refresh the delta comparisons to show.
        ///// </summary>
        //public virtual RelayCommand EndReviewCommand
        //{
        //    get
        //    {
        //        return this._endReviewCommand ??
        //            (this._endReviewCommand = new RelayCommand(ExecuteEndReviewCommand, CanExecuteEndReviewCommand));
        //    }
        //}

        ///// <summary>
        ///// Execute logic for <see cref="EndReviewCommand"/>.
        ///// </summary>
        //public virtual void ExecuteEndReviewCommand()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// CanExecute logic for <see cref="EndReviewCommand"/>.
        ///// </summary>
        //public virtual bool CanExecuteEndReviewCommand()
        //{
        //    return false;
        //}

        //#endregion

        /// <summary>
        /// Gets the rated matching.
        /// </summary>
        public virtual string Review
        {
            get
            {
                var rv = this.Model.LoadedDisagreedDelta?.Review;
                //var dr = (DetectionResult)this.Model.LoadedDisagreedDelta?.Review.DetectionResult;
                return rv?.DetectionResult != null 
                    ? XElement.Parse(rv.Matching).ToString() + 
                      System.Environment.NewLine + 
                      XElement.Parse(rv.Differencing).ToString()
                    : "";
            }
        }

        private void DisagreedMatchPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is RateableMatch rm)
            {
                if (e.PropertyName == ObservableObject.GetPropertyName(()
                    => rm.ExpectedOriginal4ThisModified_GumTreeId))
                {
                    if (rm.ExpectedOriginal4ThisModified_GumTreeId == null &&
                        rm.ExpectedOriginal4ThisModified != null)
                    {
                        //rm.ExpectedOriginal4ThisModified.GumTreeId = "-1";
                        rm.ExpectedOriginal4ThisModified.Id = "-1";
                        rm.ExpectedOriginal4ThisModified.Type = "";
                        rm.ExpectedOriginal4ThisModified.Hint = null;
                    }
                    else if (rm.ExpectedOriginal4ThisModified_GumTreeId != null)
                    {
                        var original = this.Model.LoadedDisagreedDelta.FullAsts
                            .GumTreeOriginals[rm.ExpectedOriginal4ThisModified_GumTreeId];
                        rm.ExpectedOriginal4ThisModified ??= new Common.DBModel.ElementDescription
                        {
                            //GumTreeId = "-1",
                            Id = "-1",
                            Type = "",
                            Hint = null
                        };
                        //rm.ExpectedOriginal4ThisModified.GumTreeId = original.GtID();
                        rm.ExpectedOriginal4ThisModified.Id = original.RmId();
                        rm.ExpectedOriginal4ThisModified.Type = original.Attribute("kind")?.Value ?? original.Name.LocalName;
                        //rm.ExpectedOriginal4ThisModified.Hint = original.Value;
                    }
                    rm.RaisePropertyChanged(ObservableObject.GetPropertyName(() => rm.ExpectedOriginal4ThisModified));
                }
                else if (e.PropertyName == ObservableObject.GetPropertyName(()
                    => rm.ExpectedModified4ThisOriginal_GumTreeId))
                {
                    if (rm.ExpectedModified4ThisOriginal_GumTreeId == null &&
                        rm.ExpectedModified4ThisOriginal != null)
                    {
                        //rm.ExpectedModified4ThisOriginal.GumTreeId = "-1";
                        rm.ExpectedModified4ThisOriginal.Id = "-1";
                        rm.ExpectedModified4ThisOriginal.Type = "";
                        rm.ExpectedModified4ThisOriginal.Hint = null;
                    }
                    else if (rm.ExpectedModified4ThisOriginal_GumTreeId != null)
                    {
                        var modified = this.Model.LoadedDisagreedDelta.FullAsts
                            .GumTreeModifieds[rm.ExpectedModified4ThisOriginal_GumTreeId];
                        rm.ExpectedModified4ThisOriginal ??= new Common.DBModel.ElementDescription
                        {
                            //GumTreeId = "-1",
                            Id = "-1",
                            Type = "",
                            Hint = null
                        };
                        //rm.ExpectedModified4ThisOriginal.GumTreeId = modified.GtID();
                        rm.ExpectedModified4ThisOriginal.Id = modified.RmId();
                        rm.ExpectedModified4ThisOriginal.Type = modified.Attribute("kind")?.Value ?? modified.Name.LocalName;
                        //rm.ExpectedModified4ThisOriginal.Hint = modified.Value;
                    }
                    rm.RaisePropertyChanged(ObservableObject.GetPropertyName(() => rm.ExpectedModified4ThisOriginal));
                }
                this.KnowingThat(rm);
            }
            this.ListDisagreedDeltasCommand?.RaiseCanExecuteChanged();
            this.LoadSelectedDisagreedDeltaCommand?.RaiseCanExecuteChanged();
            this.SubmitReviewCommand?.RaiseCanExecuteChanged();
            this.RefreshReview();
            this.RaisePropertyChanged(ObservableObject.GetPropertyName(() => this.Review));
        }

        private void KnowingThat(RateableMatch rating)
        {
            if (!rating.Reviewed) 
                return;

            if (rating.GoodMatch.Value)
            {
                this.Model.LoadedDisagreedDelta.DisagreedMatches.Where(dm => !dm.Reviewed).ForEach(other =>
                {
                    if (!other.ReviewedOriginal && other.DivergentMatch.DisagreedMatch.Original.Element.Id ==
                                                   rating.DivergentMatch.DisagreedMatch.Original.Element.Id)
                    {
                        other.GoodMatch ??= false; other.DeletedOriginal = false;
                        other.ExpectedModified4ThisOriginal_GumTreeId = rating.ExpectedModified4ThisOriginal_GumTreeId;
                    }

                    if (!other.ReviewedModified && other.DivergentMatch.DisagreedMatch.Modified.Element.Id ==
                                                   rating.DivergentMatch.DisagreedMatch.Modified.Element.Id)
                    {
                        other.GoodMatch ??= false; other.InsertedModified = false;
                        other.ExpectedOriginal4ThisModified_GumTreeId = rating.ExpectedOriginal4ThisModified_GumTreeId;
                    }
                });
            }
            else
            {
                if (rating.DeletedOriginal.Value)
                {
                    this.Model.LoadedDisagreedDelta.DisagreedMatches.Where(dm => !dm.ReviewedOriginal)
                                                                    .ForEach(other =>
                    {
                        if (other.DivergentMatch.DisagreedMatch.Original.Element.Id ==
                            rating.DivergentMatch.DisagreedMatch.Original.Element.Id)
                        {
                            other.GoodMatch ??= false; other.DeletedOriginal = true;
                        }
                    });
                }
                else
                {
                    this.Model.LoadedDisagreedDelta.DisagreedMatches.Where(dm => !dm.Reviewed).ForEach(other =>
                    {
                        if (other.DivergentMatch.DisagreedMatch.Original.Element.Id ==
                            rating.DivergentMatch.DisagreedMatch.Original.Element.Id &&
                            other.DivergentMatch.DisagreedMatch.Modified.Element.Id ==
                            rating.DivergentMatch.DisagreedMatch.Modified.Element.Id)
                        {
                            other.GoodMatch = true;
                        }
                        else if (!other.ReviewedOriginal &&
                                 other.DivergentMatch.DisagreedMatch.Original.Element.Id ==
                                 rating.DivergentMatch.DisagreedMatch.Original.Element.Id)
                        {
                            other.GoodMatch ??= false;
                            other.DeletedOriginal = false;
                            other.ExpectedModified4ThisOriginal_GumTreeId = rating.ExpectedModified4ThisOriginal_GumTreeId;
                        }
                    });
                }

                if (rating.InsertedModified.Value)
                {
                    this.Model.LoadedDisagreedDelta.DisagreedMatches.Where(dm => !dm.ReviewedModified).ForEach(other =>
                    {
                        if (other.DivergentMatch.DisagreedMatch.Modified.Element.Id ==
                            rating.DivergentMatch.DisagreedMatch.Modified.Element.Id)
                        {
                            other.GoodMatch ??= false;
                            other.InsertedModified = true;
                        }
                    });
                }
                else
                {
                    this.Model.LoadedDisagreedDelta.DisagreedMatches.Where(dm => !dm.Reviewed).ForEach(other =>
                    {
                        if (other.DivergentMatch.DisagreedMatch.Original.Element.Id ==
                            rating.DivergentMatch.DisagreedMatch.Original.Element.Id &&
                            other.DivergentMatch.DisagreedMatch.Modified.Element.Id ==
                            rating.DivergentMatch.DisagreedMatch.Modified.Element.Id)
                        {
                            other.GoodMatch = true;
                        }
                        else if (other.DivergentMatch.DisagreedMatch.Modified.Element.Id ==
                                 rating.DivergentMatch.DisagreedMatch.Modified.Element.Id)
                        {
                            other.GoodMatch ??= false; other.InsertedModified = false;
                            other.ExpectedOriginal4ThisModified_GumTreeId = rating.ExpectedOriginal4ThisModified_GumTreeId;
                        }
                    });
                }
            }
        }

        private void RefreshReview()
        {
            if (this.Model?.LoadedDisagreedDelta?.DisagreedMatches.Any() ?? false)
            {
                var dr = DetectionResult.Read(System.IO.File.ReadAllText(Settings.Default.RatedMatching), Encoding.Unicode);
                //var dr = (DetectionResult)this.Model.LoadedDisagreedDelta.Review.DetectionResult;
                foreach (var dm in this.Model.LoadedDisagreedDelta.DisagreedMatches/*.Where(rm => rm.Reviewed)*/)
                {
                    BetweenMatchInfo matchInfo = null;

                    switch (dm.DivergentMatch)
                    {
                        case LRMatchSymptom lr:
                            matchInfo = lr.Left;
                            break;
                        case RLMatchSymptom rl:
                            matchInfo = rl.Right;
                            break;
                        default:
                            throw new InvalidDataException();
                    }
                    var thisOriginal = new ElementVersion
                    {
                        Id = matchInfo.Original.Element.Id,
                        Label = matchInfo.Original.Element.Type,
                        Value = matchInfo.Original.Element.Hint
                    };
                    var thisModified = new ElementVersion
                    {
                        Id = matchInfo.Modified.Element.Id,
                        Label = matchInfo.Modified.Element.Type,
                        Value = matchInfo.Modified.Element.Hint
                    };

                    if (dm.GoodMatch.HasValue && dm.GoodMatch.Value)
                    {                        
                        dr.Matches.Add(new MatchDescriptor
                        {
                            Original = thisOriginal,
                            Modified = thisModified
                        });
                    }
                    else
                    {
                        if (dm.DeletedOriginal.HasValue && dm.DeletedOriginal.Value)
                        {
                            dr.Actions.Add(new Actions.DeleteOperationDescriptor
                            {
                                Element = thisOriginal
                            });
                        }
                        else if (dm.ExpectedModified4ThisOriginal != null &&
                                 dm.ExpectedModified4ThisOriginal.Id != "-1")
                        {
                            dr.Matches.Add(new MatchDescriptor
                            {
                                Original = thisOriginal,
                                Modified = new ElementVersion
                                {
                                    Id = dm.ExpectedModified4ThisOriginal.Id,
                                    Label = dm.ExpectedModified4ThisOriginal.Type,
                                    Value = dm.ExpectedModified4ThisOriginal.Hint
                                }
                            });
                        }

                        if (dm.InsertedModified.HasValue && dm.InsertedModified.Value)
                        {
                            dr.Actions.Add(new Actions.InsertOperationDescriptor
                            {
                                Element = thisModified
                            });
                        }
                        else if(dm.ExpectedOriginal4ThisModified != null &&
                                dm.ExpectedOriginal4ThisModified.Id != "-1")
                        {
                            dr.Matches.Add(new MatchDescriptor
                            {
                                Original = new ElementVersion
                                {
                                    Id = dm.ExpectedOriginal4ThisModified.Id,
                                    Label = dm.ExpectedOriginal4ThisModified.Type,
                                    Value = dm.ExpectedOriginal4ThisModified.Hint
                                },
                                Modified = thisModified
                            });
                        }
                    }
                }
                dr.Matches = dr.Matches.Distinct(new MatchDescriptorEqualityComparer()).ToList();
                dr.Actions = dr.Actions.Distinct(new ActionDescriptorEqualityComparer()).ToList();
                this.Model.LoadedDisagreedDelta.Review.DetectionResult = dr;
                //System.IO.File.WriteAllText(Settings.Default.RatedMatching, dr.WriteXmlColumn());
            }
        }
    }
}
