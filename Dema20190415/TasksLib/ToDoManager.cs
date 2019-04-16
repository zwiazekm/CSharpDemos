using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public class ToDoManager : ITaskManager
    {
        List<ToDoItem> toDoItems = new List<ToDoItem>();

        public int TaskCount => toDoItems.Count;

        public void AddTask(ToDoItem newTask)
        {
            toDoItems.Add(newTask);
        }

        public void AddTask(string title, DateTime dueDate)
        {
            ToDoItem newToDo = new ToDoItem(title, dueDate);
            AddTask(newToDo);
        }

        public void AddProjectTask(string title, string projectName)
        {
            ProjectTask newProjectTask = new ProjectTask(title);
            newProjectTask.Project = 
                new ShortProject() { ProjectName = projectName };
            toDoItems.Add(newProjectTask);
        }

        public void AddPayment(string title, DateTime dueDate, decimal amount)
        {
            Payment newPayment = new Payment(title, amount);
            newPayment.DueDate = dueDate;
            toDoItems.Add(newPayment);
        }

        public IEnumerable<ToDoItem> TaskList()
        {
            return toDoItems;
        }

        public IEnumerable<string> UncompletedTasks()
        {
            var wynik = from t in toDoItems
                        where t.Completed == false
                        select t.ToString();
            //var wyn = toDoItems.Where(t => !t.Completed).Select( t => t.ToString());
            return wynik;
        }

        public IEnumerable<Payment> Payments
        {
            get {
                return from p in toDoItems
                       where p is Payment
                       select (Payment)p;
            }
        }
    }
}
