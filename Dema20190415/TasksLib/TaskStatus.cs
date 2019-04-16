using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public enum TaskStatus
    {
        Plan,
        Progress,
        Close,
        Cancel=-1
    }
}
