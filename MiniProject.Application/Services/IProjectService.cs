using MiniProject.Application.DTOs;
using MiniProject.Persistence.Entities;

namespace MiniProject.Application.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<ProjectDto?> GetById(int id);
        Task<ProjectDto> Add(CreateProjectDto createProjectDto);
        Task<ProjectDto?> Update(int id, Project project);
        Task<ProjectDto?> Delete(int id);
    }
}