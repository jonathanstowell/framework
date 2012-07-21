namespace ThreeBytes.Core.Commands.Abstract
{
    public interface ICommand
    {
        void Execute();
        bool HasExecuted { get; }
    }
}
