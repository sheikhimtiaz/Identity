using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MongoService _mongoService;

        public UsersController(MongoService bookService)
        {
            _mongoService = bookService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _mongoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<User> Get(string id)
        {
            var user = _mongoService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _mongoService.Create(user);

            return CreatedAtRoute("GetBook", new { id = user._id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var book = _mongoService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _mongoService.Update(id, UserIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _mongoService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _mongoService.Remove(book._id);

            return NoContent();
        }
    }
}