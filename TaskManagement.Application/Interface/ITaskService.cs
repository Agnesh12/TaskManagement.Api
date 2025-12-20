using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Common.Entities;

namespace TaskManagement.Application.Interface
{
    public interface ITaskService
    {
        public Task<TaskItem?> GetById(int taskId);
        public Task<IEnumerable<TaskItem>> GetAll();
        public Task<TaskItem> Insert(TaskItem newTask);
        public Task<TaskItem> Update(TaskItem updateTask);
        public Task<TaskItem?> Delete(int taskId);
    }
}
