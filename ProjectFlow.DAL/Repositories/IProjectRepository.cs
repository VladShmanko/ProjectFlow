using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface IProjectRepository : IGenericRepository<Project>
{
    Task<Project?> GetProjectWithDetailsAsync(int id);
    Task<IEnumerable<Project>> GetAllWithMembersAsync();
}