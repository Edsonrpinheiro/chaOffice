using Shared.Commands;

namespace Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}