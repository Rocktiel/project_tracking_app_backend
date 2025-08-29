using System.ComponentModel.DataAnnotations;

namespace MiniProject.Persistence.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}