namespace AS.MCP.SSE.Shared.Tasks.Tools
{
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    using System.Text.Json;

    [McpServerToolType]
    public sealed class TaskTools
    {
        [McpServerTool, Description("Get list of agent tasks.")]
        public Task<string> GetTasks()
        {
            var tasks = new[]
            {
                new
                {
                    Id = 1,
                    Title = "Implement User Authentication UI",
                    Description = "Create login and registration forms with validation",
                    Type = "Frontend",
                    Priority = "High",
                    Status = "In Progress",
                    AssignedTo = "Frontend Developer",
                    EstimatedHours = 16,
                    DueDate = "2024-01-15"
                },
                new
                {
                    Id = 2,
                    Title = "Design Responsive Dashboard Layout",
                    Description = "Create a responsive dashboard with charts and widgets",
                    Type = "Frontend",
                    Priority = "Medium",
                    Status = "Pending",
                    AssignedTo = "UI/UX Developer",
                    EstimatedHours = 24,
                    DueDate = "2024-01-20"
                }
            };

            return Task.FromResult(JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }
    }
}
