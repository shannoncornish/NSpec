using System;
using System.Linq.Expressions;
using NSpec.Core;

namespace NSpec
{
    public abstract class Spec
    {
        internal Example Example { get; set; }

        protected void specify(Expression<Action> expectation)
        {
            EnsureNSpecConfiguration();

            Example.AddExpectation(new ActionExpectation(expectation));
        }

        protected void specify(Expression<Func<bool>> expectation)
        {
            EnsureNSpecConfiguration();

            Example.AddExpectation(new FuncExpectation(expectation));
        }

        protected void specify(string message)
        {
            EnsureNSpecConfiguration();

            Example.AddExpectation(new PendingExpectation());
        }

        void EnsureNSpecConfiguration()
        {
            if (Example == null)
                throw new NSpecConfigurationException();
        }
    }
}