using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    ITaskItemRepository Tasks { get; }
    IProjectRepository Projects { get; }
    IProjectMemberRepository ProjectMembers { get; }
    ITagRepository Tags { get; }
    ITaskItemTagRepository TaskItemTags { get; }

    Task<int> SaveAsync();
}