using AS.MCP.SSE.Shared.Tasks.Dtos;

namespace AS.MCP.SSE.Shared.Tasks.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasks();
        Task<int> AddTask(CreateTaskDto taskDto);
    }
}