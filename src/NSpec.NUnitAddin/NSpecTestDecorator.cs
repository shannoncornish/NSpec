using System.Reflection;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NSpec.NUnitAddin
{
    public class NSpecTestDecorator : ITestDecorator
    {
        readonly DecorateTestSpecification decorateTestSpecification;
        readonly NSpecTestMethodBuilder nspecTestMethodBuilder;

        public NSpecTestDecorator(DecorateTestSpecification decorateTestSpecification, NSpecTestMethodBuilder nspecTestMethodBuilder)
        {
            this.decorateTestSpecification = decorateTestSpecification;
            this.nspecTestMethodBuilder = nspecTestMethodBuilder;
        }

        public Test Decorate(Test test, MemberInfo member)
        {
            if (decorateTestSpecification.IsSatisfiedBy(test))
                return nspecTestMethodBuilder.Build((TestMethod) test);

            return test;
        }
    }
}