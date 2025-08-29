using System.ComponentModel.DataAnnotations;

namespace MiniProject.Persistence.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public required Project Project { get; set; }
    }
}