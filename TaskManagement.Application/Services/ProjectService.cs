using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.Interface;
using TaskManagement.Common.Entities;
using TaskManagement.Infrastructure.Interface;

namespace TaskManagement.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> genericRepository;
        public ProjectService(IGenericRepository<Project> projectRepository)
        {
            this.genericRepository = projectRepository;
        }
        public Task<Project> Insert(Project NewProject)
        {
            return genericRepository.Insert(NewProject);
        }
        public Task<Project> Update(Project UpdateProject)
        {
            return genericRepository.Update(UpdateProject);
        }
        public Task<Project?> Delete(int ProjectId)
        {
            return genericRepository.Delete(ProjectId);
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await genericRepository.GetAll();
        }
    }
}
