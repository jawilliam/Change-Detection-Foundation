using GalaSoft.MvvmLight;
using Jawilliam.CDF.Labs.Common.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.VSIXProject
{
    public class SolutionReviewExplorerViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the approach options.
        /// </summary>
        public virtual List<KeyValuePair<string, ChangeDetectionApproaches>> Approaches
        {
            get
            {
                return new List<KeyValuePair<string, ChangeDetectionApproaches>>
                {
                    new KeyValuePair<string, ChangeDetectionApproaches>("asas", 
                        ChangeDetectionApproaches.ExpandedInverseNativeGTtreefiedRoslynMLWithBasicPruning)/*,
                    NativeGTtreefiedRoslynML = 10,
                    InverseNativeGTtreefiedRoslynML = 11*/
                };
            }
        }
    }
}
