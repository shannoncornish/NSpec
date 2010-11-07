using System;
using System.Linq.Expressions;

namespace NSpec
{
    public abstract class Spec
    {
        protected void specify(Expression<Action> expression)
        {
            var action = expression.Compile();
            action();
        }

        protected void specify(Expression<Func<bool>> expression)
        {
            var func = expression.Compile();
            var result = func();
            if (!result) 
                throw new Exception();
       }
    }
}
