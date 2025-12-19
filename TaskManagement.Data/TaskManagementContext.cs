
using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Entities;
namespace TaskManagement.Data
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
            
        }
       public DbSet<TaskItem> tasks { get; set; }
       public DbSet<Project> projects { get; set; }
    }
}
