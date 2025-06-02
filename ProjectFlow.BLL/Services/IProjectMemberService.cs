using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface IProjectMemberService
    {
        Task<IEnumerable<ProjectMember>> GetByUserIdAsync(string userId);
        Task<bool> IsUserMemberOfProjectAsync(string userId, int projectId);
        Task<ProjectMember> AddAsync(ProjectMember member);
        Task<bool> RemoveAsync(string userId, int projectId);
    }
}
