using System.Reflection;
using System.Text;
using NSpec.Core;
using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class NSpecTestMethod : TestMethod
    {
        static readonly MethodInfo setUpMethod;
        static readonly MethodInfo tearDownMethod;

        static NSpecTestMethod()
        {
            var specType = typeof(Spec);
            setUpMethod = specType.GetMethod("SetUp", BindingFlags.Instance | BindingFlags.NonPublic);
            tearDownMethod = specType.GetMethod("TearDown", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public NSpecTestMethod(MethodInfo methodInfo) : base(methodInfo)
        {
        }

        public override TestResult RunTest()
        {
            ArrayUtil.Add(ref setUpMethods, setUpMethod);
            ArrayUtil.Add(ref tearDownMethods, tearDownMethod); // TearDown methods are run in reverse order

            var testResult = base.RunTest();
            if (testResult.IsSuccess)
            {
                var exampleResult = new TestResult(this);
                var exampleReporter = new TestResultExampleReporter(exampleResult);

                var example = ((Spec) Fixture).PreviousExample;
                example.Run(exampleReporter);

                if (example.IsFail)
                    testResult.Failure(GetTestResultMessageForResultState(exampleResult, ResultState.Failure, "Failing"), "");

                if (example.IsPending)
                    testResult.Ignore(GetTestResultMessageForResultState(exampleResult, ResultState.Ignored, "Pending"));
            }

            return testResult;
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