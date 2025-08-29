
using MiniProject.Persistence.Repositories;

namespace MiniProject.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public Task<IEnumerable<Persistence.Entities.Task>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Persistence.Entities.Task> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Persistence.Entities.Task> Add(Persistence.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<Persistence.Entities.Task?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Persistence.Entities.Task?> Update(int id, Persistence.Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}