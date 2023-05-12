// UserController.cs

using Microsoft.AspNetCore.Mvc;
using AccountManagement.Models;
using AccountManagement.Services;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace AccountManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreationDto userCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userService.CreateUser(userCreationDto);

            //Can be replaced by a DTO, based on the usage need of this API
            //To avoid An item with the same key has already been added error
            var jsonResult = JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            });

            return Ok(jsonResult);
        }


        [HttpGet("users/{customerId}")]
        public IActionResult GetUserInformation(string customerId)
        {
            var userInformation = _userService.GetUserInformation(customerId);

            if (userInformation == null)
            {
                return NotFound();
            }

            return Ok(userInformation);
        }



    }
}
