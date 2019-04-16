using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public class ProjectTask: ToDoItem
    {
        public ProjectBase Project { get; set; }
        public TaskNumber TaskNo { get; set; }
        public DateTime? EndDate { get; set; }
        public TaskStatus Status { get; set; }

        public ProjectTask(string title):base(title)
        {
            TaskNo = new TaskNumber("DP", base.ItemID);
            Status = TaskStatus.Plan;   
        }

        public override string ItemInfo()
        {
            return $"Project {Project}, taskno: {TaskNo}, " +
                $"status:{Status}";
        }

        public override string CompleteInfo()
        {
            return "Project task " + base.CompleteInfo();
        }

        public override string ToString()
        {
            return ItemInfo();
        }
    }

    public sealed class SpecialProjectTask: ProjectTask
    {
        public SpecialProjectTask() : base("Special task")
        {

        }

        public new string CompleteInfo()
        {
            return base.CompleteInfo();
        }
    }
}
