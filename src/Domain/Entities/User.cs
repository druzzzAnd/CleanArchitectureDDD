using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public User(string email, string firstName, string lastName)
        : base()
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public void Update(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
