using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public User() { }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

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
