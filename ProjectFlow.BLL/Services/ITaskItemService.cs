using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<IEnumerable<TaskItem>> GetAllWithDetailsAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem?> GetWithDetailsByIdAsync(int id);
        Task<TaskItem> CreateAsync(TaskItem taskItem);
        Task<bool> UpdateAsync(TaskItem taskItem);
        Task<bool> DeleteAsync(int id);
    }
}
