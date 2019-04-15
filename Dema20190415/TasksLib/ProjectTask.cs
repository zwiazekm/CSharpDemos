using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public class ProjectTask: ToDoItem
    {
        public string Project { get; set; }
        public string TaskNo { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public ProjectTask(string title):base(title)
        {
            
        }
    }
}
