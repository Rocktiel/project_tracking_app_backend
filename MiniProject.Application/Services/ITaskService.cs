using Task = MiniProject.Persistence.Entities.Task;
using System.Threading.Tasks;
using System.Collections.Generic;
using MiniProject.Application.DTOs;

namespace MiniProject.Application.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAll();
        Task<TaskDto?> GetById(int id);
        Task<TaskDto> Add(CreateTaskDto createTaskDto);
        Task<TaskDto?> Update(int id, Task task);
        Task<TaskDto?> Delete(int id);
        Task<TaskDto?> UpdateIsCompleted(int id);
        Task<IEnumerable<TaskDto>> GetByProjectId(int projectId);
    }
}