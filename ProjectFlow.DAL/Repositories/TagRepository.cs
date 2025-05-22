using Microsoft.EntityFrameworkCore;
using ProjectFlow.DAL.Data;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Tag?> GetByNameAsync(string name)
    {
        return await _dbSet
            .FirstOrDefaultAsync(t => t.Name == name);
    }
}