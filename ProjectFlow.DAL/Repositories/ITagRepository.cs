using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetByNameAsync(string name);
}