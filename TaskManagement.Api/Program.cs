using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interface;
using TaskManagement.Application.Services;
using TaskManagement.Data;
using TaskManagement.Infrastructure.Interface;
using TaskManagement.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ✅ Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Database
builder.Services.AddDbContext<TaskManagementContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

var app = builder.Build();

// Configure the HTTP request pipeline

// ✅ Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
