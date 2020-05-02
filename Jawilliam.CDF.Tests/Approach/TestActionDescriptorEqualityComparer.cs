using System;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Actions
{
    [TestClass]
    public class TestActionDescriptorEqualityComparer
    {
        [TestMethod]
        public void MatchDescriptorEqualityComparer_Insert()
        {
            var equalityComparer = new ActionDescriptorEqualityComparer();

            var insert1 = new InsertOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            var insert2 = new InsertOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 1
            };            
            Assert.IsFalse(equalityComparer.Equals(insert1, insert2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(insert1), equalityComparer.GetHashCode(insert2));


            insert2 = new InsertOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb2", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            Assert.IsFalse(equalityComparer.Equals(insert1, insert2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(insert1), equalityComparer.GetHashCode(insert2));

            insert2 = new InsertOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb2", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            Assert.IsFalse(equalityComparer.Equals(insert1, insert2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(insert1), equalityComparer.GetHashCode(insert2));

            insert2 = new InsertOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            Assert.IsTrue(equalityComparer.Equals(insert1, insert2));
            Assert.AreEqual(equalityComparer.GetHashCode(insert1), equalityComparer.GetHashCode(insert2));
        }

        [TestMethod]
        public void MatchDescriptorEqualityComparer_Move()
        {
            var equalityComparer = new ActionDescriptorEqualityComparer();

            var move1 = new MoveOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            var move2 = new MoveOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 1
            };
            Assert.IsFalse(equalityComparer.Equals(move1, move2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(move1), equalityComparer.GetHashCode(move2));


            move2 = new MoveOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb2", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            Assert.IsFalse(equalityComparer.Equals(move1, move2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(move1), equalityComparer.GetHashCode(move2));

            move2 = new MoveOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb2", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            Assert.IsFalse(equalityComparer.Equals(move1, move2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(move1), equalityComparer.GetHashCode(move2));

            move2 = new MoveOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
                Parent = new ElementVersion { GlobalId = "aa1", Id = "bb1", Label = "cc1", Value = "dd1" },
                Position = 0
            };
            Assert.IsTrue(equalityComparer.Equals(move1, move2));
            Assert.AreEqual(equalityComparer.GetHashCode(move1), equalityComparer.GetHashCode(move2));
        }

        [TestMethod]
        public void MatchDescriptorEqualityComparer_Delete()
        {
            var equalityComparer = new ActionDescriptorEqualityComparer();

            var delete1 = new DeleteOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
            };
            var delete2 = new DeleteOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb2", Label = "cc", Value = "dd" },
            };
            Assert.IsFalse(equalityComparer.Equals(delete1, delete2));
            Assert.AreNotEqual(equalityComparer.GetHashCode(delete1), equalityComparer.GetHashCode(delete2));

            delete2 = new DeleteOperationDescriptor
            {
                Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
            };
            Assert.IsTrue(equalityComparer.Equals(delete1, delete2));
            Assert.AreEqual(equalityComparer.GetHashCode(delete1), equalityComparer.GetHashCode(delete2));
        }



        //[TestMethod]
        //public void MatchDescriptorEqualityComparer_Delete()
        //{
        //    var equalityComparer = new ActionDescriptorEqualityComparer();

        //    var delete1 = new DeleteOperationDescriptor
        //    {
        //        Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
        //    };
        //    var delete2 = new DeleteOperationDescriptor
        //    {
        //        Element = new ElementVersion { GlobalId = "aa", Id = "bb2", Label = "cc", Value = "dd" },
        //    };
        //    Assert.IsFalse(equalityComparer.Equals(delete1, delete2));
        //    Assert.AreNotEqual(equalityComparer.GetHashCode(delete1), equalityComparer.GetHashCode(delete2));

        //    delete2 = new DeleteOperationDescriptor
        //    {
        //        Element = new ElementVersion { GlobalId = "aa", Id = "bb", Label = "cc", Value = "dd" },
        //    };
        //    Assert.IsTrue(equalityComparer.Equals(delete1, delete2));
        //    Assert.AreEqual(equalityComparer.GetHashCode(delete1), equalityComparer.GetHashCode(delete2));
        //}
    }
}
