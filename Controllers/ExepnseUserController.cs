using Budget_wars.Servies.User.Commands;
using Budget_wars.Servies.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Budget_wars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseUserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ExpenseUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //create expense user 
        //atributes
        [HttpPost]
        public async Task<IActionResult> create([FromBody]
    CreateUser.Command command)
        {
             return await _mediator.Send(command) switch
            {
                CreateUser.Response.Success { usermodel: var entity } =>
                CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity),
                _ => UnprocessableEntity()

            };
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            [FromRoute] int id
            )
        {
             var result = await _mediator.Send( new GetByIdExpenseUser.Query(id));

            return Ok(result);

        }
    }
}
