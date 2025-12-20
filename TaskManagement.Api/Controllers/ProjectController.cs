using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interface;
using TaskManagement.Application.Services;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;
        private readonly ITaskService taskService;
        public ProjectController(IProjectService projectService, IMapper mapper, ITaskService taskService)
        {
            this.projectService = projectService;
            this.mapper = mapper;
            this.taskService = taskService;
        }
        [HttpPost("Addproject")]
        public async Task<ActionResult<Project>> AddProject([FromBody] ProjectRequestDto requestDto)
        {
            var currentProject = mapper.Map<Project>(requestDto);
            var addedProject = await projectService.Insert(currentProject);
            var responseDto = mapper.Map<ProjectResponseDto>(addedProject);
            return Ok(responseDto);
        }
        [HttpDelete("delete/{deleteId}")]
        public async Task<ActionResult> DeleteProject(int deleteId)
        {
            var currentProject = await projectService.Delete(deleteId);
            return NoContent();
        }
        [HttpPut("Update{updateId}")]
        public async Task<IActionResult?> Update(int updateId, [FromBody] ProjectRequestDto requestDto)
        {
            var currentProject = mapper.Map<Project>(requestDto);
            currentProject.ProjectId = updateId;
            var updated = await projectService.Update(currentProject);
            if(updated == null)
            {
                return null;
            }
            var responseDto = mapper.Map<ProjectResponseDto>(updated);
            return Ok(responseDto);

        }
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            var projects = await projectService.GetAll();
            var listProject = mapper.Map<List<ProjectResponseDto>>(projects);
            return Ok(listProject);
            
        }
        [HttpGet("{projectId}")]
        public async Task<ActionResult<List<Task>>> GetProjectTask(int projectId)
        {
            var allTasks = await taskService.GetAll();
            var projectTasks =  allTasks.Where(taskId => taskId.ProjectId == projectId).ToList();
            var responseProjectTask = mapper.Map<List<TaskResponseDto>>(projectTasks);
            return Ok(responseProjectTask);
        }
    }
}
