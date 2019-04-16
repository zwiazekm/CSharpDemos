using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public abstract class ProjectBase
    {
        public string ProjectName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual string ProjectInfo()
        {
            return $"Project {ProjectName}";
        }

        public override string ToString()
        {
            return ProjectInfo();
        }
        public abstract string ProjectStatus();
    }

    public class ShortProject : ProjectBase
    {
        private string projectStatus;

        public override string ProjectStatus()
        {
            return projectStatus;
        }
    }

}

