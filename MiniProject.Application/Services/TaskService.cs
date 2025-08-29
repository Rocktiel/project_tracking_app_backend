using MiniProject.Persistence.Repositories;
using Task = MiniProject.Persistence.Entities.Task;
using MiniProject.Application.DTOs;

namespace MiniProject.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<TaskDto>> GetAll()
        {
            var tasks = await _taskRepository.GetAll();

            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
                ProjectId = t.ProjectId
            });
        }

        public async Task<TaskDto?> GetById(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return null;
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted,
                ProjectId = task.ProjectId
            };
        }
        public async Task<TaskDto> Add(CreateTaskDto createTaskDto)
        {
            var task = new Task
            {
                Title = createTaskDto.Title,
                IsCompleted = false,
                ProjectId = createTaskDto.ProjectId
            };
            await _taskRepository.Add(task);

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted,
                ProjectId = task.ProjectId
            };
        }

         public async Task<TaskDto?> Delete(int id)
    {
        var deletedTask = await _taskRepository.Delete(id);
        if (deletedTask == null) return null;

        return new TaskDto
        {
            Id = deletedTask.Id,
            Title = deletedTask.Title,
            IsCompleted = deletedTask.IsCompleted,
            ProjectId = deletedTask.ProjectId
        };
    }

    public async Task<TaskDto?> Update(int id, Task task)
    {
        var updatedTask = await _taskRepository.Update(id, task);
        if (updatedTask == null) return null;

        return new TaskDto
        {
            Id = updatedTask.Id,
            Title = updatedTask.Title,
            IsCompleted = updatedTask.IsCompleted,
            ProjectId = updatedTask.ProjectId
        };
    }

    public async Task<TaskDto?> UpdateIsCompleted(int id, bool isCompleted)
    {
        var updatedTask = await _taskRepository.UpdateIsCompleted(id, isCompleted);
        if (updatedTask == null) return null;

        return new TaskDto
        {
            Id = updatedTask.Id,
            Title = updatedTask.Title,
            IsCompleted = updatedTask.IsCompleted,
            ProjectId = updatedTask.ProjectId
        };
    }

        public async Task<IEnumerable<TaskDto>> GetByProjectId(int projectId)
        {
            var tasks = await _taskRepository.GetByProjectId(projectId);

            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
                ProjectId = t.ProjectId
            });
        }
    }
}