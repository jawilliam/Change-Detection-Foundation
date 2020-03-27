using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.Common.DBModel
{
    partial class RedundancySymptom
    {
        public override string ToString()
        {
            return $"{this.Pattern} missed matching {this.MissedOriginal.Type}({this.MissedOriginal.Id}) with {this.MissedModified.Type}({this.MissedModified.Id}) " +
                $"spuriously matching {this.SpuriousOriginal.Type}({this.SpuriousOriginal.Id}) with {this.SpuriousModified.Type}({this.SpuriousModified.Id}) and " +
                $"spuriously matching {this.AndSpuriousOriginal.Type}({this.AndSpuriousOriginal.Id}) with {this.AndSpuriousModified.Type}({this.AndSpuriousModified.Id}) ";
        }
    }
}
