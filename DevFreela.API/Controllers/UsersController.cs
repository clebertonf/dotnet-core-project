using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if(user is null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUserInputModel)
        {
            var userCreated = _userService.Create(createUserInputModel);

            return CreatedAtAction(nameof(GetById), new { id = 1}, createUserInputModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, LoginModel loginModel)
        {
            // Implementação será Feita na parte de autenticação e autorização
            return NoContent();
        }
    }
}
