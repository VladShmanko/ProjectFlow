using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface ITaskItemTagRepository : IGenericRepository<TaskItemTag>
{
    Task<IEnumerable<TaskItemTag>> GetByTaskItemIdAsync(int taskItemId);
    Task<IEnumerable<TaskItemTag>> GetByTagIdAsync(int tagId);
}