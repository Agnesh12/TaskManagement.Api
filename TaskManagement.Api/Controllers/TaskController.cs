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
        // reference
        private readonly ITaskService taskService;
        private readonly IMapper mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task =  taskService.GetById(id);
            if (task == null)
                return NotFound();
            var wantedData = mapper.Map<TaskDto>(task);
            return Ok(wantedData);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTask()
        {
            var tasks = taskService.GetAll();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> AddTask(TaskItem NewTask)
        {
       
            if (NewTask == null)
                return BadRequest();

            var createdTask =  taskService.Insert(NewTask);

            return CreatedAtAction(
                nameof(GetTask),
                new { id = createdTask.Id },
                createdTask
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem newTask)
        {
            if (newTask == null)
                return BadRequest();
            var existingTask =  taskService.GetById(id);
            if (existingTask == null)
                return NotFound();

            await taskService.Update(newTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task =  taskService.GetById(id);
            if (task == null)
                return NotFound();

            taskService.Delete(id);
            return NoContent();
        }
    }
}
