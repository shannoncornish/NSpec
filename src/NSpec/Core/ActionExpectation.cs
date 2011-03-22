using System;
using System.Linq.Expressions;
using System.Text;

namespace NSpec.Core
{
    public class ActionExpectation : IExpectation
    {
        readonly Expression<Action> expression;
        Exception exception;

        public ActionExpectation(Expression<Action> expression)
        {
            this.expression = expression;
        }

        public bool IsFail { get; private set; }
        public bool IsPass { get; private set; }
        public bool IsPending { get { return false; } }

        public string Message { get; set; }

        public void Run()
        {
            var action = expression.Compile();
            try
            {
                action();

                IsPass = true;
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