namespace MiniProject.Application.DTOs
{
    public class CreateTaskDto
    {
        public required string Title { get; set; }
        public int ProjectId { get; set; }
    }
}