using MiniProject.Application.DTOs;
using MiniProject.Persistence.Entities;
using MiniProject.Persistence.Repositories;

namespace MiniProject.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            var projects = await _projectRepository.GetAll();
            
            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            });
        }

        public async Task<ProjectDto?> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null) return null;
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }
        public async Task<ProjectDto> Add(CreateProjectDto createProjectDto)
        {
            var project = new Project
            {

                Name = createProjectDto.Name,
                Description = createProjectDto.Description,
            };
             await _projectRepository.Add(project);

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public async Task<ProjectDto?> Delete(int id)
        {
            var deletedProject = await _projectRepository.Delete(id);
            if (deletedProject == null) return null;
            return new ProjectDto
            {
                Id = deletedProject.Id,
                Name = deletedProject.Name,
                Description = deletedProject.Description
            };
        }



        public async Task<ProjectDto?> Update(int id, Project project)
        {
            var updatedProject = await _projectRepository.Update(id, project);
            if (updatedProject == null) return null;
            return new ProjectDto
            {
                Id = updatedProject.Id,
                Name = updatedProject.Name,
                Description = updatedProject.Description
            };
        }
    }
}