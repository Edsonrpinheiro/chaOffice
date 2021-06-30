using System;
using Shared.Commands;

namespace Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : ICommand
    {
        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}