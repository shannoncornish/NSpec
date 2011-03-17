using System;
using System.Linq.Expressions;

namespace NSpec.Core
{
    public class FuncExpectation : IExpectation
    {
        readonly Expression<Func<bool>> expression;

        public FuncExpectation(Expression<Func<bool>> expression)
        {
            this.expression = expression;
        }

        public bool IsPass { get; private set; }
        public bool IsFail { get; private set; }

        public void Run()
        {
            var func = expression.Compile();
            try
            {
                var result = func();

                IsPass = result;
                IsFail = !result;
            }
            catch
            {
                IsFail = true;
            }
        }
    }
}