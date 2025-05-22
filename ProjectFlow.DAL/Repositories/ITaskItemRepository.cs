using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface ITaskItemRepository : IGenericRepository<TaskItem>
{
    Task<IEnumerable<TaskItem>> GetAllWithTagsAndProjectAsync();
    Task<TaskItem?> GetWithDetailsByIdAsync(int id);
}