using System;
using Shared.Commands;

namespace Domain.Commands.DatasheetCommands
{
    public class AddDatasheetCommand : ICommand
    {
        public AddDatasheetCommand(Guid product, string name, decimal labor)
        {
            Product = product;
            Name = name;
            Labor = labor;
        }

        public Guid Product { get; set; }
        public string Name { get; set; }
        public decimal Labor { get; set; }
    }
}