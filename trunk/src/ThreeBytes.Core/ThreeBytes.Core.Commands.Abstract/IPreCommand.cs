namespace ThreeBytes.Core.Commands.Abstract
{
    public interface IPreCommand
    {
        void Execute();
        bool HasExecuted { get; }
    }
}
