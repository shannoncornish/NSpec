using System;
using System.Linq.Expressions;
using NSpec.Core;

namespace NSpec
{
    public abstract class Spec
    {
        internal Example Example { get; set; }
        internal Action SetUpAction { get; set; }
        internal Action TearDownAction { get; set; }

        protected void specify(Expression<Action> expectation)
        {
            specify(null, expectation);
        }

        protected void specify(string message, Expression<Action> expectation)
        {
            EnsureNSpecConfiguration();

            Example.AddExpectation(new ActionExpectation(expectation) { Message = message });
        }

        protected void specify(Expression<Func<bool>> expectation)
        {
            specify(null, expectation);
        }

        protected void specify(string message, Expression<Func<bool>> expectation)
        {
            EnsureNSpecConfiguration();
            
            Example.AddExpectation(new FuncExpectation(expectation) { Message = message });
        }

        protected void specify(string message)
        {
            EnsureNSpecConfiguration();

            Example.AddExpectation(new PendingExpectation { Message = message });
        }

        internal void SetUp()
        {
            if (SetUpAction != null)
                SetUpAction();
        }

        internal void TearDown()
        {
            if (TearDownAction != null)
                TearDownAction();
        }

        void EnsureNSpecConfiguration()
        {
            if (Example == null)
                throw new NSpecConfigurationException();
        }
    }
}