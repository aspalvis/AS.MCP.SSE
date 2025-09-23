using AS.MCP.SSE.Shared.Tasks.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithResourcesFromAssembly(typeof(TaskPrompts).Assembly)
    .WithPromptsFromAssembly(typeof(TaskPrompts).Assembly)
    .WithToolsFromAssembly(typeof(TaskPrompts).Assembly);

var app = builder.Build();

app.MapMcp();

await app.RunAsync();