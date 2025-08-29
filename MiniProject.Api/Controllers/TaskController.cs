using Microsoft.AspNetCore.Mvc;
using MiniProject.Application.DTOs;
using MiniProject.Application.Services;

namespace MiniProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
    }
}