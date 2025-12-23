using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Dtos;
using TaskManagement.Common.Entities;
using TaskManagement.Data;
using TaskManagement.Infrastructure.Interface;

namespace TaskManagement.Infrastructure.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly TaskManagementContext _context;
        public ProjectRepository(TaskManagementContext context)
        {
            _context = context;
        }
        public async Task<Project?> GetById(int projectId)
        {
            return  _context.projects
                .Include(p => p.Tasks)
                .FirstOrDefault(t => t.ProjectId == projectId);
        }
        public async Task<IEnumerable<Project?>> GetAll()
        {
            return await _context.projects
                .Include(p => p.Tasks).ToListAsync();
        }
       
    }
}
