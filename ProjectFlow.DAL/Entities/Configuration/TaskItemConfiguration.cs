using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectFlow.DAL.Entities.Configuration;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Description)
            .HasMaxLength(1000);

        builder.Property(t => t.Status)
            .IsRequired();

        builder.Property(t => t.Priority)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.HasOne(t => t.CreatedBy)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.CreatedById)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId);

        builder.HasMany(t => t.TaskItemTags)
            .WithOne(tt => tt.TaskItem)
            .HasForeignKey(tt => tt.TaskItemId);
        
        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_TaskItem_Status", "[Status] IN ('Pending', 'InProgress', 'Completed', 'Archived')");
            t.HasCheckConstraint("CK_TaskItem_Priority", "[Priority] IN ('Low', 'Normal', 'High', 'Critical')");
        });
    }
}