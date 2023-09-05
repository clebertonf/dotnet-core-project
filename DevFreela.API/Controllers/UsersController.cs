using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var userById = await _mediator.Send(query);

            if (userById is null)
            {
                return BadRequest();
            }

            return Ok(userById);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserInputModel command)
        {
            var id = await _mediator.Send(command);

             return CreatedAtAction(nameof(GetById), new { id = 1}, command);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, LoginModel loginModel)
        {
            // Implementação será Feita na parte de autenticação e autorização
            return NoContent();
        }
    }
}
