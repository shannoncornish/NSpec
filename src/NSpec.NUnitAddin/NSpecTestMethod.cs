using System.Reflection;
using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class NSpecTestMethod : TestMethod
    {
        public NSpecTestMethod(MethodInfo methodInfo) : base(methodInfo)
        {
        }
    }
}