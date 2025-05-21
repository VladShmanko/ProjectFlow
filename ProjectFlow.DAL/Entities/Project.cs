namespace ProjectFlow.DAL.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<ProjectMember> Members { get; set; } = new List<ProjectMember>();
}