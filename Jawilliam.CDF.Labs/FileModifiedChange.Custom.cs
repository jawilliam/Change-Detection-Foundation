using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    partial class FileModifiedChange
    {
        /// <summary>
        /// Gets or sets the annotations as an XML document.
        /// </summary>
        public virtual XFileModifiedChangeAnnotations XAnnotations
        {
            get { return XFileModifiedChangeAnnotations.Read(this.Annotations, Encoding.Unicode); }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                this.Annotations = value.WriteXmlColumn();
            }
        }
    }
}
