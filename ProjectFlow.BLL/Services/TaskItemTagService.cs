using ProjectFlow.DAL.Entities;
using ProjectFlow.DAL.Repositories;

namespace ProjectFlow.BLL.Services
{
    public class TaskItemTagService : ITaskItemTagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskItemTagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaskItemTag>> GetByTaskItemIdAsync(int taskItemId)
        {
            return await _unitOfWork.TaskItemTags.GetByTaskItemIdAsync(taskItemId);
        }

        public async Task<IEnumerable<TaskItemTag>> GetByTagIdAsync(int tagId)
        {
            return await _unitOfWork.TaskItemTags.GetByTagIdAsync(tagId);
        }

        public async Task<TaskItemTag> AddAsync(TaskItemTag entity)
        {
            await _unitOfWork.TaskItemTags.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int taskItemId, int tagId)
        {
            var taskItemTag = await _unitOfWork.TaskItemTags
                .FindAsync(t => t.TaskItemId == taskItemId && t.TagId == tagId);

            if (taskItemTag == null)
                return false;

            _unitOfWork.TaskItemTags.Delete(taskItemTag);
            await _unitOfWork.SaveAsync();
            return true;
        }

    }
}
