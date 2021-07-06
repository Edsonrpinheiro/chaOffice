using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetItemCommands
{
    public class UpdateDatasheetItemCommand : ICommand
    {
        public UpdateDatasheetItemCommand(Guid id, decimal quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
    }
}