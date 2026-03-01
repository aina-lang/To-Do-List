using System;
using todo_list.dtos;
using todo_list.services;
using TaskService = todo_list.services.TaskService;
namespace todo_list.EndPoints;

public static class TaskApiEndpoint
{
    public static void MapTaskApiEndpoints(this WebApplication app)
    {
        app.MapGet("/", (TaskService service) => service.GetAllTasks());

        app.MapGet("/tasks", (TaskService service) => service.GetAllTasks());

        app.MapGet("/tasks/{id}", (int id, TaskService service) =>
        {
            var task = service.GetTaskById(id);
            return task is not null ? Results.Ok(task) : Results.NotFound();
        });

        app.MapPost("/tasks", (CreateTaskDto dto, TaskService service) =>
        {
            var task = service.CreateTask(dto);
            return Results.Created($"/tasks/{task.ID}", task);
        });

        app.MapPut("/tasks/{id}", (int id, UpdateTaskDto dto, TaskService service) =>
        {
            var task = service.UpdateTask(id, dto);
            return task is not null ? Results.Ok(task) : Results.NotFound();
        });

        app.MapPatch("/tasks/{id}", (int id, UpdateTaskDto dto, TaskService service) =>
        {
            var task = service.UpdateTask(id, dto);
            return task is not null ? Results.Ok(task) : Results.NotFound();
        });

        app.MapDelete("/tasks/{id}", (int id, TaskService service) =>
            service.DeleteTask(id) ? Results.NoContent() : Results.NotFound());

    }
}
