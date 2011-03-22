using System;
using NSpec.Core;
using NSubstitute;
using NUnit.Framework;

namespace NSpec.Specs.Core
{
    public class ExampleSpec : Spec
    {
        Example example;
        IExpectation failingExpectation;
        IExpectation passingExpectation;
        IExpectation pendingExpectation;
        IExampleReporter exampleReporter;

        [SetUp]
        public void setup()
        {
            example = new Example();

            failingExpectation = CreateSubstituteExpectation(e => e.IsFail.Returns(true));
            passingExpectation = CreateSubstituteExpectation(e => e.IsPass.Returns(true));
            pendingExpectation = CreateSubstituteExpectation(e => e.IsPending.Returns(true));

            exampleReporter = Substitute.For<IExampleReporter>();
        }

        [Test]
        public void should_pass_when_all_expectations_pass()
        {
            example.AddExpectation(passingExpectation);

            specify(() => example.IsPass);
        }

        [Test]
        public void should_fail_when_any_expectations_fail()
        {
            example.AddExpectation(passingExpectation);
            example.AddExpectation(pendingExpectation);
            example.AddExpectation(failingExpectation);

            specify(() => example.IsFail);
        }

        [Test]
        public void should_be_pending_when_any_expectations_are_pending_and_no_failing_expectations()
        {
            example.AddExpectation(passingExpectation);
            example.AddExpectation(pendingExpectation);

            specify(() => example.IsPending);
        }

        [Test]
        public void should_run_all_expectations_when_running_example()
        {
            example.AddExpectation(passingExpectation);
            example.AddExpectation(failingExpectation);

            example.Run(exampleReporter);

            specify(() => passingExpectation.Received().Run());
            specify(() => failingExpectation.Received().Run());
        }

        [Test]
        public void should_report_all_expectations_when_running_example()
        {
            example.AddExpectation(passingExpectation);
            example.AddExpectation(pendingExpectation);

            example.Run(exampleReporter);

            specify(() => exampleReporter.Received().ReportExpectation(passingExpectation));
            specify(() => exampleReporter.Received().ReportExpectation(pendingExpectation));
        }

        IExpectation CreateSubstituteExpectation(Action<IExpectation> initialize)
        {
            var expectation = Substitute.For<IExpectation>();
            initialize(expectation);

            return expectation;
        }
    }
}