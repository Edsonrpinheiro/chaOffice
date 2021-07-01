using System;
using Shared.Commands;

namespace Domain.Commands.UnitMeansureCommands
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