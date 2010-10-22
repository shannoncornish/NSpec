using System.Reflection;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace NSpec.NUnitAddin
{
    public class NSpecTestDecorator : ITestDecorator
    {
        public Test Decorate(Test test, MemberInfo member)
        {
            return test;
        }
    }
}