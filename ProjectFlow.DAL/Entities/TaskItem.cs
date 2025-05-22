namespace ProjectFlow.DAL.Entities;

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public string CreatedById { get; set; }              
        public User CreatedBy { get; set; }
        
        public int? ProjectId { get; set; }                    
        public Project? Project { get; set; }
        
        public ICollection<TaskItemTag> TaskItemTags { get; set; } = new List<TaskItemTag>();
    }