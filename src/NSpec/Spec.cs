using System;

namespace NSpec
{
    public abstract class Spec
    {
        protected void specify(Action action)
        {
            action();
        }

        protected void specify(Func<bool> func)
        {
            var result = func();
            if (!result) 
                throw new Exception();
       }
    }
}
