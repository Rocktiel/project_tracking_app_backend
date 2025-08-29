namespace MiniProject.Application.DTOs
{
     public class ProjectDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}