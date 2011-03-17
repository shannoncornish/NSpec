using System;
using System.Linq.Expressions;

namespace NSpec.Core
{
    public class ActionExpectation : IExpectation
    {
        readonly Expression<Action> expression;

        public ActionExpectation(Expression<Action> expression)
        {
            this.expression = expression;
        }

        public bool IsFail { get; private set; }
        public bool IsPass { get; private set; }
        public bool IsPending { get; private set; }

        public void Run()
        {
            var action = expression.Compile();
            try
            {
                action();

                IsPass = true;
            }
            catch
            {
                IsFail = true;
            }
        }
    }
}