namespace AS.MCP.SSE.Shared.Tasks.Dtos
{
    public class CreateTaskDto
    {
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