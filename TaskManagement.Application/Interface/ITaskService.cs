using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Common.Entities;

namespace TaskManagement.Application.Interface
{
    public interface ITaskService
    {
        public Task<TaskItem> GetById(int TaskId);
        public Task<IEnumerable<TaskItem>> GetAll();
        public Task<TaskItem> Insert(TaskItem NewTask);

        public Task<TaskItem> Update(TaskItem updateTask);
        public Task<TaskItem> Delete(int TaskId);
    }
}
