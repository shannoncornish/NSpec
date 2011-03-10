using System;

namespace NSpec.Specs.Acceptance
{
    public static class SpecExtensions
    {
        public static bool Execute(this Spec spec, Action example)
        {
            example();

            return true;
        }
    }
}