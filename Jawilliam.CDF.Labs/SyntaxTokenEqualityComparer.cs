using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Jawilliam.CDF.Labs
{
    public class SyntaxTokenEqualityComparer : IEqualityComparer<SyntaxToken>
    {
        public virtual bool Equals(SyntaxToken b1, SyntaxToken b2)
        {
            return b1.RawKind == b2.RawKind && b1.ValueText == b2.ValueText;
        }

        public virtual int GetHashCode(SyntaxToken bx)
        {
            int hCode = bx.ValueText.GetHashCode() ^ bx.RawKind;
            return hCode.GetHashCode();
        }
    }
}
