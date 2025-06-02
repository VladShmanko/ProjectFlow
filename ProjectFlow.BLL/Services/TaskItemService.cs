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

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _unitOfWork.Tasks.GetAllAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllWithDetailsAsync()
        {
            return await _unitOfWork.Tasks.GetAllWithTagsAndProjectAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Tasks.GetByIdAsync(id);
        }

        public async Task<TaskItem?> GetWithDetailsByIdAsync(int id)
        {
            return await _unitOfWork.Tasks.GetWithDetailsByIdAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem taskItem)
        {
            await _unitOfWork.Tasks.AddAsync(taskItem);
            await _unitOfWork.SaveAsync();
            return taskItem;
        }

        public async Task<bool> UpdateAsync(TaskItem taskItem)
        {
            var existing = await _unitOfWork.Tasks.GetByIdAsync(taskItem.Id);
            if (existing is null)
                return false;

            existing.Title = taskItem.Title;
            existing.Description = taskItem.Description;
            existing.Status = taskItem.Status;
            existing.Priority = taskItem.Priority;
            existing.DueDate = taskItem.DueDate;
            existing.ProjectId = taskItem.ProjectId;

            _unitOfWork.Tasks.Update(existing);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taskItem = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (taskItem is null)
                return false;

            _unitOfWork.Tasks.Delete(taskItem);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
