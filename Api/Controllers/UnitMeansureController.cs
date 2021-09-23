using Domain.Commands.UnitMeansureCommands;
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
    [Route("api/UnitMeansure")]
    [ApiController]
    public class UnitMeansureController : ControllerBase
    {   

        private readonly UnitMeansureCommandHandler _handler;
        private readonly IUnitMeansureRepository _unitMeansureRepository;
        public UnitMeansureController(UnitMeansureCommandHandler handler, IUnitMeansureRepository unitMeansureRepository)
        {
            _handler = handler;
            _unitMeansureRepository = unitMeansureRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {   
            var unitMeasures = _unitMeansureRepository.GetActives();
            return Ok(unitMeasures);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var unitMeansure = _unitMeansureRepository.Get(id);
            return Ok(unitMeansure);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUnitMeansureCommand command)
        {   
            var result = _handler.Handler(command);
            return Ok(result);
        }

        // PUT api/<UnitMeansureController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateUnitMeansureCommand command)
        {   
            var result = _handler.Handler(command);
            //return NoContent();
            return Ok(result);
        }

        // DELETE api/<UnitMeansureController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _handler.Handler(new DeleteUnitMeansureCommand(id));
            //return NoContent();
            return Ok(result);
        }
    }
}
