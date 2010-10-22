using NSubstitute;
using NUnit.Core;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class NSpecTestDecoratorSpec : Spec
    {
        private NSpecTestDecorator decorator;

        [SetUp]
        public void setup()
        {
            decorator = new NSpecTestDecorator();
        }

        [Test]
        public void when_decorating()
        {
            var test = Substitute.For<Test>("name");

            var result = decorator.Decorate(test, null);

            specify(() => result == test);
        }
    }
}