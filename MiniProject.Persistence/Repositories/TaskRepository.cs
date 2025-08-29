using MiniProject.Persistence.Contexts;
using MiniProject.Persistence.Entities;
using Task = MiniProject.Persistence.Entities.Task;

namespace MiniProject.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _context;
        public TaskRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Task>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Task?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Task> Add(Task project)
        {
            throw new NotImplementedException();
        }

        public Task<Task?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Task?> Update(int id, Task project)
        {
            throw new NotImplementedException();
        }
    }
}