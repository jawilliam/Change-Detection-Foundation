using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.Labs
{
    public class SyntaxTokenEqualityComparer : IEqualityComparer<SyntaxToken>
    {
        public bool Equals(SyntaxToken b1, SyntaxToken b2)
        {
            if (b2 == null && b1 == null)
                return true;
            else if (b1 == null | b2 == null)
                return false;
            else if (b1.ValueText == b2.ValueText && b1.RawKind == b2.RawKind)
                return true;
            else
                return false;
        }

        public int GetHashCode(SyntaxToken bx)
        {
            int hCode = bx.ValueText.GetHashCode() ^ bx.RawKind;
            return hCode.GetHashCode();
        }
    }
}
