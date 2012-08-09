using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NSpec.Core;

namespace NSpec
{
    public abstract class Spec
    {
        readonly Stack<Example> examples = new Stack<Example>();

        internal Example PreviousExample { get; private set; }

        protected void specify(Expression<Action> expectation)
        {
            specify(null, expectation);
        }

        protected void specify(string message, Expression<Action> expectation)
        {
            AddExpectation(new ActionExpectation(expectation) { Message = message });
        }

        protected void specify(Expression<Func<bool>> expectation)
        {
            specify(null, expectation);
        }

        protected void specify(string message, Expression<Func<bool>> expectation)
        {
            AddExpectation(new FuncExpectation(expectation) { Message = message });
        }

        protected void specify(string message)
        {
            AddExpectation(new PendingExpectation { Message = message });
        }

        internal void SetUp()
        {
            examples.Push(new Example());
        }

        internal void TearDown()
        {
            PreviousExample = examples.Pop();
        }

        void AddExpectation(IExpectation expectation)
        {
            if (examples.Count == 0)
                throw new NSpecConfigurationException();

            var currentExample = examples.Peek();
            currentExample.AddExpectation(expectation);
        }
    }
}