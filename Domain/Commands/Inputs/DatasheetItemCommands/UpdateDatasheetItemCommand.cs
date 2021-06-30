using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetCommands
{
    public class UpdateDatasheetItemCommand : ICommand
    {
        public UpdateDatasheetItemCommand(Guid id, Guid ingredient, decimal quantity, decimal price)
        {
            Id = id;
            Ingredient = ingredient;
            Quantity = quantity;
            Price = price;
        }

        public Guid Id { get; set; }
        public Guid Ingredient { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}