using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.DBModel
{
    partial class ElementContext
    {
        public override string ToString()
        {
            return this.Element.Hint != null
                ? $"{this.Element.Id}:{this.Element.Type}({this.Element.Hint})"
                : $"{this.Element.Id}:{this.Element.Type}";
        }
    }
}
