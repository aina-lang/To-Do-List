using System;
using todo_list.dtos;
using Task = todo_list.models.Task;
namespace todo_list.services;

public class TaskService
{
    private readonly Repositories.ITaskRepository _taskRepository;
    public TaskService (Repositories.ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<models.Task> GetAllTasks() => _taskRepository.GetAllTasks();

    public models.Task GetTaskById(int id) => _taskRepository.GetTaskById(id);

    public Task CreateTask(CreateTaskDto dto)
    {
        var task = new Task
        {
            ID = _taskRepository.GetAllTasks().Count() > 0 ? _taskRepository.GetAllTasks().Max(t => t.ID) + 1 : 1,
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _taskRepository.CreateTask(task);
        return task;
    }

    public Task? UpdateTask(int id, UpdateTaskDto dto)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task == null) return null;

        // patch partiel style NestJS
        task.Title = dto.Title ?? task.Title;
        task.Description = dto.Description ?? task.Description;
        task.IsCompleted = dto.IsCompleted ?? task.IsCompleted;
        task.UpdatedAt = DateTime.Now;

        return task;
    }

    public bool DeleteTask(int id)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task == null) return false;
        _taskRepository.DeleteTask(id);
        return true;
    }
}
