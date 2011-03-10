using NUnit.Framework;

namespace NSpec.Specs
{
    public class PendingAttribute : CategoryAttribute
    {
        public PendingAttribute() : base("Pending") {}
    }
}