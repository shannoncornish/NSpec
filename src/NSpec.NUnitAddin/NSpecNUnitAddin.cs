using NUnit.Core.Extensibility;

namespace NSpec.NUnitAddin
{
    [NUnitAddin]
    public class NSpecNUnitAddin : IAddin
    {
        public bool Install(IExtensionHost host)
        {
            var extensionPoint = host.GetExtensionPoint("TestDecorators");
            if (extensionPoint == null)
                return false;

            extensionPoint.Install(new NSpecTestDecorator(new DecorateTestSpecification(), new NSpecTestMethodBuilder()));

            return true;
        }
    }
}
