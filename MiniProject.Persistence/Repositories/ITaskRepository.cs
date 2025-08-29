using Task = MiniProject.Persistence.Entities.Task;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniProject.Persistence.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAll();
        Task<Task?> GetById(int id);
        Task<Task> Add(Task task);
        Task<Task?> Update(int id, Task task);
        Task<Task?> Delete(int id);

        Task<Task?> UpdateIsCompleted(int id);

        Task<IEnumerable<Task>> GetByProjectId(int projectId);
    }
}