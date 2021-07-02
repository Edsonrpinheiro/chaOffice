using System;
using Shared.Entities;

namespace Domain.Entities
{
    public class Ingredient : Entity
    {
        public Ingredient(UnitMeansure unitMeansure, string name, decimal totalQuantity, decimal price)
        {
            UnitMeansure = unitMeansure;
            Name = name;
            TotalQuantity = totalQuantity;
            Price = price;
            CreatedAt = DateTime.Now;
            Status = true;
        }

        public UnitMeansure UnitMeansure { get; private set; }
        public string Name { get; private set; }
        public decimal TotalQuantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Status { get; private set; }

        public void Update(UnitMeansure unitMeansure, string name, decimal totalQuantity, decimal price)
        {
            UnitMeansure = unitMeansure;
            Name = name;
            TotalQuantity = totalQuantity;
            Price = price;
            UpdatedAt = DateTime.Now;
        }

        public void Deactivate() => Status = false;
        public void Activate() => Status = true;
    }
}