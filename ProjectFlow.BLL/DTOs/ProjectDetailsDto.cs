namespace ProjectFlow.BLL.DTOs
{
    public class ProjectDetailsDto : ProjectDto
    {
        public List<ProjectMemberDto> Members { get; set; } = new();
    }
}
