namespace Application.Features.Users.Queries.GetUserById.Response;

public record GetUserByIdResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName);
