using NSubstitute;
using NUnit.Core;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class DecorateTestSpecificationSpecs : Spec
    {
        DecorateTestSpecification specification;

        [SetUp]
        public void setup()
        {
            specification = new DecorateTestSpecification();    
        }

        [Test]
        public void given_test_with_test_method_test_type_and_test_fixture_type_that_inherits_from_spec()
        {
            var test = CreateTest();
            test.TestType.Returns("TestMethod");
            test.FixtureType.Returns(GetType());

            var result = specification.IsSatisfiedBy(test);

            specify(() => result);
        }

        [Test]
        public void given_test_with_test_method_test_type()
        {
            var test = CreateTest();
            test.TestType.Returns("TestMethod");

            var result = specification.IsSatisfiedBy(test);

            specify(() => result == false);
        }

        [Test]
        public void given_test_with_test_fixture_type_that_inherits_from_spec()
        {
            var test = CreateTest();
            test.FixtureType.Returns(GetType());

            var result = specification.IsSatisfiedBy(test);

            specify(() => result == false);
        }

        Test CreateTest()
        {
            return Substitute.For<Test>("");
        }
    }
}