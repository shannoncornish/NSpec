using NUnit.Framework;

namespace NSpec.Specs.Acceptance
{
    public class SpecifyingMessages : Spec
    {
        [Test]
        public void should_be_pending_when_specifying_message_only()
        {
            var result = this.Execute(specify_message);

            specify(() => result.IsPending);
        }

        void specify_message()
        {
            specify("message");
        }
    }
}