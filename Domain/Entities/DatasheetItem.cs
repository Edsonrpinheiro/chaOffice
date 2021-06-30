using System;
using Shared.Entities;

namespace Domain.Entities
{
    public class DatasheetItem : Entity
    {
        public DatasheetItem(Ingredient ingredient, decimal quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
            Price = Ingredient.Price;
            CreatedAt = DateTime.Now;
        }

        public Ingredient Ingredient { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public decimal Total() => (Quantity * Price) / Ingredient.TotalQuantity;
    }
}