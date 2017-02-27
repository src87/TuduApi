using System.Collections.Generic;
using TuduApi.Models;

namespace TuduApi.Data
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetTasks(IEnumerable<string> searchTerms);
        void Add(Task task);
        void Update(Task task);
        void Delete(int taskId);
    }
}