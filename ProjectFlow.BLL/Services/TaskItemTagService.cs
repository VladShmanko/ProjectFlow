using ProjectFlow.BLL.DTOs;
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

        public async Task<IEnumerable<TaskItemTagDto>> GetByTaskItemIdAsync(int taskItemId)
        {
            var entities = await _unitOfWork.TaskItemTags.GetByTaskItemIdAsync(taskItemId);
            return entities.Select(e => new TaskItemTagDto
            {
                TaskItemId = e.TaskItemId,
                TagId = e.TagId,
                TagName = e.Tag.Name 
            });
        }
        public async Task<IEnumerable<TaskItemTagDto>> GetByTagIdAsync(int tagId)
        {
            var entities = await _unitOfWork.TaskItemTags.GetByTagIdAsync(tagId);
            return entities.Select(e => new TaskItemTagDto
            {
                TaskItemId = e.TaskItemId,
                TagId = e.TagId,
                TagName = e.Tag.Name
            });
        }

        public async Task<TaskItemTagDto> AddAsync(TaskItemTagCreateDto dto)
        {
            var entity = new TaskItemTag
            {
                TaskItemId = dto.TaskItemId,
                TagId = dto.TagId
            };

            await _unitOfWork.TaskItemTags.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            return new TaskItemTagDto
            {
                TaskItemId = entity.TaskItemId,
                TagId = entity.TagId
            };
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
