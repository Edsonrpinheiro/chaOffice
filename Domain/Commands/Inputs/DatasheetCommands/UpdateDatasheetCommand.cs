using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetCommands
{
    public class UpdateDatasheetCommand : ICommand
    {
        public UpdateDatasheetCommand(Guid id, string name, decimal labor)
        {
            Id = id;
            Name = name;
            Labor = labor;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Labor { get; set; }
    }
}