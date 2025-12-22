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
            var addData = mapper.Map<Project>(requestDto);
            var addedProject = await projectService.Insert(addData);
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
        [HttpGet("GetAllProjectTask")]
        public async Task<ActionResult<List<TaskResponseDto>>> GetAll()
        {
            //var allProjects = await projectService.GetAll();
            //if (allProjects == null)
            //{
            //    return NotFound();
            //}
            //var allTasks = await taskService.GetAll();
           
            //var projectsDto = mapper.Map<List<ProjectDto>>(allProjects);
            
            //foreach(var projectDtos in projectsDto)
            //{
            //    var projectTasks = allTasks.Where(t => t.ProjectId == projectDtos.ProjectId).ToList();
            //    projectDtos.Tasks = mapper.Map<List<TaskResponseDto>>(projectTasks);
            //}
            //var projectsTasks = mapper.Map<List<TaskResponseDto>>(projectsDto);
            
            return Ok();
            
        }
        [HttpGet("GetProjectTask{projectId}")]
        public async Task<ActionResult<List<ProjectResponseDto>>> GetProjectTask(int projectId)
        {
            var ListTasks = await projectService.GetById(projectId);
            if(ListTasks == null)
            {
                return NotFound();
            }
            var TasksDto = mapper.Map<List<TaskResponseDto>>(ListTasks);
            return Ok(TasksDto);
        }
    }
}
