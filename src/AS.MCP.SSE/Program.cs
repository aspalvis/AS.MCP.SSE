using AS.MCP.SSE.Shared.Tasks.Tools;
using AS.MCP.SSE.Shared.Tasks.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithResourcesFromAssembly(typeof(TaskPrompts).Assembly)
    .WithPromptsFromAssembly(typeof(TaskPrompts).Assembly)
    .WithToolsFromAssembly(typeof(TaskPrompts).Assembly);

var app = builder.Build();

app.MapMcp();

await app.RunAsync();