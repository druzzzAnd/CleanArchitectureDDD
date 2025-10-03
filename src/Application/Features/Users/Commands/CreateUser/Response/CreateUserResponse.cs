namespace Application.Features.Users.Commands.CreateUser.Response;

public record CreateUserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastaName);
