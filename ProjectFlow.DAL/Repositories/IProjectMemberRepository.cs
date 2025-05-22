using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface IProjectMemberRepository : IGenericRepository<ProjectMember>
{
    Task<IEnumerable<ProjectMember>> GetByUserIdAsync(string userId);
    Task<bool> IsUserMemberOfProjectAsync(string userId, int projectId);
}