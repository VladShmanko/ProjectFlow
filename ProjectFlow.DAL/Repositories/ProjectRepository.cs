using Microsoft.EntityFrameworkCore;
using ProjectFlow.DAL.Data;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Project?> GetProjectWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Members)
            .ThenInclude(pm => pm.User)
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Project>> GetAllWithMembersAsync()
    {
        return await _dbSet
            .Include(p => p.Members)
            .ThenInclude(pm => pm.User)
            .ToListAsync();
    }
}