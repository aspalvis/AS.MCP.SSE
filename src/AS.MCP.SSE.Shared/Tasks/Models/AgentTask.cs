namespace AS.MCP.SSE.Shared.Tasks.Models
{
    public class AgentTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string AssignedTo { get; set; } = string.Empty;
        public int EstimatedHours { get; set; }
        public string DueDate { get; set; } = string.Empty;
    }
}