using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{

    //private, internal, public 
    public class ToDoItem
    {
        private static int lastID;
        protected int ItemID;
        private string title;
        public DateTime DueDate { get; set; }
        public DateTime? StartDate { get; set; }
        //Konstruktor
        public ToDoItem(string title)
        {
            ItemID = NewId();
            this.title = title;
            DueDate = DateTime.Now;
        }

        public ToDoItem(string title, DateTime date)
        {
            ItemID = NewId();
            this.title = title;
            DueDate = date;
        }

        public string ItemInfo()
        {
            string info = $"Id: {ItemID}, {title}, " +
                $"DueDate:{DueDate}, completed: {Completed}";
            return info;
        }

        public void Complete()
        {
            Completed = true;
        }

        private static int NewId()
        {
            return ++lastID;
        }

        public static int ToDoCount()
        {
            return lastID;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length == 0)
                {
                    throw new FormatException("Ciąg zerowej długości.");
                }
                title = value;
            }
        }

        public bool Completed { get; private set; }
    }
}
