using Microsoft.EntityFrameworkCore;
using ProjectFlow.DAL.Data;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public class ProjectMemberRepository : GenericRepository<ProjectMember>, IProjectMemberRepository
{
    public ProjectMemberRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProjectMember>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Include(pm => pm.Project)
            .Where(pm => pm.UserId == userId)
            .ToListAsync();
    }

    public async Task<bool> IsUserMemberOfProjectAsync(int userId, int projectId)
    {
        return await _dbSet
            .AnyAsync(pm => pm.UserId == userId && pm.ProjectId == projectId);
    }
}