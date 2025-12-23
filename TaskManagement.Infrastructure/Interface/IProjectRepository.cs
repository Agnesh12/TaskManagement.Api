using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;

namespace TaskManagement.Infrastructure.Interface
{
    public interface IProjectRepository
    {
        public  Task<Project?> GetById(int projectId);
        public Task<IEnumerable<Project?>> GetAll();
        
    }
}
