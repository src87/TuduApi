using System.Collections.Generic;

namespace TuduApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public IEnumerable<Task> SubTasks { get; set; }
    }
}