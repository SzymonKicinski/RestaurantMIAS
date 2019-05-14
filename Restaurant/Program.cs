using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {
        static Zamówienie zamówienie;
        static Menu menu;
        public List<PozycjaZamówienia> pozycjeZamówienia = new List<PozycjaZamówienia>();
        static List<Danie> menuD = new List<Danie> {
           new Danie { Nazwa="Żurek", Cena=4 },
           new Danie { Nazwa="Zestaw obiadowy - Schabowy", Cena=14 },
           new Danie { Nazwa="Placki", Cena=10 }
        };


        static void Main(string[] args)
        {
            int option = 0;

            while (option != 9)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Nowy klient");
                Console.WriteLine("2. Dodaj danie do klienta");
                Console.WriteLine("3. Edytuj klienta");
                Console.WriteLine("4. Wydrukuj potwierdzenie zapłaty");

                Console.WriteLine("--");
                Console.WriteLine("9. Wyjście");
                Console.WriteLine("==================================================");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                option = KeyToInt(keyInfo);

                Console.Clear();
                switch (option)
                {
                    case 1:
                        NowyKlient();
                        break;
                    case 2:
                       // DodajPozycję();
                        break;
                    case 3:
                        // EdycjaZamówienia();
                        break;
                    case 4:
                        WyświetlZamówienie();
                        break;
                }
            }
        }


        private static void WyświetlZamówienie()
        {
            Console.WriteLine("Czy potwierdzenie elektorniczne?");
            if (zamówienie.potwierdzenieElektroniczne)
            {
                Console.WriteLine("Potwierdzenie przez drukarkę");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Potwierdzenie przez pocztę email");
                Console.ReadLine();
            }
        }

        private static void NowyKlient()
        {
            Klient nowe = new Klient();

            Console.WriteLine("==================================================");
            Console.WriteLine("Dodawanie nowego klienta");
            Console.WriteLine("==================================================");

            Console.WriteLine("Data Zamówienia:");
            while (!DateTime.TryParse(Console.ReadLine(), out nowe.dataRealizacji))
            {
                Console.WriteLine("Nieprawidłowy format daty");
            }

            Console.WriteLine("Rezerwacja?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option2 = 0;
            while (option2 != 1 && option2 != 2)
            {
                option2 = KeyToInt(Console.ReadKey());
            }
            nowe.rezerwacja = option2 == 1;

            Console.WriteLine("Wydać numerek do szatni?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option3 = 0;
            while (option3 != 1 && option3 != 2)
            {
                option3 = KeyToInt(Console.ReadKey());
            }
            nowe.numerek = option3 == 1;

            Console.WriteLine("Pokaż menu");
            int counter = 0;
            int displayCounter = 1;
            for (int i = 0; counter + i < menuD.Count; ++i)
            {
                displayCounter += i;
                Console.WriteLine("Pozycja numer " + displayCounter);
                Console.WriteLine("Nazwa pozycji " + menuD[i].Nazwa);
                Console.WriteLine("Cena pozycji " + menuD[i].Cena);
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("Podaj numer pozycji z zamówienia do edycji");
            Console.WriteLine("==================================================");
            int pozycjaDoEdycji;
            while (!int.TryParse(Console.ReadLine(), out pozycjaDoEdycji))
            {
                Console.WriteLine("Nieprawidłowy format liczby");
            }

            ///  Console.WriteLine("Płatność kartą?");
            ///  Console.WriteLine("1. Tak");
            ///Console.WriteLine("2. Nie");

            ///            int option = 0;
            ///   while (option != 1 && option != 2)
            /// {
            ///option = KeyToInt(Console.ReadKey());
            /// }
            ///            nowe.potwierdzenieElektroniczne = option == 1;

            // zamówienie = nowe;
            Console.WriteLine(nowe);
        }

        private static int KeyToInt(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
                case ConsoleKey.D4:
                    return 4;
                case ConsoleKey.D5:
                    return 5;
                case ConsoleKey.D6:
                    return 6;
                case ConsoleKey.D7:
                    return 7;
                case ConsoleKey.D8:
                    return 8;
                case ConsoleKey.D9:
                    return 9;
                default:
                    return 0;
            }
        }
    }
}
