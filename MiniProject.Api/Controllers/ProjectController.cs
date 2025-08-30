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
        // Servis imp
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // Bütün projeleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projects = await _projectService.GetAll();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Idye göre proje getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           try
            {
                var project = await _projectService.GetById(id);
                if (project == null) return NotFound($"Project with id {id} not found");
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Proje ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProjectDto createProjectDto)
        {
            try
            {
                if (createProjectDto == null)
                    return BadRequest("Project data is required");

                var project = await _projectService.Add(createProjectDto);
                return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Proje sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                var deletedProject = await _projectService.Delete(id);
                if (deletedProject == null) return NotFound($"Project with id {id} not found");
                return Ok(deletedProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Proje güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Project project)
        {
            try
            {
                if (project == null)
                    return BadRequest("Project data is required");

                var updatedProject = await _projectService.Update(id, project);
                if (updatedProject == null) return NotFound($"Project with id {id} not found");
                return Ok(updatedProject);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}