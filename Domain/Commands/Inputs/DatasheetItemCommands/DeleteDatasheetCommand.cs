using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetItemCommands
{
    public class DeleteDatasheetItemCommand : ICommand
    {
        public DeleteDatasheetItemCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}