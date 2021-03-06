using System;
using NUnit.Framework;

namespace NSpec.Specs.Acceptance
{
    public class SpecifyingActions : Spec
    {
        [Test]
        public void should_pass_when_specifying_action_that_completes_successfully()
        {
            var result = this.Execute(specify_action_that_completes_successfully);

            specify(() => result.IsPass);
        }

        void specify_action_that_completes_successfully()
        {
            specify(() => action_that_completes_successfully());
        }

        [Test]
        public void should_pass_when_specifying_message_and_action_that_complets_successfully()
        {
            var result = this.Execute(specify_message_and_action_that_completes_sucessfully);

            specify(() => result.IsPass);
        }

        void specify_message_and_action_that_completes_sucessfully()
        {
            specify("message", () => action_that_completes_successfully());
        }

        void action_that_completes_successfully() {}

        [Test]
        public void should_fail_when_specifying_action_that_throws_exception()
        {
            var result = this.Execute(specify_action_that_throws_exception);

            specify(() => result.IsFail);
        }

        void specify_action_that_throws_exception()
        {
            specify(() => action_that_throws_exception());
        }

        void action_that_throws_exception()
        {
            throw new Exception();
        }
    }
}