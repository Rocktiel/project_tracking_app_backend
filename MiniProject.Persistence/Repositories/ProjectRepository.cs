using Microsoft.EntityFrameworkCore;
using MiniProject.Persistence.Contexts;
using MiniProject.Persistence.Entities;

namespace MiniProject.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseContext _context;
        public ProjectRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project?> Delete(int id)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);

            if (projectToDelete == null)
            {
                return null;
            }

            _context.Projects.Remove(projectToDelete);
            await _context.SaveChangesAsync();

            return projectToDelete;
        }



        public async Task<Project?> Update(int id, Project project)
        {
            var projectToUpdate = await _context.Projects.FindAsync(id);

            if (projectToUpdate == null)
            {
                return null;
            }

            projectToUpdate.Name = project.Name;
            projectToUpdate.Description = project.Description;
            
            await _context.SaveChangesAsync();

            return projectToUpdate;
        }
    }
}