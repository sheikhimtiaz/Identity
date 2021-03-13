using System.Collections.Generic;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IIdentityRepo _repository;

        public CommandsController(IIdentityRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult <User> GetCommandById(int ItemId)
        {
            var commandItem = _repository.GetCommandById(ItemId);

            return Ok(commandItem);
        }
    }
}