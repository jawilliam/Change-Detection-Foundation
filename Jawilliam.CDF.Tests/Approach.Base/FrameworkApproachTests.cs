using System;
using System.Collections.Generic;
using System.Linq;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.Base
{
    [TestClass]
    public class FrameworkApproachTests
    {
        [TestMethod, ExpectedException(typeof(ApplicationException), "Unspecified args.")]
        public void FrameworkApproach_NoSettedArgs_ThrowsException()
        {
            IApproach<int, ElementTree> myApproach = new MyApproach();
            myApproach.Proceed(null);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException), "Could not load the revision pair.")]
        public void FrameworkApproach_ProblemsLoadingRevisionPair_ThrowsException()
        {
            IApproach<int, ElementTree> myApproach = new MyApproach();
            myApproach.Proceed(new LoadRevisionPairDelegate<ElementTree>(delegate (out ElementTree o, out ElementTree m)
            {
                o = new ElementTree();
                m = new ElementTree();
                return false;
            }));
        }

        [TestMethod]
        public void FrameworkApproach_WhenProceedWithoutSteps_DoNothing()
        {
            IApproach<int, ElementTree> myApproach = new MyApproach();
            ((MyApproach)myApproach).Choices.Add(new MyChoice { Name = "MyChoice" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndDetection { Name = "MyChoiceWithEndDetection" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndStep { Name = "MyChoiceWithEndStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginStep { Name = "MyChoiceWithBeginStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginDetection { Name = "MyChoiceWithBeginDetection" });

            myApproach.Proceed(new LoadRevisionPairDelegate<ElementTree>(delegate (out ElementTree o, out ElementTree m)
            {
                o = new ElementTree();
                m = new ElementTree();
                return true;
            }));

            Assert.AreEqual(((MyApproach)myApproach).Logs.Count, 2);
            Assert.AreEqual(((MyApproach)myApproach).Logs[0], $"MyChoiceWithBeginDetection: BeginDetection.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[1], $"MyChoiceWithEndDetection: EndDetection.");
        }

        [TestMethod]
        public void FrameworkApproach_WhenProceed_CallChoicesInThatOrder()
        {
            IApproach<int, ElementTree> myApproach = new MyApproach();
            ((MyApproach)myApproach).Choices.Add(new MyChoice { Name = "MyChoice" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndDetection { Name = "MyChoiceWithEndDetection" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndStep { Name = "MyChoiceWithEndStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginStep { Name = "MyChoiceWithBeginStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginDetection { Name = "MyChoiceWithBeginDetection" });
            ((MyApproach)myApproach).Steps.Add((long)MySteps.D);
            ((MyApproach)myApproach).Steps.Add((long)(MySteps.D | MySteps.B | MySteps.C));

            myApproach.Proceed(new LoadRevisionPairDelegate<ElementTree>(delegate (out ElementTree o, out ElementTree m)
            {
                o = new ElementTree();
                m = new ElementTree();
                return true;
            }));

            Assert.AreEqual(((MyApproach)myApproach).Logs.Count, 9);
            Assert.AreEqual(((MyApproach)myApproach).Logs[0], $"MyChoiceWithBeginDetection: BeginDetection.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[1], $"MyChoiceWithBeginStep: BeginStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[2], $"MyChoice: OnStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[3], $"MyChoiceWithEndDetection: OnStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[4], $"MyChoiceWithEndStep: OnStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[5], $"MyChoiceWithBeginStep: OnStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[6], $"MyChoiceWithBeginDetection: OnStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[7], $"MyChoiceWithEndStep: EndStep.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[8], $"MyChoiceWithEndDetection: EndDetection.");
        }

        public class MyApproach : Approach<int, ElementTree>
        {
            private IList<IChoice<int, ElementTree>> _choices = new List<IChoice<int, ElementTree>>();
            public override IList<IChoice<int, ElementTree>> Choices => _choices;

            private IList<long> _steps = new List<long>();
            public override IList<long> Steps => _steps;

            public IList<string> Logs = new List<string>();

            public override TService GetService<TService>()
            {
                throw new NotImplementedException();
            }
        }

        [Flags]
        enum MySteps : long { None = 0, A = 1, B = 2, C = 4, D = 8 }

        public class MyChoice : Choice<int, ElementTree>
        {
            public virtual string Name { get; set; }
            public override IList<long> SupportedSteps => new List<long> { (long)(MySteps.B | MySteps.C) };

            public override void CoreOnStep()
            {
                Assert.AreNotEqual(this.Approach.Step & (long)(MySteps.B | MySteps.C), 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: OnStep.");
            }
        }

        public class MyChoiceWithBeginDetection : MyChoice, IChoiceWithBeginDetection<int, ElementTree>
        {
            public void BeginDetection()
            {
                Assert.AreEqual(this.Approach.Step, 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: BeginDetection.");
            }
        }

        public class MyChoiceWithBeginStep : MyChoice, IChoiceWithBeginStep<int, ElementTree>
        {
            public void BeginStep()
            {
                if (this.SupportedSteps.Any(s => (this.Approach.Step & s) != 0))
                    this.CoreBeginStep();
            }

            /// <summary>
            /// Core implementation of <see cref="BeginStep"/>.
            /// </summary>
            protected virtual void CoreBeginStep()
            {
                Assert.AreNotEqual(this.Approach.Step & ((long)(MySteps.B | MySteps.C)), 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: BeginStep.");
            }
        }

        public class MyChoiceWithEndStep : MyChoice, IChoiceWithEndStep<int, ElementTree>
        {
            public void EndStep()
            {
                if (this.SupportedSteps.Any(s => (this.Approach.Step & s) != 0))
                    this.CoreEndStep();
            }

            /// <summary>
            /// Core implementation of <see cref="BeginStep"/>.
            /// </summary>
            protected virtual void CoreEndStep()
            {
                Assert.AreNotEqual(this.Approach.Step & ((long)(MySteps.B | MySteps.C)), 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: EndStep.");
            }
        }

        public class MyChoiceWithEndDetection : MyChoice, IChoiceWithEndDetection<int, ElementTree>
        {
            public void EndDetection()
            {
                Assert.AreEqual(this.Approach.Step, 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: EndDetection.");
            }
        }
    }
}
