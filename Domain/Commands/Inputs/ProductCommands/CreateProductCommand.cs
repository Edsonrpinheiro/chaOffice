using System;
using Shared.Commands;

namespace Domain.Commands.ProductCommands
{
    public class CreateProductCommand : ICommand
    {
        public CreateProductCommand(string name, Guid category, string description)
        {
            Name = name;
            Category = category;
            Description = description;
        }

        public string Name { get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
    }
}