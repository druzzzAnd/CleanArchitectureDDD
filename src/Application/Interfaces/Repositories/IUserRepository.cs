using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IUserRepository
{
    List<User>? GetAll();
    User? GetById(Guid id);
    void Create(User user);
    void Update(User user);
    void Delete(User user);
}
