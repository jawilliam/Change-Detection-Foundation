using System;
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.CSharp
{
    [TestClass]
    public class CSharpFladTests
    {
        [TestMethod]
        public void CSharpFlad_InitAnnotations_OK()
        {
            string originalSourceCode = @"namespace @Namespace{ public class @Class { private bool  _a; } }";
            string modifiedSourceCode = @"namespace @Namespace{ public class @Class { private System.Boolean  _a; } }";

            var flad = new CSharpFlad();
            var args = new CDF.Approach.LoadRevisionPairDelegate<Microsoft.CodeAnalysis.SyntaxNode>(delegate (out SyntaxNode o, out SyntaxNode m)
            {
                var pair = CSharpFlad.LoadRevisionPair(originalSourceCode, modifiedSourceCode);
                o = pair.Original;
                m = pair.Modified;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            var b = new byte[] { 90, 250, 194, 254, 171, 10, 143, 66, 130, 9, 163, 44, 6, 171, 253, 181  };
            int r = (b[3] & 0xFF | (b[2] & 0xFF) << 8 | (b[1] & 0xFF) << 16 | (b[0] & 0xFF) << 24);
            var s = (b[3] & 0xFF | (b[2] & 0xFF) << 8 | (b[1] & 0xFF) << 16 | (b[0] & 0xFF) << 24);
        }

        [TestMethod]
        public void CSharpFlad_InitAnnotations_OK2()
        {
            string originalSourceCode = @"namespace @Namespace
                                          {
                                              public class @Class
                                              {
                                                  string unchanged;
                                                  string deleted;
                                                  string updated = ""old"";
                                                  string moved;
                                              }
                                          }";
            string modifiedSourceCode = @"namespace @Namespace
                                          {
                                              public class @Class
                                              {
                                                  string unchanged;
                                                  string moved;
                                                  string updated = ""new"";
                                                  string inserted;
                                              }
                                          }";

            var flad = new CSharpFlad();
            var args = new CDF.Approach.LoadRevisionPairDelegate<SyntaxNode>(delegate (out SyntaxNode o, out SyntaxNode m)
            {
                var pair = CSharpFlad.LoadRevisionPair(originalSourceCode, modifiedSourceCode);
                o = pair.Original;
                m = pair.Modified;
                return true;
            });

            var changes = flad.GetChanges(args).Translate();
            var b = new byte[] { 90, 250, 194, 254, 171, 10, 143, 66, 130, 9, 163, 44, 6, 171, 253, 181 };
            int r = (b[3] & 0xFF | (b[2] & 0xFF) << 8 | (b[1] & 0xFF) << 16 | (b[0] & 0xFF) << 24);
            var s = (b[3] & 0xFF | (b[2] & 0xFF) << 8 | (b[1] & 0xFF) << 16 | (b[0] & 0xFF) << 24);
        }
    }
}
