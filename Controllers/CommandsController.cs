using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    //api/commands
    //[controller] will get substituted with the part of the class name that comes before controller.
    // So the controller's job in the MVC design pattern in C# ASP.NET is basically to convert data from a database to C# objects and allow those C# objects to travel across the internet as JSON objects.
    // It manages the server operations needed to allow clients to communicate with a database.
    // It also sets up the URI routes that clients can call to communicate with the server.
    // The 'language' (protocol) the client and server speak in is HTTP.
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        // Specify that this method listens for HTTP get requests.
        // The route for this endpoint is "domain.com/api/commands".
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems);
        }

        // Specify that this methods listens for HTTP get requests.
        // The route for this endpoint is "domain.com/api/commands/5".
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}
