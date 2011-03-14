using System;
using NSpec.Core;

namespace NSpec.Specs.Acceptance
{
    public static class SpecExtensions
    {
        internal static Example Execute(this Spec spec, Action example)
        {
            example();
            
            return new Example();
        }
    }
}