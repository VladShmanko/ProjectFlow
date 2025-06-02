using ProjectFlow.DAL.Entities;
using ProjectFlow.DAL.Repositories;

namespace ProjectFlow.BLL.Services
{
    public class ProjectMemberService : IProjectMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectMember>> GetByUserIdAsync(string userId)
        {
            return await _unitOfWork.ProjectMembers.GetByUserIdAsync(userId);
        }

        public async Task<bool> IsUserMemberOfProjectAsync(string userId, int projectId)
        {
            return await _unitOfWork.ProjectMembers.IsUserMemberOfProjectAsync(userId, projectId);
        }

        public async Task<ProjectMember> AddAsync(ProjectMember member)
        {
            await _unitOfWork.ProjectMembers.AddAsync(member);
            await _unitOfWork.SaveAsync();
            return member;
        }

        public async Task<bool> RemoveAsync(string userId, int projectId)
        {
            var members = await _unitOfWork.ProjectMembers.GetByUserIdAsync(userId);
            var memberToRemove = members.FirstOrDefault(m => m.ProjectId == projectId);

            if (memberToRemove == null)
                return false;

            _unitOfWork.ProjectMembers.Delete(memberToRemove);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
