using System;
using Shared.Commands;

namespace Domain.Commands.IngredientCommands
{
    public class UpdateIngredientCommand : ICommand
    {
        public UpdateIngredientCommand(Guid id, Guid unitMeansure, string name, decimal quantity, decimal price)
        {
            Id = id;
            UnitMeansure = unitMeansure;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public Guid Id { get; set; }
        public Guid UnitMeansure { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}