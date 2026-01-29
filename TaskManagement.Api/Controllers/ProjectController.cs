using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interface;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;
//hello
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
        public async Task<ActionResult<Project>> AddProject([FromBody] ProjectResponseDto requestDto)
        {
            var projectData = mapper.Map<Project>(requestDto);

            var addedProject = await projectService.Insert(projectData);

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
        public async Task<IActionResult> Update(int updateId, [FromBody] ProjectRequestDto requestDto)
        {
            var currentProject = await projectService.GetById(updateId);
            currentProject.ProjectDescription = requestDto.ProjectDescription;
            
            if(currentProject == null)
            {
                return NotFound();
            }
            currentProject.ProjectId = updateId;
            var updated = await projectService.Update(currentProject);
            if (updated == null)
            {
                return null;
            }
            return Ok(requestDto);

        }
        [HttpGet("GetAllProjectTask")]
        public async Task<ActionResult<List<TaskResponseDto>>> GetAll()
        {         
            var allProjects = await projectService.GetAll();
            var TasksDto = mapper.Map<List<ProjectResponseDto>>(allProjects);
            

            return Ok(TasksDto);
            
        }
        [HttpGet("GetProjectTask{projectId}")]
        public async Task<ActionResult<ProjectResponseDto>> GetProjectTask(int projectId)
        {
            var ListTasks = await projectService.GetById(projectId);
            if(ListTasks == null)
            {
                return NotFound();
            }
            
            var finalTask = mapper.Map<ProjectResponseDto>(ListTasks);
            return Ok(finalTask);
        }
    }
}
