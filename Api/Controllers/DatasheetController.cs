using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Handlers;
using Domain.Commands.DatasheetCommands;
using Domain.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Datasheet")]
    public class DatasheetController : ControllerBase
    {
        private readonly DatasheetCommandHandler _handler;
        private readonly DatasheetItemCommandHandler _itemHandler;
        private readonly IDatasheetRepository _datasheetRepository;
        private readonly IDatasheetItemRepository _itemRepository;
        public DatasheetController(DatasheetCommandHandler handler,
            IDatasheetRepository datasheetRepository,
            DatasheetItemCommandHandler itemHandler,
            IDatasheetItemRepository itemRepository)
        {
            _handler = handler;
            _datasheetRepository = datasheetRepository;
            _itemHandler = itemHandler;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var datasheets = _datasheetRepository.Get();
            return Ok(datasheets);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var datasheet = _datasheetRepository.Get(id);
            return Ok(datasheet);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddDatasheetCommand command)
        {
            var result = _handler.Handler(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateDatasheetCommand command)
        {
            var result = _handler.Handler(command);
            return Ok(result);
        }
    }
}