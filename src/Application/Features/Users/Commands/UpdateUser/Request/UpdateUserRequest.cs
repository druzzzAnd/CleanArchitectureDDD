namespace Application.Features.Users.Commands.UpdateUser.Request;

public record UpdateUserRequest(
    string Email,
    string FirstName,
    string LastName);
