namespace NSpec.Core
{
    public class PendingExpectation : IExpectation
    {
        public bool IsFail { get { return false; } }
        public bool IsPass { get { return false; } }
        public bool IsPending { get { return true; } }

        public void Run() {}
    }
}