using todo_list.dtos;
using todo_list.EndPoints;
using todo_list.Repositories;
using todo_list.services;
using Task = todo_list.models.Task;


// configuration de l'application
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuration de Swagger pour la documentation de l'API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Mon TODO API", Version = "v1", Description = "Une API pour gérer une liste de tâches à faire." });

});

var app = builder.Build();

// Swagger middleware
app.UseSwagger(options =>
{
    options.RouteTemplate = "docs/{documentName}/swagger.json";
});
app.UseSwaggerUI((c) =>
{
    c.RoutePrefix="docs";
});


app.MapTaskApiEndpoints();
app.Run();
