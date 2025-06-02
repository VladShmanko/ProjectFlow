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

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _unitOfWork.Projects.GetAllAsync();
        }

        public async Task<IEnumerable<Project>> GetAllWithDetailsAsync()
        {
            return await _unitOfWork.Projects.GetAllWithMembersAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Projects.GetByIdAsync(id);
        }

        public async Task<Project?> GetWithDetailsByIdAsync(int id)
        {
            return await _unitOfWork.Projects.GetProjectWithDetailsAsync(id);
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.SaveAsync();
            return project;
        }

        public async Task<bool> UpdateAsync(Project project)
        {
            var existing = await _unitOfWork.Projects.GetByIdAsync(project.Id);
            if (existing is null)
                return false;

            existing.Name = project.Name;
            existing.Description = project.Description;

            _unitOfWork.Projects.Update(existing);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project is null)
                return false;

            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
