using todo_list.dtos;
using Task = todo_list.models.Task;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Task> tasks = [
    new Task(0, "Task 1", "Description of Task 1", false, DateTime.Now, DateTime.Now),
    new Task(1, "Task 2", "Description of Task 2", true, DateTime.Now, DateTime.Now),
    new Task(2, "Task 3", "Description of Task 3", false, DateTime.Now, DateTime.Now)
];



app.MapGet("/", () => "Bienvenue dans votre application de gestion de tâches !");

app.MapGet("/tasks", () => tasks);

app.MapGet("/tasks/{id}", (int id )=>tasks.FirstOrDefault(t=>t.ID == id));


app.MapPost("/tasks",(CreateTaskDto createTaskDto) =>
{
    var newTask = new Task(
        tasks.Count-1,
        createTaskDto.Title,
        createTaskDto.Description,
        false,
        DateTime.Now,
        DateTime.Now
    );

    bool exist = tasks.Any(t => t.Title.Equals(createTaskDto.Title, StringComparison.OrdinalIgnoreCase));
   if(exist)
   {
        return Results.BadRequest("Task already exists");
   }
    tasks.Add(newTask);
    return Results.Created($"/tasks/{newTask.ID}", newTask);
});
app.Run();
