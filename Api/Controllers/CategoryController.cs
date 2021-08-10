using Domain.Commands.CategoryCommands;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {   

        private readonly CategoryCommandHandler _handler;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(CategoryCommandHandler handler, ICategoryRepository categoryRepository)
        {
            _handler = handler;
            _categoryRepository = categoryRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {   
            var categories = _categoryRepository.Get();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryCommand command)
        {   
            var result = _handler.Handler(command);
            return Ok(result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateCategoryCommand command)
        {   
            var result = _handler.Handler(command);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return NoContent();
        }
    }
}
