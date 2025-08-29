using Task = MiniProject.Persistence.Entities.Task;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniProject.Persistence.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAll();
        Task<Task?> GetById(int id);
        Task<Task> Add(Task project);
        Task<Task?> Update(int id, Task project);
        Task<Task?> Delete(int id);
    }
}