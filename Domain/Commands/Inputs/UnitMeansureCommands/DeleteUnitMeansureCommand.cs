using System;
using Shared.Commands;

namespace Domain.Commands.CategoryCommands
{
    public class DeleteUnitMeansureCommand : ICommand
    {
        public DeleteUnitMeansureCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}