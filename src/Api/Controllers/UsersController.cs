using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.CreateUser.Request;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Commands.UpdateUser.Request;
using Application.Features.Users.Queries.GetUserById;
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
    public async Task<IActionResult> GetUsersAsync(
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException == null ? ex.Message : $"{ex.Message}: {ex.InnerException.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new CreateUserCommand(request);
            var user = await _mediator.Send(command, cancellationToken);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException == null ? ex.Message : $"{ex.Message}: {ex.InnerException.Message}");
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUserAsync(
        [FromBody] UpdateUserRequest request,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new UpdateUserCommand(id, request);
            var user = await _mediator.Send(command, cancellationToken);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException == null ? ex.Message : $"{ex.Message}: {ex.InnerException.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new DeleteUserCommand(id);
            var user = await _mediator.Send(command, cancellationToken);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException == null ? ex.Message : $"{ex.Message}: {ex.InnerException.Message}");
        }
    }
}
