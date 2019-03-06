///*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
//  namespaces, code guidelines (naming and mode...)
  
//  Removing tests related with descriptions*/

//using System.Collections.ObjectModel;
//using Jawilliam.Data.Simetric;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Jawilliam.Data.Simetric.Tests {
//    [TestClass]
//    public class TokenisersUnitTests {
//        #region TokenizerQGram3 Tests

//        [TestMethod]
//        [TestCategory("TokenizerQGram3 Test")]
//        public void TokeniserQGram3TestData() {
//            Collection<string> myKnownResult = new Collection<string> {"CHR", "HRI", "RIS"};
//            //myKnownResult.TrimExcess();
//            Collection<string> myResult = _myTokenizerQGram3.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram3 test.");
//            }
//        }

//        [TestMethod]
//        [TestCategory("TokenizerQGram3 Test")]
//        public void TokeniserQGram3ExtendedTestData() {
//            Collection<string> myKnownResult = new Collection<string> {"??C", "?CH", "CHR", "HRI", "RIS", "IS#", "S##"};
//            Collection<string> myResult = _myTokenizerQGram3Extended.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram3Extended test.");
//            }
//        }
//        #endregion

//        #region TokenizerQGram2 Tests

//        [TestMethod]
//        [TestCategory("TokenizerQGram2 Test")]
//        public void TokeniserQGram2TestData() {
//            Collection<string> myKnownResult = new Collection<string> {"CH", "HR", "RI", "IS"};
//            //myKnownResult.TrimExcess();
//            Collection<string> myResult = _myTokenizerQGram2.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram2 test.");
//            }
//        }

//        [TestMethod]
//        [TestCategory("TokenizerQGram2 CCI Test")]
//        public void TokeniserQGram2TestWithCci1_Data() {
//            Collection<string> myKnownResult = new Collection<string> {"CH", "HR", "RI", "IS", "CR", "HI", "RS"};
//            //myKnownResult.TrimExcess();
//            _myTokenizerQGram2.CharacterCombinationIndex = 1;
//            Collection<string> myResult = _myTokenizerQGram2.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram2 test.");
//            }
//        }

//        [TestMethod]
//        [TestCategory("TokenizerQGram2 Test")]
//        public void TokeniserQGram2ExtendedTestData() {
//            Collection<string> myKnownResult = new Collection<string> {"?C", "CH", "HR", "RI", "IS", "S#"};
//            Collection<string> myResult = _myTokenizerQGram2Extended.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram2Extended test.");
//            }
//        }

//        [TestMethod]
//        [TestCategory("TokenizerQGram2 CCI Test")]
//        public void TokeniserQGram2ExtendedTestCc1_Data() {
//            Collection<string> myKnownResult = new Collection<string>
//            {
//                "?C",
//                "CH",
//                "HR",
//                "RI",
//                "IS",
//                "S#",
//                "?H",
//                "CR",
//                "HI",
//                "RS",
//                "I#"
//            };
//            _myTokenizerQGram2Extended.CharacterCombinationIndex = 1;
//            Collection<string> myResult = _myTokenizerQGram2Extended.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram2Extended test.");
//            }
//        }
//        #endregion

//        #region SGram tests

//        [TestMethod]
//        public void TokeniserSGram2ExtendedTestCc1_Data() {
//            Collection<string> myKnownResult = new Collection<string>
//            {
//                "?C",
//                "CH",
//                "HR",
//                "RI",
//                "IS",
//                "S#",
//                "?H",
//                "CR",
//                "HI",
//                "RS",
//                "I#"
//            };
//            Collection<string> myResult = _myTokenizerSGram2Extended.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram2Extended test.");
//            }
//        }

//        [TestMethod]
//        public void TokeniserSGram2TestWithCci1_Data() {
//            Collection<string> myKnownResult = new Collection<string> {"CH", "HR", "RI", "IS", "CR", "HI", "RS"};
//            Collection<string> myResult = _myTokenizerSGram2.Tokenize("CHRIS");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerQGram2 test.");
//            }
//        }
//        #endregion

//        #region White Space Tests

//        [TestMethod]
//        [TestCategory("TokenizerWhitespace Test")]
//        public void TokeniserWhitespaceTestData() {
//            Collection<string> myKnownResult = new Collection<string> {"CHRIS", "IS", "HERE"};
//            Collection<string> myResult = _myTokenizerWhitespace.Tokenize("CHRIS IS HERE");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerWhitespace test.");
//            }
//        }

//        [TestMethod]
//        [TestCategory("TokenizerWhitespace Test")]
//        public void TokeniserWhitespaceDelimiterTest() {
//            Collection<string> myKnownResult = new Collection<string> {"CHRIS", "IS", "", "HERE", "woo"};
//            Collection<string> myResult = _myTokenizerWhitespace.Tokenize("CHRIS\nIS\r HERE\twoo");
//            for (int i = 0; i < myKnownResult.Count; i++) {
//                Assert.AreEqual(myKnownResult[i], myResult[i], "Problem with TokenizerWhitespace test.");
//            }
//        }
//        #endregion

//        private TokenizerQGram3 _myTokenizerQGram3;
//        private TokenizerQGram3Extended _myTokenizerQGram3Extended;
//        private TokenizerQGram2 _myTokenizerQGram2;
//        private TokenizerSGram2 _myTokenizerSGram2;
//        private TokenizerQGram2Extended _myTokenizerQGram2Extended;
//        private TokenizerSGram2Extended _myTokenizerSGram2Extended;
//        private TokenizerWhitespace _myTokenizerWhitespace;

//        [TestInitialize]
//        public void SetUp() {
//            _myTokenizerQGram3 = new TokenizerQGram3();
//            _myTokenizerQGram3Extended = new TokenizerQGram3Extended();
//            _myTokenizerQGram2 = new TokenizerQGram2();
//            _myTokenizerSGram2 = new TokenizerSGram2();
//            _myTokenizerQGram2Extended = new TokenizerQGram2Extended();
//            _myTokenizerSGram2Extended = new TokenizerSGram2Extended();
//            _myTokenizerWhitespace = new TokenizerWhitespace();
//        }
//    }
//}