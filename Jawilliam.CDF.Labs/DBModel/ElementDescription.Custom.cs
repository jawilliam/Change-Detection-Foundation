using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.DBModel
{
    partial class ElementDescription
    {
        public override string ToString()
        {
            return $"{this.Id}:{this.Type}";
        }
    }
}
