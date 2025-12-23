
using AutoMapper;
using TaskManagement.Application.Interface;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;
using TaskManagement.Infrastructure.Interface;
using TaskManagement.Infrastructure.Repository;

namespace TaskManagement.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> genericRepository;
        private readonly IProjectRepository projectRepository;  
        public ProjectService(IGenericRepository<Project> projectRepository, IProjectRepository Repository)
        {
            this.genericRepository = projectRepository;
            this.projectRepository = Repository;
        }
        public async Task<Project> Insert(Project NewProject)
        {
            return await genericRepository.Insert(NewProject);
        }
        public Task<Project> Update(Project  UpdateProject)
        {
            return genericRepository.Update(UpdateProject);
        }
        public Task<Project?> Delete(int ProjectId)
        {
            return genericRepository.Delete(ProjectId);
        }
        public async Task<List<Project?>> GetAll()
        {
            var projects = await projectRepository.GetAll();
            return projects.ToList();
        }
        public  Task<Project?> GetById(int projectId)
        {
            //var ListTask = await ProjectRepository.GetById(projectId);
            return projectRepository.GetById(projectId);
        }
    }
}
