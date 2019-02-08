using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Returns the original and modified versions to compare. 
    /// </summary>
    /// <typeparam name="T">Type of the elements contained in the original and modified versions.</typeparam>
    /// <param name="original"></param>
    /// <param name="modified"></param>
    /// <returns></returns>
    public delegate bool GetRevisionPairDelegate<T>(out T original, out T modified);
}
