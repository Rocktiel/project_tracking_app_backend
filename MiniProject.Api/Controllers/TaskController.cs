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
            var tasks = await _taskService.GetAll();
            return Ok(tasks);
        }

        // Idye göre task getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // Task ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTaskDto createTaskDto)
        {
            var task = await _taskService.Add(createTaskDto);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
            
        }

        // Task sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedTask = await _taskService.Delete(id);
            if (deletedTask == null) return NotFound();
            return Ok(deletedTask);
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
            var updatedTask = await _taskService.UpdateIsCompleted(id);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }

        // Proje Idye göre taskları getir
        [HttpGet("project/{projectId}")] 
        public async Task<IActionResult> GetByProjectId(int projectId)
        {
            var tasks = await _taskService.GetByProjectId(projectId);
            return Ok(tasks);
        }
    }
}