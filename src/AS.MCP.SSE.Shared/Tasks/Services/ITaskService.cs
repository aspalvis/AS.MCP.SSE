using AS.MCP.SSE.Shared.Tasks.Models;

namespace AS.MCP.SSE.Shared.Tasks.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<AgentTask>> GetTasks();
        Task AddTask(AgentTask task);
    }
}