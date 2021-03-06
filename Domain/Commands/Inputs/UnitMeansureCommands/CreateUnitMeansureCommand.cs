using Shared.Commands;

namespace Domain.Commands.UnitMeansureCommands
{
    public class CreateUnitMeansureCommand : ICommand
    {
        public CreateUnitMeansureCommand(string name, string acronym)
        {
            Name = name;
            Acronym = acronym;
        }

        public string Name { get; set; }
        public string Acronym { get; set; }
    }
}