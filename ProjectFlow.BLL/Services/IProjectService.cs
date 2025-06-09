using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<IEnumerable<ProjectDetailsDto>> GetAllWithDetailsAsync();
        Task<ProjectDto?> GetByIdAsync(int id);
        Task<ProjectDetailsDto?> GetWithDetailsByIdAsync(int id);
        Task<ProjectDto> CreateAsync(CreateProjectDto dto);
        Task<bool> UpdateAsync(UpdateProjectDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
