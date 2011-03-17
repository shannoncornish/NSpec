using System.Collections.Generic;
using System.Linq;

namespace NSpec.Core
{
    public class Example
    {
        readonly List<IExpectation> expectations = new List<IExpectation>();

        public bool IsFail
        {
            get { return expectations.Any(e => e.IsFail); }
        }

        public bool IsPass
        {
            get { return expectations.All(e => e.IsPass); }
        }

        public bool IsPending
        {
            get { return !IsFail && expectations.Any(e => e.IsPending); }
        }

        public void AddExpectation(IExpectation expectation)
        {
            expectations.Add(expectation);
        }

        public void Run()
        {
            expectations.ForEach(e => e.Run());
        }
    }
}