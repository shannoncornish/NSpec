using NUnit.Core;

namespace NSpec.NUnitAddin
{
    public class NSpecTestMethodBuilder
    {
        public virtual NSpecTestMethod Build(TestMethod test)
        {
            return new NSpecTestMethod(test.Method)
                       {
                           BuilderException = test.BuilderException,
                           Categories = test.Categories,
                           Description = test.Description,
                           ExceptionProcessor = test.ExceptionProcessor,
                           Fixture = test.Fixture,
                           IgnoreReason = test.IgnoreReason,
                           Parent = test.Parent,
                           Properties = test.Properties,
                           RunState = test.RunState
                       };
        }
    }
}