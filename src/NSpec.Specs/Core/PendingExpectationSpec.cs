using NSpec.Core;
using NUnit.Framework;

namespace NSpec.Specs.Core
{
    public class PendingExpectationSpec : Spec
    {
        [Test]
        public void is_pending_should_always_be_true()
        {
            var pendingExpectation = new PendingExpectation();

            specify(() => pendingExpectation.IsPending);
        }
    }
}