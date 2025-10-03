using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query, cancellationToken);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException == null ? ex.Message : $"{ex.Message}: {ex.InnerException.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var user = await _mediator.Send(command, cancellationToken);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException == null ? ex.Message : $"{ex.Message}: {ex.InnerException.Message}");
        }
    }
}
