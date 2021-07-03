using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetCommands
{
    public class RemoveDatasheetCommand : ICommand
    {
        public RemoveDatasheetCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}