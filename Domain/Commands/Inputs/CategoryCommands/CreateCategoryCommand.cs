using Shared.Commands;

namespace Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand : ICommand
    {
        public CreateCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}