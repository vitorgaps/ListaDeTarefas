using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models.Tasks;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService){
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            Console.WriteLine(tasks);
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(TaskCreation tarefa)
        {            
            if (tarefa.endDate != null && (tarefa.endDate < tarefa.startDate))
            {
                return BadRequest(new{ message = "Finish date must be after creation date" });
            }
            var created = _taskService.createTask(tarefa);
            return Ok(new { message = "Task created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskUpdate tarefa)
        {
            if (tarefa.endDate != null && (tarefa.endDate < tarefa.startDate))
            {
                return BadRequest(new { message = "Finish date must be after creation date" });
            }
            var updated = _taskService.updateTask(id,tarefa);
            if (updated)
            {
                return Ok(new { message = "Task updated" });
            }
            else 
            {
                return BadRequest(new { message = "Task not found" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTask(int id) {
            var removed = _taskService.removeTask(id);
            if (removed)
            {
                return Ok(new { message = "Task removed" });
            }

            else {                
                return BadRequest(new { message = "Task not found" });               
            }            
        }
    }

}
