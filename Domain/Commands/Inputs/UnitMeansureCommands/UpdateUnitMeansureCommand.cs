using System;
using Shared.Commands;

namespace Domain.Commands.CategoryCommands
{
    public class UpdateUnitMeansureCommand : ICommand
    {
        public UpdateUnitMeansureCommand(Guid id, string name, string acronym)
        {
            Id = id;
            Name = name;
            Acronym = acronym;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
    }
}