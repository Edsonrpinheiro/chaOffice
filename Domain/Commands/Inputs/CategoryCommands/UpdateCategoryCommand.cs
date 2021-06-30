using System;
using Shared.Commands;

namespace Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : ICommand
    {
        public UpdateCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}