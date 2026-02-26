namespace todo_list.models;

public record class Task(
    int ID,
    string Title,
    string Description,
    bool IsCompleted,
    DateTime CreatedAt ,
    DateTime UpdatedAt
);