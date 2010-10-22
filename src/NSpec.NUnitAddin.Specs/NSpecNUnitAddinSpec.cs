using NSubstitute;
using NUnit.Core.Extensibility;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class NSpecNUnitAddinSpec : Spec
    {
        NSpecNUnitAddin addin;

        [SetUp]
        public void setup()
        {
            addin = new NSpecNUnitAddin();
        }

        [Test]
        public void when_installing()
        {
            var extensionHost = Substitute.For<IExtensionHost>();
            var extensionPoint = extensionHost.GetExtensionPoint("TestDecorators");

            var result = addin.Install(extensionHost);

            specify(() => result == true);

            specify(() => extensionPoint.Received().Install(Arg.Any<NSpecTestDecorator>()));
        }

        [Test]
        public void when_installing_without_an_extension_point()
        {
            var extensionHost = Substitute.For<IExtensionHost>();
            extensionHost.GetExtensionPoint("TestDecorators").Returns((IExtensionPoint) null);

            var result = addin.Install(extensionHost);

            specify(() => result == false);
        }
    }
}