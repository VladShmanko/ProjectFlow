using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface IProjectMemberService
    {
        Task<IEnumerable<ProjectMemberDto>> GetByUserIdAsync(int userId);
        Task<bool> IsUserMemberOfProjectAsync(int userId, int projectId);
        Task<ProjectMemberDto> AddAsync(ProjectMemberDto memberDto);
        Task<bool> RemoveAsync(int userId, int projectId);
    }
}
