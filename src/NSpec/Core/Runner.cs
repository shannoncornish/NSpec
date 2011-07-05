using System;

namespace NSpec.Core
{
    public class Runner : IDisposable
    {
        readonly Spec spec;
        readonly Example preExistingExample;
        readonly Action preExistingSetUpAction;
        readonly Action preExistingTearDownAction;

        public Runner(Spec spec)
        {
            this.spec = spec;

            preExistingExample = spec.Example;
            preExistingSetUpAction = spec.SetUpAction;
            preExistingTearDownAction = spec.TearDownAction;
        }

        public Example Run(Action specifyExpectations, IExampleReporter exampleReporter)
        {
            var example = new Example();
            spec.SetUpAction = () => spec.Example = example;
            spec.TearDownAction = () => example.Run(exampleReporter);

            specifyExpectations();

            return example;
        }

        void IDisposable.Dispose()
        {
            spec.Example = preExistingExample;
            spec.SetUpAction = preExistingSetUpAction;
            spec.TearDownAction = preExistingTearDownAction;
        }
    }
}