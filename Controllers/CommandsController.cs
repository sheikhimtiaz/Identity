using System.Collections.Generic;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Ah, there you are!");

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;

            Log.Information("Processed {@Position} in {Elapsed:000} ms. \n {@commandItems}", position, elapsedMs, commandItems);
            Log.CloseAndFlush();

            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult <User> GetCommandById(int itemId)
        {
            var commandItem = _repository.GetCommandById(itemId);

            return Ok(commandItem);
        }
    }
}