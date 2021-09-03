using Domain.Commands.ProductCommands;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{   
    public class ProductCommandHandler :
    IHandler<CreateProductCommand>,
    IHandler<UpdateProductCommand>
    {
        public ProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ICommandResult Handler(CreateProductCommand command)
        {
            var productExists = _productRepository.ProductExists(command.Name);

            if(productExists)
                return new GenericCommandResult("Produto já cadastrado", false);

            var category = _categoryRepository.Get(command.Category);
            var product = new Product(command.Name, category, command.Description);
            _productRepository.Add(product);

            return new GenericCommandResult("Produto criado", true);
        }

        public ICommandResult Handler(UpdateProductCommand command)
        {
            var productExists = _productRepository.ProductExists(command.Name, command.Id);

            if(productExists)
                return new GenericCommandResult("Produto já cadastrado", false);

            var product = _productRepository.Get(command.Id);
            var category = _categoryRepository.Get(command.Category);

            product.Update(command.Name, category, command.Description);
            _productRepository.Update(product);

            return new GenericCommandResult("Produto atualizado", true);
        }
    }
}