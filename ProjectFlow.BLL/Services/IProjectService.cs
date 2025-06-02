using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<IEnumerable<Project>> GetAllWithDetailsAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<Project?> GetWithDetailsByIdAsync(int id);
        Task<Project> CreateAsync(Project project);
        Task<bool> UpdateAsync(Project project);
        Task<bool> DeleteAsync(int id);
    }
}
