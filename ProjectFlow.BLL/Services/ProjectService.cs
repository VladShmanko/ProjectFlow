using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;
using ProjectFlow.DAL.Repositories;

namespace ProjectFlow.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            });
        }

        public async Task<IEnumerable<ProjectDetailsDto>> GetAllWithDetailsAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllWithMembersAsync();

            return projects.Select(p => new ProjectDetailsDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Members = p.Members.Select(m => new ProjectMemberDto
                {
                    UserId = m.UserId,
                    ProjectId = m.ProjectId
                }).ToList()
            });
        }

        public async Task<ProjectDto?> GetByIdAsync(int id)
        {
            var p = await _unitOfWork.Projects.GetByIdAsync(id);
            if (p is null) return null;

            return new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            };
        }

        public async Task<ProjectDetailsDto?> GetWithDetailsByIdAsync(int id)
        {
            var p = await _unitOfWork.Projects.GetProjectWithDetailsAsync(id);
            if (p is null) return null;

            return new ProjectDetailsDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Members = p.Members.Select(m => new ProjectMemberDto
                {
                    UserId = m.UserId,
                    ProjectId = m.ProjectId
                }).ToList()
            };
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveAsync();

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public async Task<bool> UpdateAsync(UpdateProjectDto dto)
        {
            var existing = await _unitOfWork.Projects.GetByIdAsync(dto.Id);
            if (existing is null) return false;

            existing.Name = dto.Name;
            existing.Description = dto.Description;

            _unitOfWork.Projects.Update(existing);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project is null) return false;

            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
