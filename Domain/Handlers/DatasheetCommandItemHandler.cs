using Domain.Commands.DatasheetItemCommands;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class DatasheetCommandItemHandler :
        IHandler<CreateDatasheetItemCommand>,
        IHandler<UpdateDatasheetItemCommand>,
        IHandler<DeleteDatasheetItemCommand>
    {   
        private readonly IDatasheetItemRepository _datasheetItemRepository;
        private readonly IDatasheetRepository _datasheetRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public DatasheetCommandItemHandler(IDatasheetItemRepository datasheetItemRepository, IDatasheetRepository datasheetRepository, IIngredientRepository ingredientRepository)
        {
            _datasheetItemRepository = datasheetItemRepository;
            _datasheetRepository = datasheetRepository;
            _ingredientRepository = ingredientRepository;
        }

        public ICommandResult Handler(CreateDatasheetItemCommand command)
        {   
            var datasheet = _datasheetRepository.Get(command.Datasheet);
            var ingredient = _ingredientRepository.Get(command.Ingredient);
            
            var datasheetContainsIngredient = datasheet.ContainsIngredient(ingredient);
            if(datasheetContainsIngredient)
                return new GenericCommandResult("Essa ficha técnica já possui esse ingrediente", true);

            var item = new DatasheetItem(ingredient, command.Quantity);
            datasheet.AddItem(item);

            _datasheetRepository.Save(datasheet);

            return new GenericCommandResult("Item adicionado a ficha técnica", true);
        }

        public ICommandResult Handler(UpdateDatasheetItemCommand command)
        {
            var item = _datasheetItemRepository.Get(command.Id);
            item.UpdateQuantity(command.Quantity);

            return new GenericCommandResult("Item atualizado", true);
        }

        public ICommandResult Handler(DeleteDatasheetItemCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}