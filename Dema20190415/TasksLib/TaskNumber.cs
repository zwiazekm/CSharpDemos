using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public struct TaskNumber
    {
        private string prefix;
        private int number;
        public string Suffix { get; set; }

        public TaskNumber(string prefix, int number)
        {
            this.prefix = prefix;
            this.number = number;
            this.Suffix = null;
        }

        public string FullNo()
        {
            string nr = $"{prefix}/{number}";
            if (Suffix != null)
            {
                nr += $"/{Suffix}";
            }
            return nr;
        }

        public override string ToString()
        {
            return FullNo();
        }

        public int nr
        {
            get { return number; }
        }

        public static implicit operator TaskNumber(string strNo)
        {
            return Parse(strNo);
        }

        public static implicit operator String(TaskNumber taskNumber)
        {
            return taskNumber.ToString();
        }

        public static explicit operator int(TaskNumber taskNumber)
        {
            return taskNumber.nr;
        }

        public static TaskNumber operator +(TaskNumber tn, int num)
        {
            TaskNumber taskNumber = new TaskNumber(tn.prefix, tn.nr + num);
            taskNumber.Suffix = tn.Suffix;
            return taskNumber;
        }

        public static TaskNumber Parse(string inputString)
        {
            int num = 0;
            string sufix = null;
            if (!inputString.Contains("/"))
            {
                throw new FormatException("Nieprawidłowy format nr. Brak znaku /");
            }
            int poz = inputString.IndexOf("/");
            string prefix = inputString.Substring(0, poz);
            int poz2 = inputString.IndexOf("/", poz + 1);
            if (poz2 == -1)
            {
                num = int.Parse(inputString.Substring(poz + 1));
            }
            else
            {
                inputString = inputString.Substring(poz + 1);
                poz = inputString.IndexOf("/");
                num = int.Parse(inputString.Substring(0, poz));
                sufix = inputString.Substring(poz + 1);
            }
            TaskNumber newTaskNumber = new TaskNumber(prefix, num);
            newTaskNumber.Suffix = sufix;
            return newTaskNumber;
        }
    }
}
