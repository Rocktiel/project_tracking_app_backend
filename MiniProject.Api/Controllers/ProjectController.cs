using Microsoft.AspNetCore.Mvc;
using MiniProject.Application.DTOs;
using MiniProject.Application.Services;
using MiniProject.Persistence.Entities;


namespace MiniProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetById(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProjectDto createProjectDto)
        {
            var project = await _projectService.Add(createProjectDto);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedProject = await _projectService.Delete(id);
            if (deletedProject == null) return NotFound();
            return Ok(deletedProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Project project)
        {
            var updatedProject = await _projectService.Update(id, project);
            if (updatedProject == null) return NotFound();
            return Ok(updatedProject);
        }
    }
}