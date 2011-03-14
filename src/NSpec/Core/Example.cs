namespace NSpec.Core
{
    internal class Example
    {
        public bool IsFail { get; private set; }
        public bool IsPass { get; private set; }
        public bool IsPending { get; private set; }
    }
}