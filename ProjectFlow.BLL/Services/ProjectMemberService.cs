using ProjectFlow.BLL.DTOs;
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

        public async Task<IEnumerable<ProjectMemberDto>> GetByUserIdAsync(int userId)
        {
            var members = await _unitOfWork.ProjectMembers.GetByUserIdAsync(userId);
            return members.Select(m => new ProjectMemberDto
            {
                UserId = m.UserId,
                ProjectId = m.ProjectId
            });
        }

        public async Task<bool> IsUserMemberOfProjectAsync(int userId, int projectId)
        {
            return await _unitOfWork.ProjectMembers.IsUserMemberOfProjectAsync(userId, projectId);
        }

        public async Task<ProjectMemberDto> AddAsync(ProjectMemberDto memberDto)
        {
            var member = new ProjectMember
            {
                UserId = memberDto.UserId,
                ProjectId = memberDto.ProjectId
            };

            await _unitOfWork.ProjectMembers.AddAsync(member);
            await _unitOfWork.SaveAsync();

            return memberDto;
        }

        public async Task<bool> RemoveAsync(int userId, int projectId)
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
