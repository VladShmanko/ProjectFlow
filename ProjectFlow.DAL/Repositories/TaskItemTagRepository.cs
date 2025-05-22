using Microsoft.EntityFrameworkCore;
using ProjectFlow.DAL.Data;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public class TaskItemTagRepository : GenericRepository<TaskItemTag>, ITaskItemTagRepository
{
    public TaskItemTagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskItemTag>> GetByTaskItemIdAsync(int taskItemId)
    {
        return await _dbSet
            .Where(t => t.TaskItemId == taskItemId)
            .Include(t => t.TaskItem)
            .Include(t => t.Tag)
            .ToListAsync();
    }

    public async Task<IEnumerable<TaskItemTag>> GetByTagIdAsync(int tagId)
    {
        return await _dbSet
            .Where(t => t.TagId == tagId)
            .Include(t => t.TaskItem)
            .Include(t => t.Tag)
            .ToListAsync();
    }
}