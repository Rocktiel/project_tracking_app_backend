using MiniProject.Persistence.Entities;
using Task = System.Threading.Tasks.Task;

namespace MiniProject.Persistence.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project?> GetById(int id);
        Task<Project> Add(Project project);
        Task<Project?> Update(int id, Project project);
        Task<Project?> Delete(int id);
    }
}