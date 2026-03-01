using todo_list.models;
using Task = todo_list.models.Task;
namespace todo_list.Repositories;


public interface ITaskRepository
{
    IEnumerable<Task> GetAllTasks();
    Task? GetTaskById(int id);
    void CreateTask(Task task);
    void UpdateTask(Task task);
    void DeleteTask(int id);
}
public class TaskRepository : ITaskRepository
{
    private readonly List<Task> tasks =
[
    new Task { ID = 0, Title = "Préparer le rapport", Description = "Rédiger le rapport mensuel pour l'équipe", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 10, 9, 30, 0), UpdatedAt = new DateTime(2024, 1, 10, 9, 30, 0) },
    new Task { ID = 1, Title = "Faire les courses", Description = "Acheter du lait, du pain et des fruits", IsCompleted = true, CreatedAt = new DateTime(2024, 1, 12, 14, 0, 0), UpdatedAt = new DateTime(2024, 1, 12, 16, 0, 0) },
    new Task { ID = 2, Title = "Appeler le support technique", Description = "Résoudre le problème réseau du bureau", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 15, 11, 45, 0), UpdatedAt = new DateTime(2024, 1, 15, 11, 45, 0) },
    new Task { ID = 3, Title = "Nettoyer la voiture", Description = "Passer un coup d'aspirateur et laver l'extérieur", IsCompleted = true, CreatedAt = new DateTime(2024, 1, 18, 10, 0, 0), UpdatedAt = new DateTime(2024, 1, 18, 12, 0, 0) },
    new Task { ID = 4, Title = "Ranger le bureau", Description = "Organiser les dossiers et nettoyer l'espace de travail", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 20, 9, 15, 0), UpdatedAt = new DateTime(2024, 1, 20, 9, 15, 0) },
    new Task { ID = 5, Title = "Réviser le code", Description = "Passer en revue le dernier commit et faire des corrections", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 22, 13, 20, 0), UpdatedAt = new DateTime(2024, 1, 22, 13, 20, 0) },
    new Task { ID = 6, Title = "Envoyer un e-mail important", Description = "Transmettre les informations au client", IsCompleted = true, CreatedAt = new DateTime(2024, 1, 23, 8, 40, 0), UpdatedAt = new DateTime(2024, 1, 23, 8, 45, 0) },
    new Task { ID = 7, Title = "Planifier la réunion", Description = "Préparer l'agenda pour la réunion de la semaine prochaine", IsCompleted = false, CreatedAt = new DateTime(2024, 1, 25, 15, 10, 0), UpdatedAt = new DateTime(2024, 1, 25, 15, 10, 0) }
];


    public IEnumerable<Task> GetAllTasks() => tasks;

    public Task? GetTaskById(int id) => tasks.FirstOrDefault(t => t.ID == id);

    public void CreateTask(Task task) => tasks.Add(task);

    public void UpdateTask(Task task)
    {
        var existingTask = GetTaskById(task.ID);
        if (existingTask is not null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.UpdatedAt = DateTime.Now;
        }
    }

    public void DeleteTask(int id)
    {
        var task = GetTaskById(id);
        if (task != null)
        {
            tasks.Remove(task);
        }
    }

}