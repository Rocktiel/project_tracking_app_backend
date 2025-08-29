using Microsoft.AspNetCore.Mvc;
using MiniProject.Application.DTOs;
using MiniProject.Application.Services;

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

        
    }
}