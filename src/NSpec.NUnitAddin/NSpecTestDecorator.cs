using System.Reflection;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NSpec.NUnitAddin
{
    public class NSpecTestDecorator : ITestDecorator
    {
        readonly DecorateTestSpecification decorateTestSpecification;

        public NSpecTestDecorator(DecorateTestSpecification decorateTestSpecification)
        {
            this.decorateTestSpecification = decorateTestSpecification;
        }

        public Test Decorate(Test test, MemberInfo member)
        {
            if (decorateTestSpecification.IsSatisfiedBy(test))
                return new NSpecTestMethod((TestMethod) test);

            return test;
        }
    }
}