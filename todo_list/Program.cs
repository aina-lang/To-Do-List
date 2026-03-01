using todo_list.dtos;
using Task = todo_list.models.Task;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Task> tasks = [
    new Task{ID = 0, Title = "Task 1", Description = "Description of Task 1", IsCompleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
    new Task{ID = 1, Title = "Task 2", Description = "Description of Task 2", IsCompleted = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
    new Task{ID = 2, Title = "Task 3", Description = "Description of Task 3", IsCompleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
];



app.MapGet("/", () => tasks);

app.MapGet("/tasks", () => tasks);

app.MapGet("/tasks/{id}", (int id) => tasks.FirstOrDefault(t => t.ID == id) is Task task ?Results.Ok(task) : Results.NotFound("Task not found")).WithName("GetTaskById");


app.MapPost("/tasks", (CreateTaskDto createTaskDto) =>
{
    var newTask = new Task{
        ID=tasks.Count,
        Title=createTaskDto.Title,
        Description=createTaskDto.Description,
        IsCompleted=false,
        CreatedAt=DateTime.Now,
        UpdatedAt=DateTime.Now
    };

    bool exist = tasks.Any(t => t.Title.Equals(createTaskDto.Title, StringComparison.OrdinalIgnoreCase));

    if (exist) return Results.BadRequest("Task already exists");
    tasks.Add(newTask);

    return Results.CreatedAtRoute("GetTaskById", new { id = newTask.ID }, newTask);
});


app.MapDelete("/tasks/{id}", (int id) =>
{
   var task =tasks.FirstOrDefault(t => t.ID == id);
   if (task is null) return Results.NotFound("Task not found");
   tasks.Remove(task);
   return Results.NoContent();
});


app.MapPut("/tasks/{id}", (int id, UpdateTaskDto updateTaskDto) =>
{
    var task = tasks.FirstOrDefault(t => t.ID == id);
    if (task is null) return Results.NotFound("Task not found");
    task.Title=updateTaskDto.Title?? task.Title;
    task.Description=updateTaskDto.Description?? task.Description;
    task.IsCompleted=updateTaskDto.IsCompleted?? task.IsCompleted;
    task.UpdatedAt=DateTime.Now;
    return Results.Ok(task);
});


app.Run();
