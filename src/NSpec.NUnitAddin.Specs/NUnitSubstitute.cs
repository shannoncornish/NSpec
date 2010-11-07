using System.Linq;
using NSubstitute;
using NUnit.Core;

namespace NSpec.NUnitAddin.Specs
{
    public static class NUnitSubstitute
    {
        public static Test ForTest()
        {
            return Substitute.For<Test>("");
        }

        public static TestMethod ForTestMethod()
        {
            return Substitute.For<TestMethod>(typeof(object).GetMethods().First());
        }
    }
}