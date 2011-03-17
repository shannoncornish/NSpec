using System;
using NSpec.Core;
using NSubstitute;
using NUnit.Framework;

namespace NSpec.Specs.Core
{
    public class ActionExpectationSpec : Spec
    {
        Action action;
        ActionExpectation actionExpectation;

        [SetUp]
        public void setup()
        {
            action = Substitute.For<Action>();
            actionExpectation = new ActionExpectation(() => action());
        }

        [Test]
        public void should_pass_when_running_action_that_completes_successfully()
        {
            actionExpectation.Run();

            specify(() => actionExpectation.IsPass);
        }

        [Test]
        public void should_fail_when_running_action_that_throws_exception()
        {
            action.When(x => x.Invoke()).Throw(new Exception());

            actionExpectation.Run();

            specify(() => actionExpectation.IsFail);
        }
    }
}