using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksLib;

namespace TaskClient
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ObslugaZadan();
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
