using TaskFlow.Models;

namespace TaskFlow.Models;

public enum TaskStatus {
    Todo,
    InProgress,
    Done
}

public class TaskEntity
{
    public Guid Id {get; init;}
    public string Title {get; set;} = string.Empty;
    public string? Description { get; set; }
    public TaskStatus Status {get; set;} = TaskStatus.Todo;
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public UserEntity User { get; set; } = null!;
 
}