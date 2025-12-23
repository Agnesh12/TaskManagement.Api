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
    public class TaskController : ControllerBase
    {
       
        private readonly ITaskService taskService;
        private readonly IMapper mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        [HttpGet("TaskId{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task =  await taskService.GetById(id);
            if (task == null)
                return NotFound();
            var wantedData = mapper.Map<TaskResponseDto>(task);
            return Ok(wantedData);
        }

        [HttpGet("GetAllTask")]
        public async Task<ActionResult<List<TaskItem>>> GetAllTask()
        {
            var tasks = await taskService.GetAll();
            var listTasks = mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
            return Ok(listTasks);
        }

        [HttpPost("AddTask")]
        public async Task<ActionResult<TaskItem>> AddTask(TaskDto NewTask)
        {
            var task = mapper.Map<TaskItem>(NewTask);
            var createdTask = await taskService.Insert(task);
            var finishTask = mapper.Map<TaskResponseDto>(createdTask);
            return Ok(finishTask);
           
        }

        [HttpPut("UpdateTask{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto newTask)
        {
            var NewTask = mapper.Map<TaskItem>(newTask);
            NewTask.Id = id;
            var updated = await taskService.Update(NewTask);
            
            if (updated == null)
                return NotFound();

            var responseDto = mapper.Map<TaskResponseDto>(updated);
            return Ok();
        }

        [HttpDelete("DeleteTask{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = await taskService.GetById(id);
            if (task == null)
                return NotFound();

            await taskService.Delete(id);
            return NoContent();
        }
    }
}
