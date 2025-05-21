namespace ProjectFlow.DAL.Entities;

public class ProjectMember
{
    public string UserId { get; set; }
    public User User { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}