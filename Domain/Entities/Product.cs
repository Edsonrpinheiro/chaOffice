using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Entities;

namespace Domain.Entities
{
    public class Product : Entity
    {
        private readonly IList<Datasheet> _datasheets;

        protected Product()
        {
            _datasheets = new List<Datasheet>();            
        }
        
        public Product(string name, Category category, string description)
        {
            Name = name;
            Category = category;
            Description = description;
            CreatedAt = DateTime.Now;
            _datasheets = new List<Datasheet>();
        }
        
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IReadOnlyCollection<Datasheet> Datasheets => _datasheets.ToArray();
        
        public void AddDatasheet(Datasheet datasheet) 
        {
            _datasheets.Add(datasheet);        
        }

        public void Update(string name, Category category, string description) 
        {            
            Name = name;
            Category = category;
            Description = description;
            UpdatedAt = DateTime.Now;
        }
    }
}