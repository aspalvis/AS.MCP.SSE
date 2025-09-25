namespace AS.MCP.SSE.Shared.Tasks.Tools
{
    using AS.MCP.SSE.Shared.Tasks.Dtos;
    using AS.MCP.SSE.Shared.Tasks.Services;
    using ModelContextProtocol.Server;
    using System.ComponentModel;
    using System.Text.Json;

    [McpServerToolType]
    public sealed class TaskTools
    {
        private readonly ITaskService _taskService;

        public TaskTools(ITaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [McpServerTool, Description("Get list of agent tasks.")]
        public async Task<string> GetTasks()
        {
            var tasks = await _taskService.GetTasks();
            
            return JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        [McpServerTool, Description("Add a new task.")]
        public async Task<string> AddTask(
            [Description("Task title")] string title,
            [Description("Task description")] string description,
            [Description("Task type")] string type,
            [Description("Task priority")] string priority,
            [Description("Task status")] string status,
            [Description("Assigned to")] string assignedTo,
            [Description("Estimated hours")] int estimatedHours,
            [Description("Due date")] string dueDate)
        {
            var taskDto = new CreateTaskDto
            {
                Title = title,
                Description = description,
                Type = type,
                Priority = priority,
                Status = status,
                AssignedTo = assignedTo,
                EstimatedHours = estimatedHours,
                DueDate = dueDate
            };

            var taskId = await _taskService.AddTask(taskDto);
            
            return JsonSerializer.Serialize(new { message = "Task added successfully", taskId = taskId }, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
