using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Unifies Roslyn info and GumTree to identify quicker the current element in different contexts.
    /// </summary>
    public class ElementDescription : Jawilliam.CDF.Labs.Common.DBModel.ElementDescription, INotifyPropertyChanged
    {
        private string _gumTreeId;

        /// <summary>
        /// Gets or sets the wrapped description.
        /// </summary>
        public virtual Jawilliam.CDF.Labs.Common.DBModel.ElementDescription Source { get; set; }

        /// <summary>
        /// Gets or sets the RoslynML Id.
        /// </summary>
        public override string Id 
        { 
            get => this.Source.Id;
            set
            {
                this.Source.Id = value;
                this.NotifyPropertyChanged();
            }
        }

        public override string Hint { get => this.Source.Hint; set => this.Source.Hint = value; }
        public override string Type { get => this.Source.Type; set => this.Source.Type = value; }

        /// <summary>
        /// Gets or sets the GumTree ID.
        /// </summary>
        public virtual string GumTreeId
        {
            get { return _gumTreeId; }
            set 
            {
                _gumTreeId = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Notifies clients that a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
