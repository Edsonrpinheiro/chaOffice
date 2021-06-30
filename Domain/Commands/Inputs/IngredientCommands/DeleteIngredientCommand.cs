using System;
using Shared.Commands;

namespace Domain.Commands.IngredientCommands
{
    public class DeleteIngredientCommand : ICommand
    {
        public DeleteIngredientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}