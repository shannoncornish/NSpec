using System;
using System.Reflection;
using System.Text;
using NSpec.Core;
using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class NSpecTestMethod : TestMethod
    {
        public NSpecTestMethod(MethodInfo methodInfo) : base(methodInfo)
        {
        }

        Spec Spec
        {
            get { return (Spec) Fixture; }
        }

        public override void RunTestMethod(TestResult testResult)
        {
            using (var runner = new Runner(Spec))
            {
                var example = runner.Run(() => RunBaseTestMethod(testResult), new TestResultExampleReporter(testResult));

                if (example.IsFail)
                    testResult.Failure(GetTestResultMessageForResultState(testResult, ResultState.Failure, "Failing"), "");

                if (example.IsPass)
                    testResult.Success();

                if (example.IsPending)
                    testResult.Ignore(GetTestResultMessageForResultState(testResult, ResultState.Ignored, "Pending"));
            }
        }

        void RunBaseTestMethod(TestResult testResult)
        {
            base.RunTestMethod(testResult);
        }

        string GetTestResultMessageForResultState(TestResult testResult, ResultState state, string heading)
        {
            var messageBuilder = new StringBuilder();
            for (var i = 0; i < testResult.Results.Count; i++)
            {
                var result = (TestResult) testResult.Results[i];
                if (result.ResultState == state)
                {
                    messageBuilder.AppendLine(string.Format("{0} for specification {1}", heading, i + 1));
                    messageBuilder.AppendLine(result.Message);
                }
            }

            return messageBuilder.ToString();
        }
    }
}