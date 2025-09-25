using AS.MCP.SSE.Shared.Tasks.Tools;
using AS.MCP.SSE.Shared.Tasks.Services;
using AS.MCP.SSE.Shared.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework Core with SQLite
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") 
                     ?? "Data Source=tasks.db"));

builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithResourcesFromAssembly(typeof(TaskPrompts).Assembly)
    .WithPromptsFromAssembly(typeof(TaskPrompts).Assembly)
    .WithToolsFromAssembly(typeof(TaskPrompts).Assembly);

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    context.Database.EnsureCreated();
}

app.MapMcp();

await app.RunAsync();