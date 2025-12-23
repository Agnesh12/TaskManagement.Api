using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;

namespace TaskManagement.Application.Interface
{
    public interface IProjectService
    {
        public Task<Project> Insert(Project NewProject);
        public Task<Project> Update(Project UpdateProject);
        public Task<Project?> Delete(int ProjectId);
        public Task<List<Project?>> GetAll();
        public Task<Project?> GetById(int projectId);
    }
}
