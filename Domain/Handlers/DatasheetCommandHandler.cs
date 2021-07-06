using Domain.Commands.DatasheetCommands;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class DatasheetCommandHandler :
    IHandler<AddDatasheetCommand>,
    IHandler<RemoveDatasheetCommand>,
    IHandler<UpdateDatasheetCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDatasheetRepository _datasheetRepository;
        public DatasheetCommandHandler(IProductRepository productRepository, IDatasheetRepository datasheetRepository)
        {
            _productRepository = productRepository;
            _datasheetRepository = datasheetRepository;
        }

        public ICommandResult Handler(AddDatasheetCommand command)
        {
            var product = _productRepository.Get(command.Product);
            var datasheet = new Datasheet(command.Name, command.Labor);
            product.AddDatasheet(datasheet);
            _productRepository.Save(product);

            return new GenericCommandResult("Ficha técnica adicionada ao produto", true);
        }

        public ICommandResult Handler(RemoveDatasheetCommand command)
        {
            var datasheet = _datasheetRepository.Get(command.Id);
            _datasheetRepository.Delete(datasheet);

            return new GenericCommandResult("Ficha técnica excluída", true);
        }

        public ICommandResult Handler(UpdateDatasheetCommand command)
        {
            var datasheet = _datasheetRepository.Get(command.Id);
            datasheet.Update(command.Name, command.Labor);
            _datasheetRepository.Save(datasheet);
            
            return new GenericCommandResult("Ficha técnica atualizada", true);
        }
    }
}