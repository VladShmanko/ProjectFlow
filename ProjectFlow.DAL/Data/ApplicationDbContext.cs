using Microsoft.EntityFrameworkCore;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectMember> ProjectMembers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TaskItemTag> TaskItemTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "alice", Email = "alice@example.com", Password = "pass1", Role = "User" },
            new User { Id = 2, Username = "bob", Email = "bob@example.com", Password = "pass2", Role = "User" },
            new User { Id = 3, Username = "charlie", Email = "charlie@example.com", Password = "pass3", Role = "Admin" },
            new User { Id = 4, Username = "dave", Email = "dave@example.com", Password = "pass4", Role = "User" },
            new User { Id = 5, Username = "eve", Email = "eve@example.com", Password = "pass5", Role = "User" }
        );
        
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Project A", Description = "Alpha project" },
            new Project { Id = 2, Name = "Project B", Description = "Beta project" },
            new Project { Id = 3, Name = "Project C", Description = "Gamma project" },
            new Project { Id = 4, Name = "Project D", Description = "Delta project" },
            new Project { Id = 5, Name = "Project E", Description = "Epsilon project" }
        );
        
        modelBuilder.Entity<Tag>().HasData(
            new Tag { Id = 1, Name = "Urgent" },
            new Tag { Id = 2, Name = "Bug" },
            new Tag { Id = 3, Name = "Feature" },
            new Tag { Id = 4, Name = "Low Priority" },
            new Tag { Id = 5, Name = "UI" }
        );
        
        modelBuilder.Entity<TaskItem>().HasData(
            new TaskItem
            {
                Id = 1,
                Title = "Setup repo",
                Description = "Initialize git repository",
                Status = "Pending",
                Priority = "Normal",
                CreatedById = 1,
                ProjectId = 1,
                CreatedAt = DateTime.UtcNow
            },
            new TaskItem
            {
                Id = 2,
                Title = "Design database",
                Description = "ER diagram for project",
                Status = "InProgress",
                Priority = "High",
                CreatedById = 2,
                ProjectId = 2,
                CreatedAt = DateTime.UtcNow
            },
            new TaskItem
            {
                Id = 3,
                Title = "Implement auth",
                Description = "Add JWT and Identity",
                Status = "Completed",
                Priority = "Critical",
                CreatedById = 3,
                ProjectId = 3,
                CreatedAt = DateTime.UtcNow
            },
            new TaskItem
            {
                Id = 4,
                Title = "Frontend UI",
                Description = "React + Tailwind layout",
                Status = "Pending",
                Priority = "Low",
                CreatedById = 4,
                ProjectId = 4,
                CreatedAt = DateTime.UtcNow
            },
            new TaskItem
            {
                Id = 5,
                Title = "Test cases",
                Description = "Unit + Integration tests",
                Status = "Archived",
                Priority = "Normal",
                CreatedById = 5,
                ProjectId = 5,
                CreatedAt = DateTime.UtcNow
            }
        );
        
        modelBuilder.Entity<ProjectMember>().HasData(
            new ProjectMember { UserId = 1, ProjectId = 1 },
            new ProjectMember { UserId = 2, ProjectId = 1 },
            new ProjectMember { UserId = 3, ProjectId = 2 },
            new ProjectMember { UserId = 4, ProjectId = 3 },
            new ProjectMember { UserId = 5, ProjectId = 4 }
        );
        
        modelBuilder.Entity<TaskItemTag>().HasData(
            new TaskItemTag { TaskItemId = 1, TagId = 2 },
            new TaskItemTag { TaskItemId = 1, TagId = 1 },
            new TaskItemTag { TaskItemId = 2, TagId = 3 },
            new TaskItemTag { TaskItemId = 3, TagId = 5 },
            new TaskItemTag { TaskItemId = 4, TagId = 4 }
        );
    }
}