using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Evaluation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Evaluation
{
    [TestClass]
    public class RedundancyFinderTests
    {
        [TestMethod]
        public void FindDI_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1di" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2di" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3di" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4di" } }
            };
 
            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3di"},
                        Modified = new ElementDescriptor{Id = "4di"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3di");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4di");
        }

        [TestMethod]
        public void FindUI_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1ui" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2ui" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3ui" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4ui" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3ui"},
                        Modified = new ElementDescriptor{Id = "4ui"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3ui");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4ui");
        }

        [TestMethod]
        public void FindUMI_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2umi" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4umi" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umi"},
                        Modified = new ElementDescriptor{Id = "4umi"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umi");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umi");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4umi");
        }

        [TestMethod]
        public void FindDU_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1du" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2du" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3du" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4du" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3du"},
                        Modified = new ElementDescriptor{Id = "4du"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3du");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4du");
        }

        [TestMethod]
        public void FindDUM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4dum" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3dum"},
                        Modified = new ElementDescriptor{Id = "4dum"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3dum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4dum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4dum");
        }

        [TestMethod]
        public void FindUU_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uu" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uu"},
                        Modified = new ElementDescriptor{Id = "4uu"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3uu");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4uu");
        }

        [TestMethod]
        public void FindUMU_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2umu" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umu" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umu"},
                        Modified = new ElementDescriptor{Id = "4umu"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umu");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umu");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4umu");
        }

        [TestMethod]
        public void FindUUM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uum" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uum"},
                        Modified = new ElementDescriptor{Id = "4uum"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3uum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4uum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4uum");
        }

        [TestMethod]
        public void FindUMUM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2muum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umum" } },
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umum"},
                        Modified = new ElementDescriptor{Id = "4umum"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4umum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4umum");
        }

        [TestMethod]
        public void FindDM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dm" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dm" } },
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3dm"},
                        Modified = new ElementDescriptor{Id = "4dm"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3dm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4dm");
        }

        [TestMethod]
        public void FindMI_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2mi" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4mi" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mi"},
                        Modified = new ElementDescriptor{Id = "4mi"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mi");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4mi");
        }

        [TestMethod]
        public void FindMM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mm" } },
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mm"},
                        Modified = new ElementDescriptor{Id = "4mm"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4mm");
        }

        [TestMethod]
        public void FindUMM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umm" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umm"},
                        Modified = new ElementDescriptor{Id = "4umm"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4umm");
        }

        [TestMethod]
        public void FindMUM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mum" } },
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mum"},
                        Modified = new ElementDescriptor{Id = "4mum"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4mum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4mum");
        }

        [TestMethod]
        public void FindUM_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1um" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2um" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3um" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4um" } }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3um"},
                        Modified = new ElementDescriptor{Id = "4um"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3um");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4um");
        }

        [TestMethod]
        public void FindMU_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mu" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mu" } },
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mu"},
                        Modified = new ElementDescriptor{Id = "4mu"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mu");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4mu");
        }

        [TestMethod]
        public void Find_All_OK()
        {
            var delta = new ActionDescriptor[]
            {
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1di" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2di" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3di" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4di" } }
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1ui" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2ui" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3ui" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4ui" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2umi" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4umi" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1du" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2du" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3du" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4du" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4dum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uu" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2umu" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umu" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2muum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umum" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dm" } },
                new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2mi" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mi" } },
                new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4mi" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umm" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mum" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mum" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1um" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2um" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3um" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4um" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mu" } },
                new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mu" } },
                new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mu" } },
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3di"},
                        Modified = new ElementDescriptor{Id = "4di"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3ui"},
                        Modified = new ElementDescriptor{Id = "4ui"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umi"},
                        Modified = new ElementDescriptor{Id = "4umi"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3du"},
                        Modified = new ElementDescriptor{Id = "4du"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3dum"},
                        Modified = new ElementDescriptor{Id = "4dum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uu"},
                        Modified = new ElementDescriptor{Id = "4uu"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umu"},
                        Modified = new ElementDescriptor{Id = "4umu"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uum"},
                        Modified = new ElementDescriptor{Id = "4uum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umum"},
                        Modified = new ElementDescriptor{Id = "4umum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3dm"},
                        Modified = new ElementDescriptor{Id = "4dm"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mi"},
                        Modified = new ElementDescriptor{Id = "4mi"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mm"},
                        Modified = new ElementDescriptor{Id = "4mm"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umm"},
                        Modified = new ElementDescriptor{Id = "4umm"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mum"},
                        Modified = new ElementDescriptor{Id = "4mum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3um"},
                        Modified = new ElementDescriptor{Id = "4um"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mu"},
                        Modified = new ElementDescriptor{Id = "4mu"}
                    }
                }
            };

            (RedundancyPattern pattern, ActionDescriptor original, ActionDescriptor andOriginal, ActionDescriptor modified, ActionDescriptor andModified)[] symptoms = finder.Find(delta).ToArray();

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3di");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4di");

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3ui");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4ui");

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umi");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umi");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4umi");

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3du");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4du");

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3dum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4dum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4dum");

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3uu");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4uu");

            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umu");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umu");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4umu");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3uum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4uum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4uum");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4umum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4umum");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(DeleteOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((DeleteOperationDescriptor)symptoms[0].original).Element.Id, "3dm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4dm");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MI);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(InsertOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mi");
            Assert.AreEqual(((InsertOperationDescriptor)symptoms[0].modified).Element.Id, "4mi");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4mm");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNotNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andOriginal, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3umm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andOriginal).Element.Id, "3umm");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4umm");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MUM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNotNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].andModified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mum");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4mum");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].andModified).Element.Id, "4mum");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UM);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(UpdateOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(MoveOperationDescriptor));
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].original).Element.Id, "3um");
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].modified).Element.Id, "4um");

            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MU);
            Assert.IsNotNull(symptoms[0].original);
            Assert.IsNull(symptoms[0].andOriginal);
            Assert.IsNotNull(symptoms[0].modified);
            Assert.IsNull(symptoms[0].andModified);
            Assert.IsInstanceOfType(symptoms[0].original, typeof(MoveOperationDescriptor));
            Assert.IsInstanceOfType(symptoms[0].modified, typeof(UpdateOperationDescriptor));
            Assert.AreEqual(((MoveOperationDescriptor)symptoms[0].original).Element.Id, "3mu");
            Assert.AreEqual(((UpdateOperationDescriptor)symptoms[0].modified).Element.Id, "4mu");
        }
    }
}
