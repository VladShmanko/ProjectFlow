namespace ProjectFlow.BLL.DTOs
{
    public class TaskItemCreateDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedById { get; set; }
        public int? ProjectId { get; set; }
    }
}
