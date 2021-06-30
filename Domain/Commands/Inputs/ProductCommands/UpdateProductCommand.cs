using System;
using Shared.Commands;

namespace Domain.Commands.ProductCommands
{
    public class UpdateProductCommand : ICommand
    {
        public UpdateProductCommand(Guid id, string name, Guid category, string description)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
    }
}