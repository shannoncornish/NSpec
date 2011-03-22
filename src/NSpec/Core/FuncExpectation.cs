using System;
using System.Linq.Expressions;
using System.Text;

namespace NSpec.Core
{
    public class FuncExpectation : IExpectation
    {
        readonly Expression<Func<bool>> expression;
        Exception exception;

        public FuncExpectation(Expression<Func<bool>> expression)
        {
            this.expression = expression;
        }

        public bool IsFail { get; private set; }
        public bool IsPass { get; private set; }
        public bool IsPending { get { return false; } }

        public string Message { get; set; }

        public void Run()
        {
            var func = expression.Compile();
            try
            {
                var result = func();

                IsPass = result;
                IsFail = !result;
            }
            catch (Exception e)
            {
                exception = e;
                IsFail = true;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            if (Message != null)
                stringBuilder.AppendLine(string.Format("Message: {0}", Message));

            stringBuilder.AppendLine(string.Format("Expression: {0}", expression));

            if (exception != null)
                stringBuilder.AppendLine(string.Format("Exception: {0}", exception));

            return stringBuilder.ToString();
        }
    }
}