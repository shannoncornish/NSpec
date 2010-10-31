using System.Linq;
using System.Reflection;
using NSubstitute;
using NUnit.Core;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class NSpecTestDecoratorSpecs : Spec
    {
        NSpecTestDecorator decorator;
        DecorateTestSpecification decorateTestSpecification;
        NSpecTestMethodBuilder nspecTestMethodBuilder;
        TestMethod test;

        [SetUp]
        public void setup()
        {
            decorateTestSpecification = Substitute.For<DecorateTestSpecification>();
            nspecTestMethodBuilder = new NSpecTestMethodBuilder();
            decorator = new NSpecTestDecorator(decorateTestSpecification, nspecTestMethodBuilder);

            test = TestSubstitute.ForTestMethod(); 
        }

        [Test]
        public void should_return_nspec_test_method_for_tests_that_match_specification()
        {
            decorateTestSpecification.IsSatisfiedBy(test).ReturnsForAnyArgs(true);

            var result = decorator.Decorate(test, null) as NSpecTestMethod;

            specify(() => result != null);
        }

        [Test]
        public void should_return_test_for_tests_that_do_not_match_specification()
        {
            var result = decorator.Decorate(test, null);

            specify(() => result == test);
        }
    }
}