using System;

namespace NSpec.Core
{
    public class Runner : IDisposable
    {
        readonly Spec spec;
        readonly Example preExistingExample;

        public Runner(Spec spec)
        {
            this.spec = spec;
            preExistingExample = spec.Example;
        }

        public Example Run(Action specifyExpectations)
        {
            var example = new Example();
            spec.Example = example;

            specifyExpectations();
            example.Run();

            return example;
        }

        void IDisposable.Dispose()
        {
            spec.Example = preExistingExample;
        }
    }
}