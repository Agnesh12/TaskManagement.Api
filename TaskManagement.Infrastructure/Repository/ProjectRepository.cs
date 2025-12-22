using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<Project> GetById(int projectId)
        {
            return await _context.projects
                .Include(p => p.Tasks);
        }
    }
}
