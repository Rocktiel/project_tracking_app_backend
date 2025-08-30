using Microsoft.AspNetCore.Mvc;
using MiniProject.Application.DTOs;
using MiniProject.Application.Services;

namespace MiniProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        // Servis imp
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Bütün taskları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskService.GetAll();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Idye göre task getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _taskService.GetById(id);
                if (task == null) return NotFound($"Task with id {id} not found");
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Task ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTaskDto createTaskDto)
        {
            try
            {
                if (createTaskDto == null)
                    return BadRequest("Task data is required");

                var task = await _taskService.Add(createTaskDto);
                return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
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

        // Task sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedTask = await _taskService.Delete(id);
                if (deletedTask == null) return NotFound($"Task with id {id} not found");
                return Ok(deletedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] CreateTaskDto createTaskDto)
        // {
        //     var updatedTask = await _taskService.Update(id, createTaskDto);
        //     if (updatedTask == null) return NotFound();
        //     return Ok(updatedTask);
        // }

       
        // Task tamamlandı olarak işaretle
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateIsCompleted(int id)
        {
            try
            {
                var updatedTask = await _taskService.UpdateIsCompleted(id);
                if (updatedTask == null) return NotFound($"Task with id {id} not found");
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Proje Idye göre taskları getir
        [HttpGet("project/{projectId}")] 
        public async Task<IActionResult> GetByProjectId(int projectId)
        {
            try
            {
                var tasks = await _taskService.GetByProjectId(projectId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}