namespace todo_list.models;

public record class Task{
   public int ID{get; set;}
    public string? Title{get; set;}
    public string? Description{get; set;}
    public bool? IsCompleted{get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
};