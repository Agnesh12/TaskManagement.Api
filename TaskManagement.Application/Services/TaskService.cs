
using TaskManagement.Application.Interface;
using TaskManagement.Common.Entities;
using TaskManagement.Infrastructure.Interface;

namespace TaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<TaskItem> genericRepository;
        public TaskService(IGenericRepository<TaskItem> taskRepository)
        {
            this.genericRepository = taskRepository;
        }
        public async Task<TaskItem?> GetById(int TaskId)
        {
            var task = await genericRepository.GetById(TaskId);
            if(task == null)
            {
                return null;
            }
            return task;
        }
        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await genericRepository.GetAll();
        }
        public async Task<TaskItem> Insert(TaskItem newTask)
        {
            return await genericRepository.Insert(newTask);
        }
        public Task<TaskItem> Update(TaskItem updateTask)
        {
            
            return genericRepository.Update(updateTask);
        }
        public async Task<TaskItem?> Delete(int id)
        {
            return await genericRepository.Delete(id);
        }
     }
}
