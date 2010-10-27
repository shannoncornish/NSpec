using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class DecorateTestSpecification
    {
        const string TestMethodTestType = "TestMethod";

        public virtual bool IsSatisfiedBy(Test test)
        {
            return test.TestType == TestMethodTestType
                && typeof(Spec).IsAssignableFrom(test.FixtureType);
        }
    }
}