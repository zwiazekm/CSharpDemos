using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public delegate decimal CalcInterest(decimal amount);

    public class Payment : ToDoItem
    {
        public decimal Amount { get; private set; }
        public CalcInterest calculator;

        public Payment(string title, decimal amount) : base(title)
        {
            Amount = amount;
        }

        public void Refund(decimal amount)
        {
            Amount -= amount;
        }

        public void Interest()
        {
            if (calculator != null)
                Amount += calculator(Amount);
        }
    }
}
