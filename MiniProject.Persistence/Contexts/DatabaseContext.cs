using Microsoft.EntityFrameworkCore;

namespace MiniProject.Persistence.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
    }
}