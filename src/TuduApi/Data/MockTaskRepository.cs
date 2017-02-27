using System.Collections.Generic;
using System.Linq;
using TuduApi.Models;

namespace TuduApi.Data
{
    public class MockTaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks;

        public MockTaskRepository()
        {
            _tasks = InitialTasks().ToList();
        }

        private static IEnumerable<Task> InitialTasks()
        {
            yield return new Task { Id = 1, Title = "First test task", Description = "first description", Status = TaskStatus.Active };
            yield return new Task { Id = 2, Title = "Second test task", Description = "second description", Status = TaskStatus.Active };
            yield return new Task { Id = 3, Title = "Third test task", Description = "third description", Status = TaskStatus.Done };
            yield return new Task { Id = 4, Title = "Fourth test task", Description = "fourth description", Status = TaskStatus.Archived };
        }

        public IEnumerable<Task> GetTasks()
        {
            return _tasks.OrderBy(t => t.Id);
        }

        public void Add(Task task)
        {
            _tasks.Add(task);
        }

        public void Delete(int taskId)
        {
            TryRemoveTask(taskId);
        }

        public void Update(Task task)
        {
            TryRemoveTask(task.Id);
            _tasks.Add(task);
        }

        private void TryRemoveTask(int taskId)
        {
            var taskToRemove = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
                _tasks.Remove(taskToRemove);
        }
    }
}
