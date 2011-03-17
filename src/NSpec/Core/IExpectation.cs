namespace NSpec.Core
{
    public interface IExpectation
    {
        bool IsFail { get; }
        bool IsPass { get; }
        bool IsPending { get; }

        void Run();
    }
}