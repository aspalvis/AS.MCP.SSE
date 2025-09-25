using AS.MCP.SSE.Shared.Tasks.Models;
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

        public async Task<IEnumerable<AgentTask>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task AddTask(AgentTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }
    }
}