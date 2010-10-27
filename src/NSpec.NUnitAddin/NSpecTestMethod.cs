using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class NSpecTestMethod : TestMethod
    {
        public NSpecTestMethod(TestMethod testMethod) : base(testMethod.Method)
        {
        }
    }
}