namespace todo_list.dtos;

public record class CreateTaskDto
{
    public string Title { get; init; }
    public string Description { get; init; }
    public bool IsCompleted { get; init; }
}
