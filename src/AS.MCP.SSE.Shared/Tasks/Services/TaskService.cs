using AS.MCP.SSE.Shared.Tasks.Models;

namespace AS.MCP.SSE.Shared.Tasks.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<AgentTask> _tasks;
        private int _nextId = 1;

        public TaskService()
        {
            _tasks = new List<AgentTask>();
        }

        public Task<IEnumerable<AgentTask>> GetTasks()
        {
            return Task.FromResult(_tasks.AsEnumerable());
        }

        public Task AddTask(AgentTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            task.Id = _nextId++;
            _tasks.Add(task);
            return Task.CompletedTask;
        }
    }
}