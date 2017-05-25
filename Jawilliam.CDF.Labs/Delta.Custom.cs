using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    partial class Delta
    {
        /// <summary>
        /// Gets or sets the annotations as an XML document.
        /// </summary>
        public virtual XDeltaAnnotations XAnnotations
        {
            get { return XDeltaAnnotations.Read(this.Annotations, Encoding.Unicode); }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                this.Annotations = value.WriteXmlColumn();
            }
        }
    }
}
