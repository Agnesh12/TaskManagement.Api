
using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Entities;
namespace TaskManagement.Data
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasOne(b => b.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(b => b.ProjectId);
        }
       public DbSet<TaskItem> tasks { get; set; }
       public DbSet<Project> projects { get; set; }
    }
}
