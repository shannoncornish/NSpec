namespace NSpec.Core
{
    public interface IExpectation
    {
        bool IsFail { get; }
        bool IsPass { get; }

        void Run();
    }
}