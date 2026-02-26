namespace todo_list.dtos;

public record class CreateTaskDto
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}
