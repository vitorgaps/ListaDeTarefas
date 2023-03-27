using webapi.Entities;
using webapi.Helpers;
using webapi.Models.Tasks;

namespace webapi.Services
{
    public interface ITaskService
    {
        IEnumerable<Entities.Task> GetAllTasks();
        bool createTask(TaskCreation tarefa);
        bool updateTask(int id, TaskUpdate tarefa);
        bool removeTask(int id);
    }

    public class TaskService : ITaskService
    {
        private DataContext _context;

        public TaskService(DataContext context) {
            _context =  context;
        }

        public bool createTask(TaskCreation tarefa)
        {
            Entities.Task tarefaCriada = new Entities.Task(){
                startDate = tarefa.startDate,
                endDate = tarefa.endDate,
                description = tarefa.taskDescription,
                taskName = tarefa.taskName,
                finished = tarefa.finished
            };

            _context.Tasks.Add(tarefaCriada);
            _context.SaveChanges();
            return true;
        }        

        public IEnumerable<Entities.Task> GetAllTasks()
        {
            var tarefas = _context.Tasks;
            return tarefas;
        }

        public bool removeTask(int id)
        {
            var task = GetTask(id);
            if (task == null)
            {
                return false;
            }
            else {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return true;
            }
        }

        public Entities.Task? GetTask(int id)
        {
            var task = _context.Tasks.Find(id);
            return task;            
        }

        public bool updateTask(int id, TaskUpdate tarefa)
        {
            var task = GetTask(id);
            if (task == null)
            {
                return false;
            }
            else {
                task.taskName = tarefa.taskName;
                task.description = tarefa.taskDescription;
                task.startDate = tarefa.startDate;
                task.endDate = tarefa.endDate;
                task.finished = tarefa.finished;
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
