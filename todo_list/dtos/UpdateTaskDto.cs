namespace todo_list.dtos;

public record class UpdateTaskDto:CreateTaskDto
{
  public new string? Title { get; init; }
    public new string? Description { get; init; }
    public new  bool?    IsCompleted { get; init; }
    
}
