using todo_list.dtos;
using Task = todo_list.models.Task;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// In-memory data store
List<Task> tasks = new()
{
    new Task { ID = 0, Title = "Préparer le rapport", Description = "Rédiger le rapport mensuel pour l'équipe", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 10, 9, 30, 0), UpdatedAt = new DateTime(2024, 1, 10, 9, 30, 0) },
    new Task { ID = 1, Title = "Faire les courses", Description = "Acheter du lait, du pain et des fruits", IsCompleted = true, CreatedAt = new DateTime(2024, 1, 12, 14, 0, 0), UpdatedAt = new DateTime(2024, 1, 12, 16, 0, 0) },
    new Task { ID = 2, Title = "Appeler le support technique", Description = "Résoudre le problème réseau du bureau", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 15, 11, 45, 0), UpdatedAt = new DateTime(2024, 1, 15, 11, 45, 0) },
    new Task { ID = 3, Title = "Nettoyer la voiture", Description = "Passer un coup d'aspirateur et laver l'extérieur", IsCompleted = true, CreatedAt = new DateTime(2024, 1, 18, 10, 0, 0), UpdatedAt = new DateTime(2024, 1, 18, 12, 0, 0) },
    new Task { ID = 4, Title = "Ranger le bureau", Description = "Organiser les dossiers et nettoyer l'espace de travail", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 20, 9, 15, 0), UpdatedAt = new DateTime(2024, 1, 20, 9, 15, 0) },
    new Task { ID = 5, Title = "Réviser le code", Description = "Passer en revue le dernier commit et faire des corrections", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 22, 13, 20, 0), UpdatedAt = new DateTime(2024, 1, 22, 13, 20, 0) },
    new Task { ID = 6, Title = "Envoyer un e-mail important", Description = "Transmettre les informations au client", IsCompleted = true, CreatedAt = new DateTime(2024, 1, 23, 8, 40, 0), UpdatedAt = new DateTime(2024, 1, 23, 8, 45, 0) },
    new Task { ID = 7, Title = "Planifier la réunion", Description = "Préparer l'agenda pour la réunion de la semaine prochaine", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 25, 15, 10, 0), UpdatedAt = new DateTime(2024, 1, 25, 15, 10, 0) }
};



// Root endpoint
app.MapGet("/", () => tasks);

// Get all tasks
app.MapGet("/tasks", () => tasks);

// Get a task by ID
app.MapGet("/tasks/{id}", (int id) => tasks.FirstOrDefault(t => t.ID == id) is Task task ?Results.Ok(task) : Results.NotFound("Task not found")).WithName("GetTaskById");


// Create a new task
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


// Delete a task
app.MapDelete("/tasks/{id}", (int id) =>
{
   var task =tasks.FirstOrDefault(t => t.ID == id);
   if (task is null) return Results.NotFound("Task not found");
   tasks.Remove(task);
   return Results.NoContent();
});


// Update a task
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
