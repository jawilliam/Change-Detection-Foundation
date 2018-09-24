using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Evaluation
{

    public enum RedundancyPattern : byte
    {
        DI   = 1,
        UI   = 2,
        DU   = 3,
        UU   = 4,
        DM   = 5,
        MI   = 6,
        MM   = 7,
        UM   = 8,
        MU   = 9,
        UMI  = 10,
        DUM  = 11,
        UMU  = 12,
        UUM  = 13,
        UMUM = 14,
        MUM  = 15,
        UMM  = 16

    }
}