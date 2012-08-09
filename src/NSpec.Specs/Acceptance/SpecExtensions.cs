using System;
using NSpec.Core;
using NSubstitute;

namespace NSpec.Specs.Acceptance
{
    public static class SpecExtensions
    {
        internal static Example Execute(this Spec spec, Action specifyExpectations)
        {
            spec.SetUp();
            specifyExpectations();
            spec.TearDown();

            var example = spec.PreviousExample;
            example.Run(Substitute.For<IExampleReporter>());

            return spec.PreviousExample;
        }
    }
}