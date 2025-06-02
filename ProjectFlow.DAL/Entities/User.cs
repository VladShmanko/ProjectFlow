namespace ProjectFlow.DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } 
    public string Role { get; set; } = "User"; 
    
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<ProjectMember> ProjectMemberships { get; set; } = new List<ProjectMember>();
}