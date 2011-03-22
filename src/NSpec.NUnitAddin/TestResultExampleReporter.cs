using NSpec.Core;
using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class TestResultExampleReporter : IExampleReporter
    {
        readonly TestResult testResult;

        public TestResultExampleReporter(TestResult testResult)
        {
            this.testResult = testResult;
        }

        public void ReportExpectation(IExpectation expectation)
        {
            var result = CreateTestResultFromExpectation(expectation);
            testResult.AddResult(result);
        }

        TestResult CreateTestResultFromExpectation(IExpectation expectation)
        {
            var result = new TestResult(new TestName { Name = expectation.Message });

            if (expectation.IsFail)
                result.Failure(expectation.ToString(), "");
            else if (expectation.IsPass)
                result.Success();
            else if (expectation.IsPending)
                result.Ignore(expectation.ToString(), "");

            return result;
        }
    }
}