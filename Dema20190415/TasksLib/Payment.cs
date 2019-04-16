using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public delegate decimal CalcInterest(decimal amount);
    public delegate void Overpaid(object sender, decimal amount);

    public class Payment : ToDoItem
    {
        public decimal Amount { get; private set; }
        public CalcInterest calculator;
        public event Overpaid OnOverPaid;
        public event EventHandler OnPaid;

        public Payment(string title, decimal amount) : base(title)
        {
            Amount = amount;
        }

        public void Refund(decimal amount)
        {
            Amount -= amount;

            OnPaid?.Invoke(this, new EventArgs());

            if ((Amount <0) && (OnOverPaid != null) )
            {
                OnOverPaid(this, Amount);
            }

        }

        public void Interest()
        {
            if (calculator != null)
                Amount += calculator(Amount);
        }

        //public delegate decimal calk(decimal amount, DateTime date);
        //public void Interest3 (calk calculator)
        //{

        //}


        public void Interest2(
            Func<decimal, DateTime, decimal> calc)
        {
            Amount += calc(Amount, DueDate);
        }

        public override string ItemInfo()
        {
            string info = $"Payment: {ItemID}, {Title}, " +
                $"DueDate:{DueDate}, amount: {Amount}," +
                $" completed: {Completed}";
            return info;
        }
    }
}
