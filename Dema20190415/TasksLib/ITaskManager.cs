using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public interface ITaskManager
    {
        void AddTask(ToDoItem newTask);
        void AddTask(string title, DateTime dueDate);

        IEnumerable<ToDoItem> TaskList();

        IEnumerable<string> UncompletedTasks();

        int TaskCount { get; }

    }
}
