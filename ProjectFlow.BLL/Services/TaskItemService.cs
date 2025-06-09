using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;
using ProjectFlow.DAL.Repositories;

namespace ProjectFlow.BLL.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();

            return tasks.Select(t => new TaskItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                DueDate = t.DueDate,
                CreatedAt = t.CreatedAt,
                CreatedById = t.CreatedById,
                ProjectId = t.ProjectId
            });
        }

        public async Task<TaskItemDto?> GetByIdAsync(int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null)
                return null;

            return new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
                CreatedById = task.CreatedById,
                ProjectId = task.ProjectId
            };
        }

        public async Task<TaskItemDto> CreateAsync(TaskItemCreateDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                Priority = dto.Priority,
                DueDate = dto.DueDate,
                CreatedById = dto.CreatedById,
                ProjectId = dto.ProjectId
            };

            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveAsync();

            return new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
                CreatedById = task.CreatedById,
                ProjectId = task.ProjectId
            };
        }

        public async Task<bool> UpdateAsync(TaskItemUpdateDto dto)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(dto.Id);
            if (task == null)
                return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.Priority = dto.Priority;
            task.DueDate = dto.DueDate;
            task.ProjectId = dto.ProjectId;

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null)
                return false;

            _unitOfWork.Tasks.Delete(task);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
