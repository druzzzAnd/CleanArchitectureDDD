namespace Application.Features.Users.Commands.CreateUser.Request;

public record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName);
