using System;
using Shared.Commands;

namespace Domain.Commands.IngredientCommands
{
    public class CreateIngredientCommand : ICommand
    {
        public CreateIngredientCommand(Guid unitMeansure, string name, decimal quantity, decimal price)
        {
            UnitMeansure = unitMeansure;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public Guid UnitMeansure { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}