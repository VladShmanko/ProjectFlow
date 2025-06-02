using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface ITaskItemTagService
    {
        Task<IEnumerable<TaskItemTag>> GetByTaskItemIdAsync(int taskItemId);
        Task<IEnumerable<TaskItemTag>> GetByTagIdAsync(int tagId);
        Task<TaskItemTag> AddAsync(TaskItemTag entity);
        Task<bool> DeleteAsync(int taskItemId, int tagId);
    }
}
