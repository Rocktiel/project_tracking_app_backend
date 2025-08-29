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
        public Task<IEnumerable<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Project?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Project> Add(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<Project?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Project?> Update(int id, Project project)
        {
            throw new NotImplementedException();
        }
    }
}