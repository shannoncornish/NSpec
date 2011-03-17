using System;
using NSubstitute.Core;

namespace NSpec.Specs
{
    public static class NSubstituteExtensions
    {
        public static void Throw<T>(this WhenCalled<T> whenCalled, Exception exception)
        {
            whenCalled.Do(x => { throw exception; });
        }
    }
}