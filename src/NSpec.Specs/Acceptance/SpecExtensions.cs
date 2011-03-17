using System;
using NSpec.Core;

namespace NSpec.Specs.Acceptance
{
    public static class SpecExtensions
    {
        internal static Example Execute(this Spec spec, Action specifyExpectations)
        {
            using (var runner = new Runner(spec))
                return runner.Run(specifyExpectations);
        }
    }
}