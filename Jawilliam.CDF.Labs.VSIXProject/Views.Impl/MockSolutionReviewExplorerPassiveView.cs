using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.VSIXProject.Views.Impl
{
    public class MockSolutionReviewExplorerPassiveView : ISolutionReviewExplorerPassiveView
    {
        /// <summary>
        /// Requests that the given object must be shown in the properties window.
        /// </summary>
        /// <param name="source">object to show in the properties windows.</param>
        public virtual void ShowProperties(object source)
        {
            throw new System.NotImplementedException();
        }
    }
}
