using AS.MCP.SSE.Shared.Tasks.Models;
using AS.MCP.SSE.Shared.Tasks.Dtos;
using AS.MCP.SSE.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AS.MCP.SSE.Shared.Tasks.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _context;

        public TaskService(TaskDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks.Select(MapToDto);
        }

        public async Task<int> AddTask(CreateTaskDto taskDto)
        {
            if (taskDto == null)
                throw new ArgumentNullException(nameof(taskDto));

            var task = MapToEntity(taskDto);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        private static TaskDto MapToDto(AgentTask task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Type = task.Type,
                Priority = task.Priority,
                Status = task.Status,
                AssignedTo = task.AssignedTo,
                EstimatedHours = task.EstimatedHours,
                DueDate = task.DueDate
            };
        }

        private static AgentTask MapToEntity(CreateTaskDto dto)
        {
            return new AgentTask
            {
                Title = dto.Title,
                Description = dto.Description,
                Type = dto.Type,
                Priority = dto.Priority,
                Status = dto.Status,
                AssignedTo = dto.AssignedTo,
                EstimatedHours = dto.EstimatedHours,
                DueDate = dto.DueDate
            };
        }
    }
}