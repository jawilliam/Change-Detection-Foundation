using Jawilliam.CDF.Approach;
using System.Collections.Generic;
using System.Xml.Linq;
using Jawilliam.CDF.CSharp.RoslynML;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Represents a XML-based AST revision pair to optimally access the elements. 
    /// </summary>
    public class XAstRevisionPair : RevisionPair<XElement>
    {
        /// <summary>
        /// Gets or sets the original elements indexed by their GumTree IDs.
        /// </summary>
        public virtual Dictionary<string, XElement> GumTreeOriginals { get; protected set; }

        /// <summary>
        /// Gets or sets the modified elements indexed by their GumTree IDs.
        /// </summary>
        public virtual Dictionary<string, XElement> GumTreeModifieds { get; protected set; }

        /// <summary>
        /// Gets or sets the original elements indexed by their Roslyn IDs.
        /// </summary>
        public virtual Dictionary<string, XElement> RoslynOriginals { get; protected set; }

        /// <summary>
        /// Gets or sets the modified elements indexed by their Roslyn IDs.
        /// </summary>
        public virtual Dictionary<string, XElement> RoslynModifieds { get; protected set; }

        /// <summary>
        /// Gets or sets the element original version.
        /// </summary>
        public override XElement Original 
        { 
            get => base.Original;
            set 
            { 
                base.Original = value;
                this.GumTreeOriginals = value?.ToGtDictionary();
                this.RoslynOriginals = value?.ToRmDictionary();
            }
        }

        /// <summary>
        /// Gets or sets the element modified version.
        /// </summary>
        public override XElement Modified
        { 
            get => base.Modified;
            set
            { 
                base.Modified = value;
                this.GumTreeModifieds = value?.ToGtDictionary();
                this.RoslynModifieds = value?.ToRmDictionary();
            }
        }
    }
}
