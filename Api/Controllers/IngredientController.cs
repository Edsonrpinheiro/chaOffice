using Domain.Commands.IngredientCommands;
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
    [Route("api/Ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {   

        private readonly IngredientCommandHandler _handler;
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientController(IngredientCommandHandler handler, IIngredientRepository ingredientRepository)
        {
            _handler = handler;
            _ingredientRepository = ingredientRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {   
            var ingredients = _ingredientRepository.GetActives();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var ingredient = _ingredientRepository.Get(id);
            return Ok(ingredient);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateIngredientCommand command)
        {   
            var result = _handler.Handler(command);
            return Ok(result);
        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateIngredientCommand command)
        {   
            var result = _handler.Handler(command);
            //return NoContent();
            return Ok(result);
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _handler.Handler(new DeleteIngredientCommand(id));
            //return NoContent();
            return Ok(result);
        }
    }
}
