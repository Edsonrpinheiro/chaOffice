using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetItemCommands
{
    public class DeleteDatasheetItemCommand : ICommand
    {
        public DeleteDatasheetItemCommand(Guid id, Guid datasheet)
        {
            Id = id;
            Datasheet = datasheet;
        }

        public Guid Id { get; set; }
        public Guid Datasheet { get; set; }
    }
}