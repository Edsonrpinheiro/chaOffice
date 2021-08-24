using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Handlers;
using Domain.Commands.ProductCommands;
using Domain.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductCommandHandler _handler;
        private readonly IProductRepository _productRepository;
        public ProductController(ProductCommandHandler handler, IProductRepository productRepository)
        {
            _handler = handler;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.Get();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = _productRepository.Get(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommand command)
        {
            var result = _handler.Handler(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateProductCommand command)
        {
            var result = _handler.Handler(command);
            return Ok(result);
        }

        // [HttpDelete]
        // public IActionResult Delete([FromBody] DeleteProductCommand command)
        // {
        //     var result = _handler.Handler(command);
        //     return Ok(result);
        // }
    }
}