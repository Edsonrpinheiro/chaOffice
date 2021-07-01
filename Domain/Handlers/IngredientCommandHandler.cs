using Domain.Commands.IngredientCommands;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class IngredientCommandHandler :
    IHandler<CreateIngredientCommand>,
    IHandler<UpdateIngredientCommand>,
    IHandler<DeleteIngredientCommand>
    {
        public ICommandResult Handler(CreateIngredientCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handler(UpdateIngredientCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handler(DeleteIngredientCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}