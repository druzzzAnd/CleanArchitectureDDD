namespace Application.Features.Users.Queries.GetUsers.Response;

public record GetUsersResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastaName);
