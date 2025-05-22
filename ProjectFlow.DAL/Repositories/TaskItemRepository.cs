using Microsoft.EntityFrameworkCore;
using ProjectFlow.DAL.Data;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
{
    public TaskItemRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskItem>> GetAllWithTagsAndProjectAsync()
    {
        return await _dbSet
            .Include(t => t.Project)
            .Include(t => t.TaskItemTags)
            .ThenInclude(tt => tt.Tag)
            .Include(t => t.CreatedBy)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetWithDetailsByIdAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Project)
            .Include(t => t.TaskItemTags)
            .ThenInclude(tt => tt.Tag)
            .Include(t => t.CreatedBy)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}