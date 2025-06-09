namespace ProjectFlow.BLL.DTOs
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
