using GalaSoft.MvvmLight;
using Jawilliam.CDF.Labs.Common.DBModel;
using System;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Contains a rated or rateable divergent match.
    /// </summary>
    public class RateableMatch : ObservableObject
    {
        private bool? _goodMatch;
        private bool? _deletedOriginal;
        private string _expectedModified4ThisOriginal_GumTreeId;
        private Common.DBModel.ElementDescription _expectedModified4ThisOriginal;
        private bool? _insertedModified;
        private string _expectedOriginal4ThisModified_GumTreeId;
        private Common.DBModel.ElementDescription _expectedOriginal4ThisModified;

        /// <summary>
        /// Initializes the instance with a given match under review.
        /// </summary>
        /// <param name="divergentMatch">match under review</param>
        public RateableMatch(BetweenSymptom divergentMatch)
        {
            this.DivergentMatch = divergentMatch ?? throw new ArgumentNullException(nameof(divergentMatch));
        }

        /// <summary>
        /// Gets the match under review.
        /// </summary>
        public BetweenSymptom DivergentMatch { get; private set; }

        /// <summary>
        /// Whether or not the rated match is correct.
        /// </summary>
        public virtual bool? GoodMatch
        {
            get { return _goodMatch; }
            set {
                _goodMatch = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Reviewed));
                this.RaisePropertyChanged(nameof(ReviewedOriginal));
                this.RaisePropertyChanged(nameof(ReviewedModified));
            }
        }

        #region ExpectedModified4ThisOriginal

        /// <summary>
        /// Whether or not delete the original element.
        /// </summary>
        public virtual bool? DeletedOriginal
        {
            get { return _deletedOriginal; }
            set { 
                _deletedOriginal = value;
                if (value ?? false)
                    this.ExpectedModified4ThisOriginal_GumTreeId = default;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Reviewed));
                this.RaisePropertyChanged(nameof(ReviewedOriginal));
            }
        }

        /// <summary>
        /// Gets or sets the GumTree id of the modified element version matching to the current original element.
        /// </summary>
        public virtual string ExpectedModified4ThisOriginal_GumTreeId
        {
            get { return _expectedModified4ThisOriginal_GumTreeId; }
            set
            {
                _expectedModified4ThisOriginal_GumTreeId = string.IsNullOrWhiteSpace(value) ? null : value;
                //if (value == default)
                //    this.ExpectedModified4ThisOriginal = null;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Reviewed));
                this.RaisePropertyChanged(nameof(ReviewedOriginal));
            }
        }

        /// <summary>
        /// Gets or sets the modified element version matching to the current original element. 
        /// </summary>
        public virtual Jawilliam.CDF.Labs.Common.DBModel.ElementDescription ExpectedModified4ThisOriginal
        {
            get { return _expectedModified4ThisOriginal; }
            set {
                _expectedModified4ThisOriginal = value;
                this.RaisePropertyChanged();
                //this.RaisePropertyChanged(nameof(Reviewed));
                //this.RaisePropertyChanged(nameof(ReviewedOriginal));
            }
        }

        #endregion

        #region ExpectedOriginal4ThisModified

        /// <summary>
        /// Whether or not insert the referred modified element version.
        /// </summary>
        public virtual bool? InsertedModified
        {
            get { return _insertedModified; }
            set { 
                _insertedModified = value;
                if (value ?? false)
                    ExpectedOriginal4ThisModified_GumTreeId = default;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Reviewed));
                this.RaisePropertyChanged(nameof(ReviewedModified));
            }
        }

        /// <summary>
        /// Gets or sets the GumTree id of the original element version matching to the current modified element. 
        /// </summary>
        public virtual string ExpectedOriginal4ThisModified_GumTreeId
        {
            get { return _expectedOriginal4ThisModified_GumTreeId; }
            set
            {
                _expectedOriginal4ThisModified_GumTreeId = string.IsNullOrWhiteSpace(value) ? null : value;
                //if (value == default)
                //    this.ExpectedOriginal4ThisModified = null;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(Reviewed));
                this.RaisePropertyChanged(nameof(ReviewedModified));
            }
        }

        /// <summary>
        /// Gets or sets the original element version matching to the current modified element. 
        /// </summary>
        public virtual Jawilliam.CDF.Labs.Common.DBModel.ElementDescription ExpectedOriginal4ThisModified
        {
            get { return _expectedOriginal4ThisModified; }
            set
            {
                _expectedOriginal4ThisModified = value;
                this.RaisePropertyChanged();
                //this.RaisePropertyChanged(nameof(Reviewed));
                //this.RaisePropertyChanged(nameof(ReviewedModified));
            }
        }

        #endregion

        /// <summary>
        /// Whether or not current match is entirely reviewed.
        /// </summary>
        public virtual bool Reviewed
        {
            get => this.ReviewedOriginal && ReviewedModified;
        }

        /// <summary>
        /// Whether or not current original is reviewed.
        /// </summary>
        public virtual bool ReviewedOriginal
        {
            get => (this.GoodMatch.HasValue && this.GoodMatch.Value) || 
                   (this.DeletedOriginal.HasValue && (this.DeletedOriginal.Value ||
                   (!this.DeletedOriginal.Value &&
                    this.ExpectedModified4ThisOriginal_GumTreeId != null &&
                    this.ExpectedModified4ThisOriginal_GumTreeId != "-1")));
        }

        /// <summary>
        /// Whether or not current match is entirely reviewed.
        /// </summary>
        public virtual bool ReviewedModified
        {
            get => (this.GoodMatch.HasValue && this.GoodMatch.Value) ||
                   (this.InsertedModified.HasValue && (this.InsertedModified.Value ||
                   (!this.InsertedModified.Value &&
                    this.ExpectedOriginal4ThisModified_GumTreeId != null &&
                    this.ExpectedOriginal4ThisModified_GumTreeId != "-1")));
        }
    }
}
