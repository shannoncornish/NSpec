using System.Reflection;
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
                var example = runner.Run(() => RunBaseTestMethod(testResult));

                if (example.IsFail)
                    testResult.Failure("", "");
                else if (example.IsPending)
                    testResult.Ignore("");
            }
        }

        void RunBaseTestMethod(TestResult testResult)
        {
            base.RunTestMethod(testResult);
        }
    }
}