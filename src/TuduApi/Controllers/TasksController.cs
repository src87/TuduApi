using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TuduApi.Data;
using TuduApi.Models;

namespace TuduApi.Controllers
{
    [Route("api/tasks")]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IEnumerable<Task> Get(string searchTerms = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerms))
                return _taskRepository.GetTasks();

            var terms = searchTerms.Split(' ');
            return _taskRepository.GetTasks(terms);
        }

        [HttpPost]
        public void Post([FromBody]Task task)
        {
            _taskRepository.Add(task);
        }

        [HttpPut]
        public void Put([FromBody]Task task)
        {
            _taskRepository.Update(task);
        }

        [HttpDelete("{taskId}")]
        public void Delete(int taskId)
        {
            _taskRepository.Delete(taskId);
        }
    }
}