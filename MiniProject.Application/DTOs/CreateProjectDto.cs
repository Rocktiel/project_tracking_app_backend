namespace MiniProject.Application.DTOs
{
    public class CreateProjectDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}