using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksLib;

namespace TaskClient
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //ObslugaZadan();
                //ObslugaZadan2();
                //ObslugaZadan3();
                ObslugaZadan4();
                //StruktAndOperatorDemo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Maine exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally main");
            }
        }

        private static void ObslugaZadan4()
        {
            ToDoManager mng = new ToDoManager();
            ITaskManager itm = mng;
            mng.AddTask("Todo 1", DateTime.Now);
            mng.AddPayment("Payment 1", DateTime.Now, 200M);
            mng.AddProjectTask("Projekt task 1", "Demo Project");

            Console.WriteLine("Lista zadań:");
            foreach (var item in mng.TaskList())
            {
                Console.WriteLine(item.ItemInfo());
            }

            Console.WriteLine("Lista opłat:");
            foreach(var item in mng.Payments)
            {
                Console.WriteLine(item.ItemInfo());
            }
        }

        private static void ObslugaZadan3()
        {
            Payment p1 = new Payment("Rata 1", 234M);
            p1.DueDate = DateTime.Now.AddDays(-3);
            p1.calculator += new CalcInterest(Calculator);
            p1.calculator += am =>
            {
                decimal rate = 0.2M;
                return am * rate;
            };
            p1.calculator += am => am * 0.2M;
            p1.OnOverPaid += P1_OnOverPaid;
            p1.OnOverPaid += 
                (S, a) => Console.WriteLine($"Zdarzenie nadpłaty. {a}");
            p1.OnPaid += P1_OnPaid;
            p1.OnPaid += (o, ea) => Console.WriteLine("Zdarzenie spłaty");
            p1.Interest();
            p1.Interest2(Calculator);
            p1.Interest2((am, dd) => am * 0.2M);
            p1.Refund(230);

            Console.WriteLine($"Saldo: {p1.Amount}" );
            p1.Refund(500);
            Console.WriteLine($"Saldo: {p1.Amount}");

        }

        private static void P1_OnPaid(object sender, EventArgs e)
        {
            Console.WriteLine("Wpłacono kwotę");
        }

        private static void P1_OnOverPaid(object sender, decimal amount)
        {
            
            Console.WriteLine($"Wystąpiło zdarzenie nadpłaty. " +
                $"Kwota: {amount}");
        }

        private static decimal Calculator(decimal amount, DateTime dueDate)
        {
            return amount * 0.2M;
        }

        private static decimal Calculator(decimal amount)
        {
            decimal rate = 0.2M;
            return amount * rate;
        }

        private static void StruktAndOperatorDemo()
        {
            TaskNumber nr1 = new TaskNumber();
            //{
            //    number = 1,
            //    prefix = "Test"
            //};
            //Console.WriteLine($"prefix: {nr1.prefix}, nr: {nr1.number}");

            TaskNumber nr2 = "Pref/12/20";
            string strnr = nr2;

            //nr2.prefix = "Test2";
            //nr2.number = 1;
            //nr2.Suffix = "2019";

            TaskNumber nr3 = new TaskNumber("Demo", 4)
            {
                Suffix = "r2p2"
            };
            TaskNumber nr4 = nr2 + 2;
            int a = (int)nr4;
            //Console.WriteLine($"prefix: {nr2.prefix}, nr: {nr2.number}");
            Console.WriteLine(nr1);
            Console.WriteLine(nr2);
            Console.WriteLine(nr3);
            Console.WriteLine(nr4);
            Console.WriteLine($"Tekst z nr2: {strnr}");
            Console.WriteLine($"nr z nr4:{a}");
        }

        static void ObslugaZadan2()
        {
            ShortProject sp1 = new ShortProject();
            sp1.ProjectName = "Test Short Project";
            sp1.DateFrom = DateTime.Parse("2017-04-01");
            sp1.DateTo = DateTime.Parse("2020-05-30");

            ProjectTask pt1 = new ProjectTask("Task 1");
            pt1.Project = sp1;
            pt1.StartDate = DateTime.Now.AddDays(2);
            pt1.DueDate = DateTime.Now.AddDays(30);
            //pt1.Status = "Plan";

            ToDoItem td1 = pt1;
            Console.WriteLine(td1.ItemInfo());
            Console.WriteLine(pt1.ItemInfo());
            Console.WriteLine(td1.CompleteInfo());
            Console.WriteLine(pt1.CompleteInfo());
            Console.WriteLine(pt1);
        }


        private static void ObslugaZadan()
        {
            try
            {
                ToDoItem td1 = new ToDoItem("Todo 1");
                ToDoItem td2 = new ToDoItem("Todo 2", DateTime.Now.AddDays(2));
                ToDoItem td3 = td2;
                ProjectTask pt1 = new ProjectTask("Project task 1");
                ToDoItem td4 = pt1;
                pt1.DueDate = DateTime.Now.AddDays(5);
                //td3.Title = "";
                td1.StartDate = DateTime.Now;
                Console.WriteLine(td1.ItemInfo());
                Console.WriteLine(td2.ItemInfo());
                Console.WriteLine(td3.ItemInfo());
                Console.WriteLine(pt1.ItemInfo());
                //Odwołanie do metody statycznej.
                Console.WriteLine($"Liczba obiektów: {ToDoItem.ToDoCount()}");
                td3.StartDate = DateTime.Now.AddDays(-1);
                if (td3.StartDate.HasValue)
                {
                    DateTime date = (DateTime)td3.StartDate;
                    Console.WriteLine($"Start date td3={date}");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd ogólny: {ex.Message}");
                
            }
            finally
            {
                Console.WriteLine("Blok finally");
            }
            Console.WriteLine("Kod za try catch finally");
        }

        //Przyklady wywoływania metod przeciążonych
        private static void PrzeciazeniaDemo()
        {
            //Obliczenia obl1 = new Obliczenia();
            Obliczenia.Dodaj(12, 41);
            Obliczenia.Dodaj("12,14", "12,56");
            decimal[] liczby = new decimal[3];//Typ tablicowy (Array)
            //Array l = Array.CreateInstance(typeof(decimal), 3);
            decimal[] l = { 12.52M, 123.54M, 1, 52 };
            Obliczenia.Dodaj(l);
            Obliczenia.Dodaj(12M, 45M, 12M, 41M);
        }
    }

    class Obliczenia
    {

        public static decimal Dodaj(decimal liczba1, decimal liczba2)
        {
            return liczba1 + liczba2;
        }

        public static decimal Dodaj(string l1, string l2)
        {
            var liczba1 = decimal.Parse(l1);
            var liczba2 = decimal.Parse(l2);
            return Dodaj(liczba1, liczba2);//Wywołanie pierwszej wersji
        }

        public static decimal Dodaj(params decimal[] liczby)
        {
            decimal wynik = 0M;
            foreach (var item in liczby)
            {
                wynik += item;
            }
            return wynik;
        }

    }
}
