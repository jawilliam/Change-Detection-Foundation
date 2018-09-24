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
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1di" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2di" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3di", Label = "l3di", Value = "v3di" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4di", Label = "l4di", Value = "v4di" } }
                }
            };
 
            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3di"},
                        Modified = new ElementDescriptor{Id = "4di"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DI);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3di");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3di");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3di");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4di");
            Assert.AreEqual(symptoms[0].MissedModified.Label, "l4di");
            Assert.AreEqual(symptoms[0].MissedModified.Value, "v4di");
            Assert.AreEqual(symptoms[0].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].SpuriousModified, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified, null);
        }

        [TestMethod]
        public void FindUI_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1ui" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2ui" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3ui", Label = "l3ui", Value = "v3ui" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4ui", Label = "l4ui", Value = "v4ui" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1ui"},
                        Modified = new ElementDescriptor{Id = "1uix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3ui"},
                        Modified = new ElementDescriptor{Id = "3uix"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3ui"},
                        Modified = new ElementDescriptor{Id = "4ui"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UI);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3ui");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3ui");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3ui");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4ui");
            Assert.AreEqual(symptoms[0].MissedModified.Label, "l4ui");
            Assert.AreEqual(symptoms[0].MissedModified.Value, "v4ui");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3ui");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3ui");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3ui");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3uix");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified, null);
        }

        [TestMethod]
        public void FindUMI_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2umi" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi", Label = "l3umi", Value = "v3umi" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi", Label = "l3umi", Value = "v3umi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4umi", Label = "l4umi", Value = "v4umi" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umi"},
                        Modified = new ElementDescriptor{Id = "1umix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umi"},
                        Modified = new ElementDescriptor{Id = "3umix"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umi"},
                        Modified = new ElementDescriptor{Id = "4umi"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMI);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3umi");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3umi");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3umi");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4umi");
            Assert.AreEqual(symptoms[0].MissedModified.Label, "l4umi");
            Assert.AreEqual(symptoms[0].MissedModified.Value, "v4umi");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3umi");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3umi");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3umi");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3umix");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified, null);
        }

        [TestMethod]
        public void FindDU_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1du" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2du", Label = "l3du", Value = "v3du" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3du", Label = "l3du", Value = "v3du" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4dux", Label = "l4dux", Value = "v4dux" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2du"},
                        Modified = new ElementDescriptor{Id = "2dux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4dux"},
                        Modified = new ElementDescriptor{Id = "4du"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3du"},
                        Modified = new ElementDescriptor{Id = "4du"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DU);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3du");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3du");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3du");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4du");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].SpuriousModified, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4dux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4dux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4dux");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4du");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindDUM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum", Label = "l2dum", Value = "v2dum" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dum", Label = "l3dum", Value = "v3dum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dumx", Label = "l4dumx", Value = "v4dumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4dumx", Label = "l4dumx", Value = "v4dumx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2dum"},
                        Modified = new ElementDescriptor{Id = "2dumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4dumx"},
                        Modified = new ElementDescriptor{Id = "4dum"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3dum"},
                        Modified = new ElementDescriptor{Id = "4dum"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DUM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3dum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3dum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3dum");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4dum");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].SpuriousModified, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4dumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4dumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4dumx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4dum");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindUU_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uu", Label = "l3uu", Value = "v3uu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uux", Label = "l4uux", Value = "v4uux" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1uu"},
                        Modified = new ElementDescriptor{Id = "1uux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2uu"},
                        Modified = new ElementDescriptor{Id = "2uux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uu"},
                        Modified = new ElementDescriptor{Id = "3uux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4uux"},
                        Modified = new ElementDescriptor{Id = "4uu"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uu"},
                        Modified = new ElementDescriptor{Id = "4uu"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UU);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3uu");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3uu");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3uu");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4uu");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3uu");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3uu");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3uu");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3uux");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4uux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4uux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4uux");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4uu");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindUMU_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2umu" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu", Label = "l3umu", Value = "v3umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu", Label = "l3umu", Value = "v3umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umux", Label = "l4umux", Value = "v4umux" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umu"},
                        Modified = new ElementDescriptor{Id = "1umux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2umu"},
                        Modified = new ElementDescriptor{Id = "2umux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umu"},
                        Modified = new ElementDescriptor{Id = "3umux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4umux"},
                        Modified = new ElementDescriptor{Id = "4umu"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umu"},
                        Modified = new ElementDescriptor{Id = "4umu"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMU);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3umu");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3umu");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3umu");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4umu");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3umu");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3umu");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3umu");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3umux");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4umux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4umux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4umux");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4umu");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindUUM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4uumx", Label = "l4uumx", Value = "v4uumx"} },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uum", Label = "l3uum", Value = "v3uum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uumx", Label = "l4uumx", Value = "v4uumx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1uum"},
                        Modified = new ElementDescriptor{Id = "1uumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2uum"},
                        Modified = new ElementDescriptor{Id = "2uumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uum"},
                        Modified = new ElementDescriptor{Id = "3uumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4uumx"},
                        Modified = new ElementDescriptor{Id = "4uum"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uum"},
                        Modified = new ElementDescriptor{Id = "4uum"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UUM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3uum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3uum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3uum");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4uum");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3uum");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3uum");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3uum");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3uumx");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4uumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4uumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4uumx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4uum");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindUMUM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2umum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum", Label = "l3umum", Value = "v3umum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum", Label = "l3umum", Value = "v3umum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umumx", Label = "l4umumx", Value = "v4umumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umumx", Label = "l4umumx", Value = "v4umumx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umum"},
                        Modified = new ElementDescriptor{Id = "1umumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2umum"},
                        Modified = new ElementDescriptor{Id = "2umumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umum"},
                        Modified = new ElementDescriptor{Id = "3umumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4umumx"},
                        Modified = new ElementDescriptor{Id = "4umum"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umum"},
                        Modified = new ElementDescriptor{Id = "4umum"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMUM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3umum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3umum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3umum");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4umum");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3umum");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3umum");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3umum");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3umumx");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4umumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4umumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4umumx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4umum");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindDM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dm" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dm", Label = "l3dm", Value = "v3dm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dmx", Label = "l4dmx", Value = "v4dmx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2dm"},
                        Modified = new ElementDescriptor{Id = "2dmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4dmx"},
                        Modified = new ElementDescriptor{Id = "4dm"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3dm"},
                        Modified = new ElementDescriptor{Id = "4dm"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3dm");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3dm");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3dm");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4dm");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].SpuriousModified, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4dmx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4dmx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4dmx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4dm");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindMI_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2mi" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mi", Label = "l3mi", Value = "v3mi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4mi", Label = "l4mi", Value = "v4mi" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mi"},
                        Modified = new ElementDescriptor{Id = "1mix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mi"},
                        Modified = new ElementDescriptor{Id = "3mix"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mi"},
                        Modified = new ElementDescriptor{Id = "4mi"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MI);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3mi");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3mi");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3mi");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4mi");
            Assert.AreEqual(symptoms[0].MissedModified.Label, "l4mi");
            Assert.AreEqual(symptoms[0].MissedModified.Value, "v4mi");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3mi");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3mi");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3mi");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3mix");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified, null);
        }

        [TestMethod]
        public void FindMM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mm", Label = "l3mm", Value = "v3mm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mmx", Label = "l4mmx", Value = "v4mmx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mm"},
                        Modified = new ElementDescriptor{Id = "1mmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2mm"},
                        Modified = new ElementDescriptor{Id = "2mmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mm"},
                        Modified = new ElementDescriptor{Id = "3mmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4mmx"},
                        Modified = new ElementDescriptor{Id = "4mm"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mm"},
                        Modified = new ElementDescriptor{Id = "4mm"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3mm");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3mm");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3mm");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4mm");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3mm");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3mm");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3mm");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3mmx");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4mmx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4mmx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4mmx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4mm");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindUMM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm", Label = "l3umm", Value = "v3umm" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm", Label = "l3umm", Value = "v3umm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4ummx", Label = "l4ummx", Value = "v4ummx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umm"},
                        Modified = new ElementDescriptor{Id = "1ummx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2umm"},
                        Modified = new ElementDescriptor{Id = "2ummx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umm"},
                        Modified = new ElementDescriptor{Id = "3ummx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4ummx"},
                        Modified = new ElementDescriptor{Id = "4umm"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umm"},
                        Modified = new ElementDescriptor{Id = "4umm"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UMM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3umm");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3umm");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3umm");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4umm");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3umm");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3umm");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3umm");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3ummx");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4ummx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4ummx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4ummx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4umm");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindMUM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mum", Label = "l3mum", Value = "v3mum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mumx", Label = "l4mumx", Value = "v4mumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mumx", Label = "l4mumx", Value = "v4mumx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mum"},
                        Modified = new ElementDescriptor{Id = "1mumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2mum"},
                        Modified = new ElementDescriptor{Id = "2mumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mum"},
                        Modified = new ElementDescriptor{Id = "3mumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4mumx"},
                        Modified = new ElementDescriptor{Id = "4mum"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mum"},
                        Modified = new ElementDescriptor{Id = "4mum"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MUM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3mum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3mum");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3mum");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4mum");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3mum");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3mum");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3mum");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3mumx");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4mumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4mumx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4mumx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4mum");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindUM_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1um" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2um" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3um", Label = "l3um", Value = "v3um" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umx", Label = "l4umx", Value = "v4umx" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1um"},
                        Modified = new ElementDescriptor{Id = "1umx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2um"},
                        Modified = new ElementDescriptor{Id = "2umx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3um"},
                        Modified = new ElementDescriptor{Id = "3umx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4umx"},
                        Modified = new ElementDescriptor{Id = "4um"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3um"},
                        Modified = new ElementDescriptor{Id = "4um"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.UM);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3um");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3um");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3um");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4um");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3um");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3um");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3um");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3umx");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4umx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4umx");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4umx");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4um");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void FindMU_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mu" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mu", Label = "l3mu", Value = "v3mu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mux", Label = "l4mux", Value = "v4mux" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mu"},
                        Modified = new ElementDescriptor{Id = "1mux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2mu"},
                        Modified = new ElementDescriptor{Id = "2mux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mu"},
                        Modified = new ElementDescriptor{Id = "3mux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4mux"},
                        Modified = new ElementDescriptor{Id = "4mu"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
                MatchingSet = new RevisionDescriptor[]
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mu"},
                        Modified = new ElementDescriptor{Id = "4mu"}
                    }
                }
            };

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();
            Assert.AreEqual(symptoms.Count(), 1);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.MU);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3mu");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3mu");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3mu");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4mu");
            Assert.AreEqual(symptoms[0].MissedModified.Label, null);
            Assert.AreEqual(symptoms[0].MissedModified.Value, null);
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Id, "3mu");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Label, "l3mu");
            Assert.AreEqual(symptoms[0].SpuriousOriginal.Value, "v3mu");
            Assert.AreEqual(symptoms[0].SpuriousModified.Id, "3mux");
            Assert.AreEqual(symptoms[0].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Id, "4mux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Label, "l4mux");
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal.Value, "v4mux");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Id, "4mu");
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified.Value, null);
        }

        [TestMethod]
        public void Find_All_OK()
        {
            var delta = new DetectionResult
            {
                Actions = new List<ActionDescriptor>
                {
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1di" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2di" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3di", Label = "l3di", Value = "v3di" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4di", Label = "l4di", Value = "v4di" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1ui" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2ui" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3ui", Label = "l3ui", Value = "v3ui" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4ui", Label = "l4ui", Value = "v4ui" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2umi" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi", Label = "l3umi", Value = "v3umi" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umi", Label = "l3umi", Value = "v3umi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4umi", Label = "l4umi", Value = "v4umi" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1du" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2du", Label = "l3du", Value = "v3du" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3du", Label = "l3du", Value = "v3du" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4dux", Label = "l4dux", Value = "v4dux" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2dum", Label = "l2dum", Value = "v2dum" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dum", Label = "l3dum", Value = "v3dum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dumx", Label = "l4dumx", Value = "v4dumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4dumx", Label = "l4dumx", Value = "v4dumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uu", Label = "l3uu", Value = "v3uu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uux", Label = "l4uux", Value = "v4uux" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2umu" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu", Label = "l3umu", Value = "v3umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umu", Label = "l3umu", Value = "v3umu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umux", Label = "l4umux", Value = "v4umux" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1uum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2uum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4uumx", Label = "l4uumx", Value = "v4uumx"} },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3uum", Label = "l3uum", Value = "v3uum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4uumx", Label = "l4uumx", Value = "v4uumx" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2umum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum", Label = "l3umum", Value = "v3umum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umum", Label = "l3umum", Value = "v3umum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umumx", Label = "l4umumx", Value = "v4umumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4umumx", Label = "l4umumx", Value = "v4umumx" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "1dm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2dm" } },
                    new DeleteOperationDescriptor { Element = new ElementDescriptor{ Id = "3dm", Label = "l3dm", Value = "v3dm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4dmx", Label = "l4dmx", Value = "v4dmx" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "2mi" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mi", Label = "l3mi", Value = "v3mi" } },
                    new InsertOperationDescriptor { Element = new ElementDescriptor{ Id = "4mi", Label = "l4mi", Value = "v4mi" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mm", Label = "l3mm", Value = "v3mm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mmx", Label = "l4mmx", Value = "v4mmx" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1umm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2umm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm", Label = "l3umm", Value = "v3umm" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3umm", Label = "l3umm", Value = "v3umm" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4ummx", Label = "l4ummx", Value = "v4ummx" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mum", Label = "l3mum", Value = "v3mum" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4mumx", Label = "l4mumx", Value = "v4mumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mumx", Label = "l4mumx", Value = "v4mumx" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "1um" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "2um" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "3um", Label = "l3um", Value = "v3um" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "4umx", Label = "l4umx", Value = "v4umx" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "1mu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "2mu" } },
                    new MoveOperationDescriptor { Element = new ElementDescriptor{ Id = "3mu", Label = "l3mu", Value = "v3mu" } },
                    new UpdateOperationDescriptor { Element = new ElementDescriptor{ Id = "4mux", Label = "l4mux", Value = "v4mux" } }
                },
                Matches = new List<RevisionDescriptor>
                {
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1ui"},
                        Modified = new ElementDescriptor{Id = "1uix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3ui"},
                        Modified = new ElementDescriptor{Id = "3uix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umi"},
                        Modified = new ElementDescriptor{Id = "1umix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umi"},
                        Modified = new ElementDescriptor{Id = "3umix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2du"},
                        Modified = new ElementDescriptor{Id = "2dux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4dux"},
                        Modified = new ElementDescriptor{Id = "4du"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2dum"},
                        Modified = new ElementDescriptor{Id = "2dumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4dumx"},
                        Modified = new ElementDescriptor{Id = "4dum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1uu"},
                        Modified = new ElementDescriptor{Id = "1uux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2uu"},
                        Modified = new ElementDescriptor{Id = "2uux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uu"},
                        Modified = new ElementDescriptor{Id = "3uux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4uux"},
                        Modified = new ElementDescriptor{Id = "4uu"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umu"},
                        Modified = new ElementDescriptor{Id = "1umux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2umu"},
                        Modified = new ElementDescriptor{Id = "2umux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umu"},
                        Modified = new ElementDescriptor{Id = "3umux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4umux"},
                        Modified = new ElementDescriptor{Id = "4umu"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1uum"},
                        Modified = new ElementDescriptor{Id = "1uumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2uum"},
                        Modified = new ElementDescriptor{Id = "2uumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3uum"},
                        Modified = new ElementDescriptor{Id = "3uumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4uumx"},
                        Modified = new ElementDescriptor{Id = "4uum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umum"},
                        Modified = new ElementDescriptor{Id = "1umumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2umum"},
                        Modified = new ElementDescriptor{Id = "2umumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umum"},
                        Modified = new ElementDescriptor{Id = "3umumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4umumx"},
                        Modified = new ElementDescriptor{Id = "4umum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2dm"},
                        Modified = new ElementDescriptor{Id = "2dmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4dmx"},
                        Modified = new ElementDescriptor{Id = "4dm"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mi"},
                        Modified = new ElementDescriptor{Id = "1mix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mi"},
                        Modified = new ElementDescriptor{Id = "3mix"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mm"},
                        Modified = new ElementDescriptor{Id = "1mmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2mm"},
                        Modified = new ElementDescriptor{Id = "2mmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mm"},
                        Modified = new ElementDescriptor{Id = "3mmx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4mmx"},
                        Modified = new ElementDescriptor{Id = "4mm"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1umm"},
                        Modified = new ElementDescriptor{Id = "1ummx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2umm"},
                        Modified = new ElementDescriptor{Id = "2ummx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3umm"},
                        Modified = new ElementDescriptor{Id = "3ummx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4ummx"},
                        Modified = new ElementDescriptor{Id = "4umm"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mum"},
                        Modified = new ElementDescriptor{Id = "1mumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2mum"},
                        Modified = new ElementDescriptor{Id = "2mumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mum"},
                        Modified = new ElementDescriptor{Id = "3mumx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4mumx"},
                        Modified = new ElementDescriptor{Id = "4mum"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1um"},
                        Modified = new ElementDescriptor{Id = "1umx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2um"},
                        Modified = new ElementDescriptor{Id = "2umx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3um"},
                        Modified = new ElementDescriptor{Id = "3umx"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4umx"},
                        Modified = new ElementDescriptor{Id = "4um"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "1mu"},
                        Modified = new ElementDescriptor{Id = "1mux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "2mu"},
                        Modified = new ElementDescriptor{Id = "2mux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "3mu"},
                        Modified = new ElementDescriptor{Id = "3mux"}
                    },
                    new RevisionDescriptor
                    {
                        Original = new ElementDescriptor{Id = "4mux"},
                        Modified = new ElementDescriptor{Id = "4mu"}
                    }
                }
            };

            RedundancyFinder finder = new MatchingSetRedundancyFinder
            {
                Delta = delta,
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

            (RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();

            Assert.AreEqual(symptoms.Count(), 16);
            Assert.AreEqual(symptoms[0].pattern, RedundancyPattern.DI);
            Assert.AreEqual(symptoms[0].MissedOriginal.Id, "3di");
            Assert.AreEqual(symptoms[0].MissedOriginal.Label, "l3di");
            Assert.AreEqual(symptoms[0].MissedOriginal.Value, "v3di");
            Assert.AreEqual(symptoms[0].MissedModified.Id, "4di");
            Assert.AreEqual(symptoms[0].MissedModified.Label, "l4di");
            Assert.AreEqual(symptoms[0].MissedModified.Value, "v4di");
            Assert.AreEqual(symptoms[0].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].SpuriousModified, null);
            Assert.AreEqual(symptoms[0].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[0].AndSpuriousModified, null);

            Assert.AreEqual(symptoms[1].pattern, RedundancyPattern.UI);
            Assert.AreEqual(symptoms[1].MissedOriginal.Id, "3ui");
            Assert.AreEqual(symptoms[1].MissedOriginal.Label, "l3ui");
            Assert.AreEqual(symptoms[1].MissedOriginal.Value, "v3ui");
            Assert.AreEqual(symptoms[1].MissedModified.Id, "4ui");
            Assert.AreEqual(symptoms[1].MissedModified.Label, "l4ui");
            Assert.AreEqual(symptoms[1].MissedModified.Value, "v4ui");
            Assert.AreEqual(symptoms[1].SpuriousOriginal.Id, "3ui");
            Assert.AreEqual(symptoms[1].SpuriousOriginal.Label, "l3ui");
            Assert.AreEqual(symptoms[1].SpuriousOriginal.Value, "v3ui");
            Assert.AreEqual(symptoms[1].SpuriousModified.Id, "3uix");
            Assert.AreEqual(symptoms[1].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[1].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[1].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[1].AndSpuriousModified, null);

            Assert.AreEqual(symptoms[2].pattern, RedundancyPattern.UMI);
            Assert.AreEqual(symptoms[2].MissedOriginal.Id, "3umi");
            Assert.AreEqual(symptoms[2].MissedOriginal.Label, "l3umi");
            Assert.AreEqual(symptoms[2].MissedOriginal.Value, "v3umi");
            Assert.AreEqual(symptoms[2].MissedModified.Id, "4umi");
            Assert.AreEqual(symptoms[2].MissedModified.Label, "l4umi");
            Assert.AreEqual(symptoms[2].MissedModified.Value, "v4umi");
            Assert.AreEqual(symptoms[2].SpuriousOriginal.Id, "3umi");
            Assert.AreEqual(symptoms[2].SpuriousOriginal.Label, "l3umi");
            Assert.AreEqual(symptoms[2].SpuriousOriginal.Value, "v3umi");
            Assert.AreEqual(symptoms[2].SpuriousModified.Id, "3umix");
            Assert.AreEqual(symptoms[2].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[2].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[2].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[2].AndSpuriousModified, null);

            Assert.AreEqual(symptoms[3].pattern, RedundancyPattern.DU);
            Assert.AreEqual(symptoms[3].MissedOriginal.Id, "3du");
            Assert.AreEqual(symptoms[3].MissedOriginal.Label, "l3du");
            Assert.AreEqual(symptoms[3].MissedOriginal.Value, "v3du");
            Assert.AreEqual(symptoms[3].MissedModified.Id, "4du");
            Assert.AreEqual(symptoms[3].MissedModified.Label, null);
            Assert.AreEqual(symptoms[3].MissedModified.Value, null);
            Assert.AreEqual(symptoms[3].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[3].SpuriousModified, null);
            Assert.AreEqual(symptoms[3].AndSpuriousOriginal.Id, "4dux");
            Assert.AreEqual(symptoms[3].AndSpuriousOriginal.Label, "l4dux");
            Assert.AreEqual(symptoms[3].AndSpuriousOriginal.Value, "v4dux");
            Assert.AreEqual(symptoms[3].AndSpuriousModified.Id, "4du");
            Assert.AreEqual(symptoms[3].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[3].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[4].pattern, RedundancyPattern.DUM);
            Assert.AreEqual(symptoms[4].MissedOriginal.Id, "3dum");
            Assert.AreEqual(symptoms[4].MissedOriginal.Label, "l3dum");
            Assert.AreEqual(symptoms[4].MissedOriginal.Value, "v3dum");
            Assert.AreEqual(symptoms[4].MissedModified.Id, "4dum");
            Assert.AreEqual(symptoms[4].MissedModified.Label, null);
            Assert.AreEqual(symptoms[4].MissedModified.Value, null);
            Assert.AreEqual(symptoms[4].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[4].SpuriousModified, null);
            Assert.AreEqual(symptoms[4].AndSpuriousOriginal.Id, "4dumx");
            Assert.AreEqual(symptoms[4].AndSpuriousOriginal.Label, "l4dumx");
            Assert.AreEqual(symptoms[4].AndSpuriousOriginal.Value, "v4dumx");
            Assert.AreEqual(symptoms[4].AndSpuriousModified.Id, "4dum");
            Assert.AreEqual(symptoms[4].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[4].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[5].pattern, RedundancyPattern.UU);
            Assert.AreEqual(symptoms[5].MissedOriginal.Id, "3uu");
            Assert.AreEqual(symptoms[5].MissedOriginal.Label, "l3uu");
            Assert.AreEqual(symptoms[5].MissedOriginal.Value, "v3uu");
            Assert.AreEqual(symptoms[5].MissedModified.Id, "4uu");
            Assert.AreEqual(symptoms[5].MissedModified.Label, null);
            Assert.AreEqual(symptoms[5].MissedModified.Value, null);
            Assert.AreEqual(symptoms[5].SpuriousOriginal.Id, "3uu");
            Assert.AreEqual(symptoms[5].SpuriousOriginal.Label, "l3uu");
            Assert.AreEqual(symptoms[5].SpuriousOriginal.Value, "v3uu");
            Assert.AreEqual(symptoms[5].SpuriousModified.Id, "3uux");
            Assert.AreEqual(symptoms[5].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[5].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[5].AndSpuriousOriginal.Id, "4uux");
            Assert.AreEqual(symptoms[5].AndSpuriousOriginal.Label, "l4uux");
            Assert.AreEqual(symptoms[5].AndSpuriousOriginal.Value, "v4uux");
            Assert.AreEqual(symptoms[5].AndSpuriousModified.Id, "4uu");
            Assert.AreEqual(symptoms[5].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[5].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[6].pattern, RedundancyPattern.UMU);
            Assert.AreEqual(symptoms[6].MissedOriginal.Id, "3umu");
            Assert.AreEqual(symptoms[6].MissedOriginal.Label, "l3umu");
            Assert.AreEqual(symptoms[6].MissedOriginal.Value, "v3umu");
            Assert.AreEqual(symptoms[6].MissedModified.Id, "4umu");
            Assert.AreEqual(symptoms[6].MissedModified.Label, null);
            Assert.AreEqual(symptoms[6].MissedModified.Value, null);
            Assert.AreEqual(symptoms[6].SpuriousOriginal.Id, "3umu");
            Assert.AreEqual(symptoms[6].SpuriousOriginal.Label, "l3umu");
            Assert.AreEqual(symptoms[6].SpuriousOriginal.Value, "v3umu");
            Assert.AreEqual(symptoms[6].SpuriousModified.Id, "3umux");
            Assert.AreEqual(symptoms[6].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[6].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[6].AndSpuriousOriginal.Id, "4umux");
            Assert.AreEqual(symptoms[6].AndSpuriousOriginal.Label, "l4umux");
            Assert.AreEqual(symptoms[6].AndSpuriousOriginal.Value, "v4umux");
            Assert.AreEqual(symptoms[6].AndSpuriousModified.Id, "4umu");
            Assert.AreEqual(symptoms[6].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[6].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[7].pattern, RedundancyPattern.UUM);
            Assert.AreEqual(symptoms[7].MissedOriginal.Id, "3uum");
            Assert.AreEqual(symptoms[7].MissedOriginal.Label, "l3uum");
            Assert.AreEqual(symptoms[7].MissedOriginal.Value, "v3uum");
            Assert.AreEqual(symptoms[7].MissedModified.Id, "4uum");
            Assert.AreEqual(symptoms[7].MissedModified.Label, null);
            Assert.AreEqual(symptoms[7].MissedModified.Value, null);
            Assert.AreEqual(symptoms[7].SpuriousOriginal.Id, "3uum");
            Assert.AreEqual(symptoms[7].SpuriousOriginal.Label, "l3uum");
            Assert.AreEqual(symptoms[7].SpuriousOriginal.Value, "v3uum");
            Assert.AreEqual(symptoms[7].SpuriousModified.Id, "3uumx");
            Assert.AreEqual(symptoms[7].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[7].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[7].AndSpuriousOriginal.Id, "4uumx");
            Assert.AreEqual(symptoms[7].AndSpuriousOriginal.Label, "l4uumx");
            Assert.AreEqual(symptoms[7].AndSpuriousOriginal.Value, "v4uumx");
            Assert.AreEqual(symptoms[7].AndSpuriousModified.Id, "4uum");
            Assert.AreEqual(symptoms[7].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[7].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[8].pattern, RedundancyPattern.UMUM);
            Assert.AreEqual(symptoms[8].MissedOriginal.Id, "3umum");
            Assert.AreEqual(symptoms[8].MissedOriginal.Label, "l3umum");
            Assert.AreEqual(symptoms[8].MissedOriginal.Value, "v3umum");
            Assert.AreEqual(symptoms[8].MissedModified.Id, "4umum");
            Assert.AreEqual(symptoms[8].MissedModified.Label, null);
            Assert.AreEqual(symptoms[8].MissedModified.Value, null);
            Assert.AreEqual(symptoms[8].SpuriousOriginal.Id, "3umum");
            Assert.AreEqual(symptoms[8].SpuriousOriginal.Label, "l3umum");
            Assert.AreEqual(symptoms[8].SpuriousOriginal.Value, "v3umum");
            Assert.AreEqual(symptoms[8].SpuriousModified.Id, "3umumx");
            Assert.AreEqual(symptoms[8].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[8].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[8].AndSpuriousOriginal.Id, "4umumx");
            Assert.AreEqual(symptoms[8].AndSpuriousOriginal.Label, "l4umumx");
            Assert.AreEqual(symptoms[8].AndSpuriousOriginal.Value, "v4umumx");
            Assert.AreEqual(symptoms[8].AndSpuriousModified.Id, "4umum");
            Assert.AreEqual(symptoms[8].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[8].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[9].pattern, RedundancyPattern.DM);
            Assert.AreEqual(symptoms[9].MissedOriginal.Id, "3dm");
            Assert.AreEqual(symptoms[9].MissedOriginal.Label, "l3dm");
            Assert.AreEqual(symptoms[9].MissedOriginal.Value, "v3dm");
            Assert.AreEqual(symptoms[9].MissedModified.Id, "4dm");
            Assert.AreEqual(symptoms[9].MissedModified.Label, null);
            Assert.AreEqual(symptoms[9].MissedModified.Value, null);
            Assert.AreEqual(symptoms[9].SpuriousOriginal, null);
            Assert.AreEqual(symptoms[9].SpuriousModified, null);
            Assert.AreEqual(symptoms[9].AndSpuriousOriginal.Id, "4dmx");
            Assert.AreEqual(symptoms[9].AndSpuriousOriginal.Label, "l4dmx");
            Assert.AreEqual(symptoms[9].AndSpuriousOriginal.Value, "v4dmx");
            Assert.AreEqual(symptoms[9].AndSpuriousModified.Id, "4dm");
            Assert.AreEqual(symptoms[9].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[9].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[10].pattern, RedundancyPattern.MI);
            Assert.AreEqual(symptoms[10].MissedOriginal.Id, "3mi");
            Assert.AreEqual(symptoms[10].MissedOriginal.Label, "l3mi");
            Assert.AreEqual(symptoms[10].MissedOriginal.Value, "v3mi");
            Assert.AreEqual(symptoms[10].MissedModified.Id, "4mi");
            Assert.AreEqual(symptoms[10].MissedModified.Label, "l4mi");
            Assert.AreEqual(symptoms[10].MissedModified.Value, "v4mi");
            Assert.AreEqual(symptoms[10].SpuriousOriginal.Id, "3mi");
            Assert.AreEqual(symptoms[10].SpuriousOriginal.Label, "l3mi");
            Assert.AreEqual(symptoms[10].SpuriousOriginal.Value, "v3mi");
            Assert.AreEqual(symptoms[10].SpuriousModified.Id, "3mix");
            Assert.AreEqual(symptoms[10].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[10].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[10].AndSpuriousOriginal, null);
            Assert.AreEqual(symptoms[10].AndSpuriousModified, null);

            Assert.AreEqual(symptoms[11].pattern, RedundancyPattern.MM);
            Assert.AreEqual(symptoms[11].MissedOriginal.Id, "3mm");
            Assert.AreEqual(symptoms[11].MissedOriginal.Label, "l3mm");
            Assert.AreEqual(symptoms[11].MissedOriginal.Value, "v3mm");
            Assert.AreEqual(symptoms[11].MissedModified.Id, "4mm");
            Assert.AreEqual(symptoms[11].MissedModified.Label, null);
            Assert.AreEqual(symptoms[11].MissedModified.Value, null);
            Assert.AreEqual(symptoms[11].SpuriousOriginal.Id, "3mm");
            Assert.AreEqual(symptoms[11].SpuriousOriginal.Label, "l3mm");
            Assert.AreEqual(symptoms[11].SpuriousOriginal.Value, "v3mm");
            Assert.AreEqual(symptoms[11].SpuriousModified.Id, "3mmx");
            Assert.AreEqual(symptoms[11].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[11].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[11].AndSpuriousOriginal.Id, "4mmx");
            Assert.AreEqual(symptoms[11].AndSpuriousOriginal.Label, "l4mmx");
            Assert.AreEqual(symptoms[11].AndSpuriousOriginal.Value, "v4mmx");
            Assert.AreEqual(symptoms[11].AndSpuriousModified.Id, "4mm");
            Assert.AreEqual(symptoms[11].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[11].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[12].pattern, RedundancyPattern.UMM);
            Assert.AreEqual(symptoms[12].MissedOriginal.Id, "3umm");
            Assert.AreEqual(symptoms[12].MissedOriginal.Label, "l3umm");
            Assert.AreEqual(symptoms[12].MissedOriginal.Value, "v3umm");
            Assert.AreEqual(symptoms[12].MissedModified.Id, "4umm");
            Assert.AreEqual(symptoms[12].MissedModified.Label, null);
            Assert.AreEqual(symptoms[12].MissedModified.Value, null);
            Assert.AreEqual(symptoms[12].SpuriousOriginal.Id, "3umm");
            Assert.AreEqual(symptoms[12].SpuriousOriginal.Label, "l3umm");
            Assert.AreEqual(symptoms[12].SpuriousOriginal.Value, "v3umm");
            Assert.AreEqual(symptoms[12].SpuriousModified.Id, "3ummx");
            Assert.AreEqual(symptoms[12].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[12].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[12].AndSpuriousOriginal.Id, "4ummx");
            Assert.AreEqual(symptoms[12].AndSpuriousOriginal.Label, "l4ummx");
            Assert.AreEqual(symptoms[12].AndSpuriousOriginal.Value, "v4ummx");
            Assert.AreEqual(symptoms[12].AndSpuriousModified.Id, "4umm");
            Assert.AreEqual(symptoms[12].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[12].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[13].pattern, RedundancyPattern.MUM);
            Assert.AreEqual(symptoms[13].MissedOriginal.Id, "3mum");
            Assert.AreEqual(symptoms[13].MissedOriginal.Label, "l3mum");
            Assert.AreEqual(symptoms[13].MissedOriginal.Value, "v3mum");
            Assert.AreEqual(symptoms[13].MissedModified.Id, "4mum");
            Assert.AreEqual(symptoms[13].MissedModified.Label, null);
            Assert.AreEqual(symptoms[13].MissedModified.Value, null);
            Assert.AreEqual(symptoms[13].SpuriousOriginal.Id, "3mum");
            Assert.AreEqual(symptoms[13].SpuriousOriginal.Label, "l3mum");
            Assert.AreEqual(symptoms[13].SpuriousOriginal.Value, "v3mum");
            Assert.AreEqual(symptoms[13].SpuriousModified.Id, "3mumx");
            Assert.AreEqual(symptoms[13].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[13].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[13].AndSpuriousOriginal.Id, "4mumx");
            Assert.AreEqual(symptoms[13].AndSpuriousOriginal.Label, "l4mumx");
            Assert.AreEqual(symptoms[13].AndSpuriousOriginal.Value, "v4mumx");
            Assert.AreEqual(symptoms[13].AndSpuriousModified.Id, "4mum");
            Assert.AreEqual(symptoms[13].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[13].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[14].pattern, RedundancyPattern.UM);
            Assert.AreEqual(symptoms[14].MissedOriginal.Id, "3um");
            Assert.AreEqual(symptoms[14].MissedOriginal.Label, "l3um");
            Assert.AreEqual(symptoms[14].MissedOriginal.Value, "v3um");
            Assert.AreEqual(symptoms[14].MissedModified.Id, "4um");
            Assert.AreEqual(symptoms[14].MissedModified.Label, null);
            Assert.AreEqual(symptoms[14].MissedModified.Value, null);
            Assert.AreEqual(symptoms[14].SpuriousOriginal.Id, "3um");
            Assert.AreEqual(symptoms[14].SpuriousOriginal.Label, "l3um");
            Assert.AreEqual(symptoms[14].SpuriousOriginal.Value, "v3um");
            Assert.AreEqual(symptoms[14].SpuriousModified.Id, "3umx");
            Assert.AreEqual(symptoms[14].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[14].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[14].AndSpuriousOriginal.Id, "4umx");
            Assert.AreEqual(symptoms[14].AndSpuriousOriginal.Label, "l4umx");
            Assert.AreEqual(symptoms[14].AndSpuriousOriginal.Value, "v4umx");
            Assert.AreEqual(symptoms[14].AndSpuriousModified.Id, "4um");
            Assert.AreEqual(symptoms[14].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[14].AndSpuriousModified.Value, null);

            Assert.AreEqual(symptoms[15].pattern, RedundancyPattern.MU);
            Assert.AreEqual(symptoms[15].MissedOriginal.Id, "3mu");
            Assert.AreEqual(symptoms[15].MissedOriginal.Label, "l3mu");
            Assert.AreEqual(symptoms[15].MissedOriginal.Value, "v3mu");
            Assert.AreEqual(symptoms[15].MissedModified.Id, "4mu");
            Assert.AreEqual(symptoms[15].MissedModified.Label, null);
            Assert.AreEqual(symptoms[15].MissedModified.Value, null);
            Assert.AreEqual(symptoms[15].SpuriousOriginal.Id, "3mu");
            Assert.AreEqual(symptoms[15].SpuriousOriginal.Label, "l3mu");
            Assert.AreEqual(symptoms[15].SpuriousOriginal.Value, "v3mu");
            Assert.AreEqual(symptoms[15].SpuriousModified.Id, "3mux");
            Assert.AreEqual(symptoms[15].SpuriousModified.Label, null);
            Assert.AreEqual(symptoms[15].SpuriousModified.Value, null);
            Assert.AreEqual(symptoms[15].AndSpuriousOriginal.Id, "4mux");
            Assert.AreEqual(symptoms[15].AndSpuriousOriginal.Label, "l4mux");
            Assert.AreEqual(symptoms[15].AndSpuriousOriginal.Value, "v4mux");
            Assert.AreEqual(symptoms[15].AndSpuriousModified.Id, "4mu");
            Assert.AreEqual(symptoms[15].AndSpuriousModified.Label, null);
            Assert.AreEqual(symptoms[15].AndSpuriousModified.Value, null);
        }
    }
}
