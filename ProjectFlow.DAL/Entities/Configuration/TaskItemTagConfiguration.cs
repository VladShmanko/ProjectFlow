using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectFlow.DAL.Entities.Configuration;

public class TaskItemTagConfiguration : IEntityTypeConfiguration<TaskItemTag>
{
    public void Configure(EntityTypeBuilder<TaskItemTag> builder)
    {
        builder.HasKey(tt => new { tt.TaskItemId, tt.TagId });

        builder.HasOne(tt => tt.TaskItem)
            .WithMany(t => t.TaskItemTags)
            .HasForeignKey(tt => tt.TaskItemId);

        builder.HasOne(tt => tt.Tag)
            .WithMany(t => t.TaskItemTags)
            .HasForeignKey(tt => tt.TagId);
    }
}