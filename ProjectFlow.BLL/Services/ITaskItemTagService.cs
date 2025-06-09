using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface ITaskItemTagService
    {
        Task<IEnumerable<TaskItemTagDto>> GetByTaskItemIdAsync(int taskItemId);
        Task<IEnumerable<TaskItemTagDto>> GetByTagIdAsync(int tagId);
        Task<TaskItemTagDto> AddAsync(TaskItemTagCreateDto dto);
        Task<bool> DeleteAsync(int taskItemId, int tagId);
    }
}
