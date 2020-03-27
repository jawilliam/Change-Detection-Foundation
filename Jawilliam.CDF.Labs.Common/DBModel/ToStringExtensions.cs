using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.Common.DBModel
{
    partial class BetweenPartInfo
    {
        public override string ToString()
        {
            return $"{this.Parent4IDU_Original4U} -- {this.Element4IDM_Modified4U}";
        }
    }

    //partial class BetweenSymptom
    //{
    //    public override string ToString()
    //    {
    //        return $"{this.Pattern}: {this.Left} vs. {this.Right}";
    //    }
    //}
}
