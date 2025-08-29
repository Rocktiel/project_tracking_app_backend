using Task = MiniProject.Persistence.Entities.Task;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniProject.Application.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAll();
        Task<Task> GetById(int id);
        Task<Task> Add(Task task);
        Task<Task?> Update(int id, Task task);
        Task<Task?> Delete(int id);
    }
}