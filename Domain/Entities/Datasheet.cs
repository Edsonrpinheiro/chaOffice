using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Enums;
using Shared.Entities;

namespace Domain.Entities
{
    public class Datasheet : Entity
    {
        private readonly IList<DatasheetItem> _items;

        public Datasheet(string name, decimal labor)
        {
            Name = name;
            Labor = labor;
            Status = EDatasheetStatus.Created;
            CreatedAt = DateTime.Now;
            _items = new List<DatasheetItem>();
        }

        public string Name { get; private set; }
        public EDatasheetStatus Status { get; private set; }
        public decimal Labor { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyCollection<DatasheetItem> Items => _items.ToArray();
        public bool ContainsIngredient(Ingredient ingredient) => Items.Any(x => x.Ingredient.Id == ingredient.Id);
        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total() => SubTotal() + Labor;

        public void AddItem(DatasheetItem item)
        {
            _items.Add(item);
            Status = EDatasheetStatus.InConstruct;
            UpdatedAt = DateTime.Now;
        }

        public void RemoveItem(DatasheetItem item)
        {
            _items.Remove(item);
            Status = EDatasheetStatus.InConstruct;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string name, decimal labor)
        {
            Name = name;
            Labor = labor;
            UpdatedAt = DateTime.Now;
        }
    }
}