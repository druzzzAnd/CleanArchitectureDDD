namespace Application.Events.Users.CreateUser;

public record CreateUserEvent(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    DateTime CreatedAt,
    DateTime UpdatedAt);
