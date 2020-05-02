using System;
using Jawilliam.CDF.Approach;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Actions
{
    [TestClass]
    public class TestMatchDescriptorEqualityComparer
    {
        [TestMethod]
        public void MatchDescriptorEqualityComparer()
        {
            var md1 = new MatchDescriptor
            {
                Original = new ElementVersion 
                { 
                    GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd"
                },
                Modified = new ElementVersion
                {
                    GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1"
                }
            };

            var md2 = new MatchDescriptor
            {
                Original = new ElementVersion 
                { 
                    GlobalId = "aa2", Id = "bb2", Label = "cc2", Value = "dd2"
                },
                Modified = new ElementVersion
                {
                    GlobalId = "aa3", Id = "bb3", Label = "cc3", Value = "dd3"
                }
            };

            var md3 = new MatchDescriptor
            {
                Original = new ElementVersion 
                { 
                    GlobalId = "aa2", Id = "bb", Label = "cc2", Value = "dd2"
                },
                Modified = new ElementVersion
                {
                    GlobalId = "aa3", Id = "bb1", Label = "cc3", Value = "dd3"
                }
            };

            var equalityComparer = new MatchDescriptorEqualityComparer();
            Assert.IsFalse(equalityComparer.Equals(md1, md2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(md1), equalityComparer.GetHashCode(md2));
            Assert.IsTrue(equalityComparer.Equals(md1, md3));
            Assert.AreEqual(equalityComparer.GetHashCode(md1), equalityComparer.GetHashCode(md3));
        }
    }
}
