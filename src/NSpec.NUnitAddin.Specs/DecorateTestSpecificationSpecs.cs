using NSubstitute;
using NUnit.Core;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class DecorateTestSpecificationSpecs : Spec
    {
        DecorateTestSpecification specification;
        Test test;

        [SetUp]
        public void setup()
        {
            specification = new DecorateTestSpecification();

            test = TestSubstitute.ForTest();
        }

        [Test]
        public void matches_given_test_with_test_method_test_type_and_test_fixture_type_that_inherits_from_spec()
        {
            test.TestType.Returns("TestMethod");
            test.FixtureType.Returns(GetType());

            var result = specification.IsSatisfiedBy(test);

            specify(() => result);
        }

        [Test]
        public void does_not_match_given_test_with_test_method_test_type()
        {
            test.TestType.Returns("TestMethod");

            var result = specification.IsSatisfiedBy(test);

            specify(() => result == false);
        }

        [Test]
        public void does_not_match_given_test_with_test_fixture_type_that_inherits_from_spec()
        {
            test.FixtureType.Returns(GetType());

            var result = specification.IsSatisfiedBy(test);

            specify(() => result == false);
        }
    }
}