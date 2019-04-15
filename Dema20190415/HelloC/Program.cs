using System;

namespace Altkom
{
    namespace Szkolenie.DemoC
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Console.WriteLine("Hello World");
                //ZmienneITypy();
                Konwersja();
                Console.ReadLine();
            }

            static void ZmienneITypy()
            {
                //zmienne lokalne
                int zmiennaInt = 10;
                long zmiennaInt64 = 34;
                decimal zmiennaDec = 12.45M;
                string zmiennaTekstowa = "test string";

                //operatory arytmetyczne: +,-, *, /, %
                zmiennaInt64 = 23 + 3 * 5 / 45;

                //inkrementacja: ++, --
                zmiennaInt++; zmiennaInt += 1 ; zmiennaInt = zmiennaInt + 1;
                zmiennaInt64 = ++zmiennaInt; //najpierw powiekszy o 1 potem przypisze
                zmiennaInt64 = zmiennaInt++; //najpierw przypiesz potem powiększy o 1
                
                //operator przypisania: =, +=, -=, *=, /=
                zmiennaInt += 5; zmiennaInt = zmiennaInt + 5;

                //Operator porównania: ==, !=, <, >, <=, >=
                if (zmiennaInt == zmiennaInt64) ;
                bool czyPrawda = zmiennaDec > zmiennaInt;

                //operator logiczny: and(&, &&), or(|, ||), not -> !
                bool sprawdz = (zmiennaInt > zmiennaInt64)
                    || (zmiennaTekstowa != "demo");

                //Operator konkatenacji: +
                string nowyTekst = zmiennaTekstowa + " Demo";

                //Operator terarny. Warunkowy: ?:
                string info = (zmiennaInt <= zmiennaInt64) ? "Ok" : "Nie ok";

            }

            static void Konwersja()
            {
                //Niejawna = Z małego do dużego
                int a = 10;
                long b = a;

                //Jawna - z dużego do małego i pomiędzy niezgodnymi typami
                //operator rzutowania
                int c = (int)b;
                checked
                {
                    b = (long)int.MaxValue + 1;
                    //c = (int)b;
                    Console.WriteLine(c);
                }

                //klasa convert
                int d = 34;
                decimal e = Convert.ToDecimal(d);

                string txtLiczba = "23,45";

                decimal decLiczba = Convert.ToDecimal(txtLiczba);
                Console.WriteLine("decLiczba={0}", decLiczba);
                //Uzycie metody Parse
                txtLiczba = "dskjfsd";
                decLiczba = decimal.Parse(txtLiczba);
                Console.WriteLine("decLiczba={0}", decLiczba);

                //Użycie metody TryParse
                if (!decimal.TryParse(txtLiczba, out decLiczba))
                {
                    Console.WriteLine("Błędna liczba");
                    
                }

            }
        }
    }
}
