using Domain.Commands.CategoryCommands;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class CategoryCommandHandler :
    IHandler<CreateCategoryCommand>,
    IHandler<UpdateCategoryCommand>,
    IHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICommandResult Handler(CreateCategoryCommand command)
        {
            var categoryExists = _categoryRepository.CategoryExists(command.Name);

            if (categoryExists)
                return new GenericCommandResult("Categoria já criada anteriormente", false);

            var category = new Category(command.Name);
            _categoryRepository.Create(category);

            return new GenericCommandResult("Categoria criada com sucesso", true);
        }

        public ICommandResult Handler(UpdateCategoryCommand command)
        {

            var categoryExists = _categoryRepository.CategoryExists(command.Name, command.Id);

            if (categoryExists)
                return new GenericCommandResult("Categoria já criada anteriormente", false);

            var category = _categoryRepository.Get(command.Id);
            category.ChangeName(command.Name);

            _categoryRepository.Update(category);

            return new GenericCommandResult("Categoria atualizada com sucesso", true);
        }

        public ICommandResult Handler(DeleteCategoryCommand command)
        {
            var category = _categoryRepository.Get(command.Id);
            var categoryInUse = _categoryRepository.CategoryInUse(category);

            if (categoryInUse)
                return new GenericCommandResult("Categoria está sendo utilizada e não pode ser desativada", false);

            category.Deactivate();
            _categoryRepository.Update(category);

            return new GenericCommandResult("Categoria desativada com sucesso", true);
        }
    }
}