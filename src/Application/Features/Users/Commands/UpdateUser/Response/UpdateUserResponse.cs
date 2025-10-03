namespace Application.Features.Users.Commands.UpdateUser.Response;

public record UpdateUserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName);
