using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.DBModel
{
    public abstract partial class BetweenSymptom : Symptom
    {
    }

    public partial class LRMatchSymptom : BetweenSymptom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LRMatchSymptom()
        {
            this.Left = new BetweenMatchInfo();
            this.NullRight = new BetweenMatchInfo();
            this.OriginalAtRight = new BetweenMatchInfo();
            this.ModifiedAtRight = new BetweenMatchInfo();
        }


        public BetweenMatchInfo Left { get; set; }
        private BetweenMatchInfo NullRight { get; set; }
        public BetweenMatchInfo OriginalAtRight { get; set; }
        public BetweenMatchInfo ModifiedAtRight { get; set; }
    }

    public partial class RLMatchSymptom : BetweenSymptom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RLMatchSymptom()
        {
            this.Right = new BetweenMatchInfo();
            this.OriginalAtLeft = new BetweenMatchInfo();
            this.ModifiedAtLeft = new BetweenMatchInfo();
            this.NullLeft = new BetweenMatchInfo();
        }


        public BetweenMatchInfo Right { get; set; }
        public BetweenMatchInfo OriginalAtLeft { get; set; }
        public BetweenMatchInfo ModifiedAtLeft { get; set; }
        private BetweenMatchInfo NullLeft { get; set; }
    }
}
