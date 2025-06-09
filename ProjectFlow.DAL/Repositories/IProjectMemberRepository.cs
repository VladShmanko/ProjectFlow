using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface IProjectMemberRepository : IGenericRepository<ProjectMember>
{
    Task<IEnumerable<ProjectMember>> GetByUserIdAsync(int userId);
    Task<bool> IsUserMemberOfProjectAsync(int userId, int projectId);
}