using ProjectFlow.DAL.Data;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IUserRepository Users { get; }
    public ITaskItemRepository Tasks { get; }
    public IProjectRepository Projects { get; }
    public IProjectMemberRepository ProjectMembers { get; }
    public ITagRepository Tags { get; }
    public ITaskItemTagRepository TaskItemTags { get; }
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Tasks = new TaskItemRepository(context);
        Projects = new ProjectRepository(context);
        ProjectMembers = new ProjectMemberRepository(context);
        Tags = new TagRepository(context);
        TaskItemTags = new TaskItemTagRepository(context);
    }
    
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}