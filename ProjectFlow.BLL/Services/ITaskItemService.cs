using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemDto>> GetAllAsync();
        Task<TaskItemDto?> GetByIdAsync(int id);
        Task<TaskItemDto> CreateAsync(TaskItemCreateDto dto);
        Task<bool> UpdateAsync(TaskItemUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
