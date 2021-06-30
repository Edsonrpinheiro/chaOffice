using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetCommands
{
    public class DeleteDatasheetCommand : ICommand
    {
        public DeleteDatasheetCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}