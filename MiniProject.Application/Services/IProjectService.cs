using MiniProject.Persistence.Entities;

namespace MiniProject.Application.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project?> GetById(int id);
        Task<Project> Add(Project project);
        Task<Project?> Update(int id, Project project);
        Task<Project?> Delete(int id);
    }
}