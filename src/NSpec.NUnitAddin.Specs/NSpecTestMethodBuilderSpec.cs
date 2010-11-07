using System;
using System.Collections;
using NSubstitute;
using NUnit.Core;
using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class NSpecTestMethodBuilderSpec : Spec
    {
        NSpecTestMethodBuilder builder;
        TestMethod test;

        [SetUp]
        public void setup()
        {
            builder = new NSpecTestMethodBuilder();

            test = NUnitSubstitute.ForTestMethod();
            test.BuilderException = new Exception();
            test.Categories = new ArrayList();
            test.Description = "description";
            test.ExceptionProcessor = Substitute.For<ExpectedExceptionProcessor>(test);
            test.Fixture = this;
            test.IgnoreReason = "ignoreReason";
            test.Parent = NUnitSubstitute.ForTest();
            test.Properties = new Hashtable();
            test.RunState = RunState.Runnable;
        }

        [Test]
        public void when_building_should_copy_values_from_test_method()
        {
            var result = builder.Build(test);

            specify(() => result.BuilderException == test.BuilderException);
            specify(() => result.Categories == test.Categories);
            specify(() => result.Description == test.Description);
            specify(() => result.ExceptionProcessor == test.ExceptionProcessor);
            specify(() => result.Fixture == test.Fixture);
            specify(() => result.IgnoreReason == test.IgnoreReason);
            specify(() => result.Parent == test.Parent);
            specify(() => result.Properties == test.Properties);
            specify(() => result.RunState == test.RunState);
        }
    }
}