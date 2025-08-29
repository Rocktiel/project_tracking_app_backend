using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Task>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Task?> GetById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        public async Task<Task> Add(Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task?> Delete(int id)
        {
            var taskToDelete =  await _context.Tasks.FindAsync(id);
            if (taskToDelete == null)
            {
                return null;
            }
            _context.Tasks.Remove(taskToDelete);
            await _context.SaveChangesAsync();
            return taskToDelete;
        }

        public async Task<Task?> Update(int id, Task task)
        {
            var taskToUpdate = await _context.Tasks.FindAsync(id);
            if (taskToUpdate == null)
            {
                return null;
            }

           
            taskToUpdate.IsCompleted = task.IsCompleted;
            await _context.SaveChangesAsync();
            return taskToUpdate;
        }

        public async Task<Task?> UpdateIsCompleted(int id)
        {
            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null) return null;

            existingTask.IsCompleted = true;

            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<IEnumerable<Task>> GetByProjectId(int projectId)
        {
             return await _context.Tasks
                             .Where(t => t.ProjectId == projectId)
                             .ToListAsync();
        }
    }
}