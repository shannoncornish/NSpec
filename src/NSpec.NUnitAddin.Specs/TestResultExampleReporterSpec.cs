using System;
using NSpec.Core;
using NSubstitute;
using NUnit.Core;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class TestResultExampleReporterSpec : Spec
    {
        TestResult testResult;
        TestResultExampleReporter testResultExampleReporter;

        [SetUp]
        public void setup()
        {
            testResult = new TestResult(NUnitSubstitute.ForTest());
            testResultExampleReporter = new TestResultExampleReporter(testResult);
        }

        [Test]
        public void report_expectations_for_failing_expectations_should_add_test_result_with_failure_state()
        {
            var failingExpectation = CreateSubstituteExpectation(e => e.IsFail.Returns(true));

            testResultExampleReporter.ReportExpectation(failingExpectation);

            var result = FirstTestResult();
            specify(() => result.ResultState == ResultState.Failure);
        }

        [Test]
        public void report_expectations_for_passing_expectations_should_add_test_result_with_sucess_state()
        {
            var passingExpectation = CreateSubstituteExpectation(e => e.IsPass.Returns(true));

            testResultExampleReporter.ReportExpectation(passingExpectation);

            var result = FirstTestResult();
            specify(() => result.ResultState == ResultState.Success);
        }

        [Test]
        public void report_expectations_for_pending_expectations_should_add_test_result_with_ignored_state()
        {
            var pendingExpectation = CreateSubstituteExpectation(e => e.IsPending.Returns(true));

            testResultExampleReporter.ReportExpectation(pendingExpectation);

            var result = FirstTestResult();
            specify(() => result.ResultState == ResultState.Ignored);
        }

        IExpectation CreateSubstituteExpectation(Action<IExpectation> initialize)
        {
            var expectation = Substitute.For<IExpectation>();
            initialize(expectation);

            return expectation;
        }

        TestResult FirstTestResult()
        {
            return (TestResult) testResult.Results[0];
        }
    }
}