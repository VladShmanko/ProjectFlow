using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
}