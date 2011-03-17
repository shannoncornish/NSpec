using System;
using NSpec.Core;
using NSubstitute;
using NUnit.Framework;

namespace NSpec.Specs.Core
{
    public class FuncExpectationSpec : Spec
    {
        Func<bool> func;
        FuncExpectation funcExpectation;

        [SetUp]
        public void setup()
        {
            func = Substitute.For<Func<bool>>();
            funcExpectation = new FuncExpectation(() => func());
        }

        [Test]
        public void should_pass_when_func_returns_true()
        {
            func.Invoke().Returns(true);
            
            funcExpectation.Run();

            specify(() => funcExpectation.IsPass);
        }

        [Test]
        public void should_fail_when_func_returns_false()
        {
            func.Invoke().Returns(false);

            funcExpectation.Run();

            specify(() => funcExpectation.IsFail);
        }

        [Test]
        public void should_fail_when_func_throws_exception()
        {
            func.When(x => x.Invoke()).Throw(new Exception());

            funcExpectation.Run();

            specify(() => funcExpectation.IsFail);
        }
    }
}