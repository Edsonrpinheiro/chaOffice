using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetItemCommands
{
    public class CreateDatasheetItemCommand : ICommand
    {
        public CreateDatasheetItemCommand(Guid datasheet, Guid ingredient, decimal quantity, decimal price)
        {
            Datasheet = datasheet;
            Ingredient = ingredient;
            Quantity = quantity;
            Price = price;
        }

        public Guid Datasheet { get; set; }
        public Guid Ingredient { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}