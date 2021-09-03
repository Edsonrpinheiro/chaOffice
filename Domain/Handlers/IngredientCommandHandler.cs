using Domain.Commands.IngredientCommands;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class IngredientCommandHandler :
    IHandler<CreateIngredientCommand>,
    IHandler<UpdateIngredientCommand>,
    IHandler<DeleteIngredientCommand>
    {   
        private readonly IUnitMeansureRepository _unitMeansureRepository;
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientCommandHandler(IUnitMeansureRepository unitMeansureRepository, IIngredientRepository ingredientRepository)
        {
            _unitMeansureRepository = unitMeansureRepository;
            _ingredientRepository = ingredientRepository;
        }

        public ICommandResult Handler(CreateIngredientCommand command)
        {   
            var ingredientAlreadyExists = _ingredientRepository.IngredientExists(command.Name);
            if(ingredientAlreadyExists)
                return new GenericCommandResult("Ingreditente já foi cadastrado anteriormente", false); 

            var unitMeansure = _unitMeansureRepository.Get(command.UnitMeansure);
            var ingredient = new Ingredient(unitMeansure, command.Name, command.Quantity, command.Price);
            _ingredientRepository.Add(ingredient);
            _ingredientRepository.Save();

            return new GenericCommandResult("Ingreditente adicionado", true);
        }

        public ICommandResult Handler(UpdateIngredientCommand command)
        {
            var ingredientAlreadyExists = _ingredientRepository.IngredientExists(command.Name, command.Id);
            if(ingredientAlreadyExists)
                return new GenericCommandResult("Ingreditente já foi cadastrado anteriormente", false); 

            var unitMeansure = _unitMeansureRepository.Get(command.UnitMeansure);
            var ingredient = _ingredientRepository.Get(command.Id);

            ingredient.Update(unitMeansure, command.Name, command.Quantity, command.Price);
            _ingredientRepository.Save();

            return new GenericCommandResult("Ingreditente alterado", true);
        }

        public ICommandResult Handler(DeleteIngredientCommand command)
        {   
            var ingredient = _ingredientRepository.Get(command.Id);
            var ingredientInUse = _ingredientRepository.IngredientInUse(ingredient);

            if(ingredientInUse)
                return new GenericCommandResult("Ingreditente não pode ser desativo pois está em uso", false);

            ingredient.Deactivate();
            _ingredientRepository.Save();

            return new GenericCommandResult("Ingreditente desativado", true);
        }
    }
}