using System;
using System.Collections.Generic;
using System.Linq;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Annotations.Impl;
using Jawilliam.CDF.Approach.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.Base
{
    [TestClass]
    public class FrameworkApproachTests
    {
        [TestMethod, ExpectedException(typeof(ApplicationException), "Unspecified args.")]
        public void FrameworkApproach_NoSettedArgs_ThrowsException()
        {
            IApproach<int> myApproach = new MyApproach();
            myApproach.Proceed(null);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException), "Could not load the revision pair.")]
        public void FrameworkApproach_ProblemsLoadingRevisionPair_ThrowsException()
        {
            IApproach<int> myApproach = new MyApproach();

            myApproach.Proceed(new LoadRevisionPairDelegate<int>(delegate (out int o, out int m)
            {
                o = 0;
                m = 0;
                return false;
            }));
        }

        [TestMethod]
        public void FrameworkApproach_WhenProceedWithoutSteps_DoNothing()
        {
            IApproach<int> myApproach = new MyApproach();
            ((MyApproach)myApproach).Choices.Add(new MyChoice(myApproach) { Name = "MyChoice" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndDetection(myApproach) { Name = "MyChoiceWithEndDetection" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndStep(myApproach) { Name = "MyChoiceWithEndStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginStep(myApproach) { Name = "MyChoiceWithBeginStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginDetection(myApproach) { Name = "MyChoiceWithBeginDetection" });

            myApproach.Proceed(new LoadRevisionPairDelegate<int>(delegate (out int o, out int m)
            {
                o = 0;
                m = 0;
                return true;
            }));

            Assert.AreEqual(((MyApproach)myApproach).Logs.Count, 2);
            Assert.AreEqual(((MyApproach)myApproach).Logs[0], $"MyChoiceWithBeginDetection: BeginDetection.");
            Assert.AreEqual(((MyApproach)myApproach).Logs[1], $"MyChoiceWithEndDetection: EndDetection.");
        }

        [TestMethod]
        public void FrameworkApproach_WhenProceed_CallChoicesInThatOrder()
        {
            IApproach<int> myApproach = new MyApproach();
            ((MyApproach)myApproach).Choices.Add(new MyChoice(myApproach) { Name = "MyChoice" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndDetection(myApproach) { Name = "MyChoiceWithEndDetection" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithEndStep(myApproach) { Name = "MyChoiceWithEndStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginStep(myApproach) { Name = "MyChoiceWithBeginStep" });
            ((MyApproach)myApproach).Choices.Add(new MyChoiceWithBeginDetection(myApproach) { Name = "MyChoiceWithBeginDetection" });
            ((MyApproach)myApproach).Steps.Add((long)MySteps.D);
            ((MyApproach)myApproach).Steps.Add((long)(MySteps.D | MySteps.B | MySteps.C));

            myApproach.Proceed(new LoadRevisionPairDelegate<int>(delegate (out int o, out int m)
            {
                o = 0;
                m = 0;
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

        public class MyApproach : FladApproach<int, Annotation<int>>
        {
            private IList<IChoice> _choices = new List<IChoice>();
            public override IList<IChoice> Choices => _choices;

            private IList<long> _steps = new List<long>();
            public override IList<long> Steps => _steps;

            public IList<string> Logs = new List<string>();
        }

        [Flags]
        enum MySteps : long { None = 0, A = 1, B = 2, C = 4, D = 8 }

        public class MyChoice : Choice<int>
        {
            public MyChoice(IApproach<int> approach) : base(approach) { }

            public virtual string Name { get; set; }
            protected override IList<long> SupportedSteps => new List<long> { (long)(MySteps.B | MySteps.C) };

            protected override void CoreOnStep()
            {
                Assert.AreNotEqual(this.Approach.Step & (long)(MySteps.B | MySteps.C), 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: OnStep.");
            }
        }

        public class MyChoiceWithBeginDetection : MyChoice, IBeginDetection
        {
            public MyChoiceWithBeginDetection(IApproach<int> approach) : base(approach) { }

            public void BeginDetection()
            {
                Assert.AreEqual(this.Approach.Step, 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: BeginDetection.");
            }
        }

        public class MyChoiceWithBeginStep : MyChoice, IBeginStep
        {
            public MyChoiceWithBeginStep(IApproach<int> approach) : base(approach) { }

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

        public class MyChoiceWithEndStep : MyChoice, IEndStep
        {
            public MyChoiceWithEndStep(IApproach<int> approach) : base(approach) { }

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

        public class MyChoiceWithEndDetection : MyChoice, IEndDetection
        {
            public MyChoiceWithEndDetection(IApproach<int> approach) : base(approach) { }

            public void EndDetection()
            {
                Assert.AreEqual(this.Approach.Step, 0);
                ((MyApproach)this.Approach).Logs.Add($"{Name}: EndDetection.");
            }
        }
    }
}
