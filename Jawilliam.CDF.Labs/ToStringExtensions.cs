using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    partial class BetweenPartInfo
    {
        public override string ToString()
        {
            return $"{this.OriginalOrParent} -- {this.ModifiedOrElement}";
        }
    }

    partial class BetweenSymptom
    {
        public override string ToString()
        {
            return $"{this.Pattern}: {this.Left} vs. {this.Right}";
        }
    }
}
