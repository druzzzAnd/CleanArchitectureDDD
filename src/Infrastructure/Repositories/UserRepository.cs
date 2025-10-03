using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories;

public class UserRepository(PostgreDbContext context) : IUserRepository
{
    public void Create(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public List<User>? GetAll()
    {
        return context.Users.ToList();
    }

    public User? GetById(Guid id)
    {
        return context.Users.FirstOrDefault(f => f.Id == id);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
        context.SaveChanges();
    }

    public void Delete(User user)
    {
        context.Remove(user);
        context.SaveChanges();
    }
}
