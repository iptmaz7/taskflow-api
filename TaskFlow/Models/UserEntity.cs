using  TaskFlow.Models;

namespace TaskFlow.Models;

public class UserEntity
{
    public Guid Id {get; init;}
    public string Email {get; set;} = string.Empty;

    public string HashPassword {get; set;} = string.Empty;

    public  List<TaskEntity> Tasks { get; set; } = new(); 
}
