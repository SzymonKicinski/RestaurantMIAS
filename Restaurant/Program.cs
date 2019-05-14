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
        public List<PozycjaDanie> pozycjeDań = new List<PozycjaDanie>();
        static List<Danie> menuD = new List<Danie> {
           new Danie { Nazwa="Żurek", Cena=4 },
           new Danie { Nazwa="Zestaw obiadowy - Schabowy", Cena=14 },
           new Danie { Nazwa="Placki", Cena=10 }
        };
        // Lista klientów
        static List<Klient> klienci = new List<Klient>();


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
                       DodajDanieDoKlienta();
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


        private static void WyświetlZamówienie() //TODO
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
            Klient klient = new Klient();
            

            Console.WriteLine("==================================================");
            Console.WriteLine("Dodawanie nowego klienta");
            Console.WriteLine("==================================================");

            Console.WriteLine("Rezerwacja?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option2 = 0;
            while (option2 != 1 && option2 != 2)
            {
                option2 = KeyToInt(Console.ReadKey());
            }
            klient.rezerwacja = option2 == 1;

            Console.WriteLine("Wydać numerek do szatni?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option3 = 0;
            while (option3 != 1 && option3 != 2)
            {
                option3 = KeyToInt(Console.ReadKey());
            }
            klient.numerek = option3 == 1;

            Console.WriteLine("Pokaż menu");
            int counter = 0;
            int displayCounter = 1;
            for (int i = 0; counter + i < menuD.Count; ++i)
            {
                if (menuD[i].Cena > 0)
                {
                    displayCounter += i;
                    Console.WriteLine("Pozycja numer " + displayCounter);
                    Console.WriteLine("Nazwa pozycji " + menuD[i].Nazwa);
                    Console.WriteLine("Cena pozycji " + menuD[i].Cena);
                }
               
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("Podaj numer dania do zamówienia klienta");
            Console.WriteLine("==================================================");
            int pozycjaDoZamowienia;
            while (!int.TryParse(Console.ReadLine(), out pozycjaDoZamowienia))
            {
                Console.WriteLine("Nieprawidłowy format liczby");
            }
            pozycjaDoZamowienia --;
            klient.zamówienie.DodajDanieDoZamówienia(menuD[pozycjaDoZamowienia]);
            int check = 0;
            Console.WriteLine("Dodać kolejne danie do zamówienia?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option4 = 0;
            while (option4 != 1 && option4 != 2)
            {
                if ( check == 1)
                {
                    Console.WriteLine("Dodać kolejne danie do zamówienia?");
                    Console.WriteLine("1. Tak");
                    Console.WriteLine("2. Nie");
                }
                check = 1;
                option4 = KeyToInt(Console.ReadKey());
                if ( option4 == 1 )
                {
                    option4 = 0;
                    Console.WriteLine("==================================================");
                    Console.WriteLine("Podaj numer dania do zamówienia klienta");
                    Console.WriteLine("==================================================");
                    int pozycjaDoZamowienia2;
                    while (!int.TryParse(Console.ReadLine(), out pozycjaDoZamowienia2))
                    {
                        Console.WriteLine("Nieprawidłowy format liczby");
                    }
                    klient.zamówienie.DodajDanieDoZamówienia(menuD[pozycjaDoZamowienia2]);
                }
                else if ( option4 == 2 )
                {
                    option4 = 0;
                    break;
                }
                
                
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
            klienci.Add(klient);
            Console.WriteLine(klient);
        }
        private static void DodajDanieDoKlienta()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Wyswietl listę klientów");
            Console.WriteLine("==================================================");
            int counter = 0;
            int numeryKlientow = 1;
            for ( int i = 0; counter+i<klienci.Count; i++)
            {
                numeryKlientow += i;
                Console.WriteLine("Numer klienta: " + numeryKlientow);
                Console.WriteLine("Numerek z szatni: " + klienci[i].numerek);
                Console.WriteLine("Dania: ");
                for (int d = 0; counter + d < klienci[i].zamówienie.dania.Count; d++)
                {
                    if (klienci[i].zamówienie.dania[d].Cena > 0)
                    {
                        Console.WriteLine("Danie numer: " + d + " " + klienci[i].zamówienie.dania[d].Nazwa);
                        Console.WriteLine("Danie numer: " + d + " " + klienci[i].zamówienie.dania[d].Cena);
                    }
                }
                   
                Console.WriteLine("Rezerwacja: " + klienci[i].rezerwacja);
            }

            // Edycja zamówienia klienta

            // Numer klienta
            Console.WriteLine("======================================================");
            Console.WriteLine("Podaj numer klienta w którym chesz edytować zamówienia?");
            Console.WriteLine("======================================================");
            int numerKlientaWKtórymDokuonujeEdycjiZamownienia;
            while (!int.TryParse(Console.ReadLine(), out numerKlientaWKtórymDokuonujeEdycjiZamownienia))
            {
                Console.WriteLine("Nieprawidłowy format liczby");
            }
            //numerKlientaWKtórymDokuonujeEdycjiZamownienia -= 1;
            
            // Numer dania
            Console.WriteLine("==================================================");
            Console.WriteLine("Podaj numer dania");
            Console.WriteLine("==================================================");
            int danieDoEdycji;
            while (!int.TryParse(Console.ReadLine(), out danieDoEdycji))
            {
                Console.WriteLine("Nieprawidłowy format liczby");
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("Usunąć danie numer: "+danieDoEdycji+"?");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option = 0;
            while (option != 1 && option != 2)
            {
                option = KeyToInt(Console.ReadKey());

                if ( option == 1 )
                {
                    //    klienci[numerKlientaWKtórymDokuonujeEdycjiZamownienia].zamówienie.UsunDanieZZamówienia(klienci[numerKlientaWKtórymDokuonujeEdycjiZamownienia].zamówienie,danieDoEdycji);
                    klienci[numerKlientaWKtórymDokuonujeEdycjiZamownienia].zamówienie.dania[danieDoEdycji].Nazwa = null;
                    klienci[numerKlientaWKtórymDokuonujeEdycjiZamownienia].zamówienie.dania[danieDoEdycji].Cena = 0;
                }
            }

            Console.WriteLine("==================================================");
            Console.WriteLine("Dodać nowe danie do klienta?");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            int option2 = 0;
            while (option2 != 1 && option2 != 2)
            {
                option2 = KeyToInt(Console.ReadKey());
                if ( option2 == 1 )
                {
                    Console.WriteLine("Pokaż menu");
                    int counter2 = 0;
                    int displayCounter = 1;
                    for (int i = 0; counter2 + i < menuD.Count; ++i)
                    {
                        displayCounter += i;
                        Console.WriteLine("Pozycja numer " + displayCounter);
                        Console.WriteLine("Nazwa pozycji " + menuD[i].Nazwa);
                        Console.WriteLine("Cena pozycji " + menuD[i].Cena);
                    }
                    Console.WriteLine("==================================================");
                    Console.WriteLine("Podaj numer dania do zamówienia klienta");
                    Console.WriteLine("==================================================");
                    int pozycjaDoZamowienia;
                    while (!int.TryParse(Console.ReadLine(), out pozycjaDoZamowienia))
                    {
                        Console.WriteLine("Nieprawidłowy format liczby");
                    }
                    pozycjaDoZamowienia--;
                    klienci[numerKlientaWKtórymDokuonujeEdycjiZamownienia].zamówienie.DodajDanieDoZamówienia(menuD[pozycjaDoZamowienia]);
                    int check = 0;
                    Console.WriteLine("Dodać kolejne danie do zamówienia?");
                    Console.WriteLine("1. Tak");
                    Console.WriteLine("2. Nie");
                    int option4 = 0;
                    while (option4 != 1 && option4 != 2)
                    {
                        if (check == 1)
                        {
                            Console.WriteLine("Dodać kolejne danie do zamówienia?");
                            Console.WriteLine("1. Tak");
                            Console.WriteLine("2. Nie");
                        }
                        check = 1;
                        option4 = KeyToInt(Console.ReadKey());
                        if (option4 == 1)
                        {
                            option4 = 0;
                            Console.WriteLine("==================================================");
                            Console.WriteLine("Podaj numer dania do zamówienia klienta");
                            Console.WriteLine("==================================================");
                            int pozycjaDoZamowienia2;
                            while (!int.TryParse(Console.ReadLine(), out pozycjaDoZamowienia2))
                            {
                                Console.WriteLine("Nieprawidłowy format liczby");
                            }
                            klienci[numerKlientaWKtórymDokuonujeEdycjiZamownienia].zamówienie.DodajDanieDoZamówienia(menuD[pozycjaDoZamowienia2]);
                        }
                        else if (option4 == 2)
                        {
                            option4 = 0;
                            break;
                        }
                    }
                }
            }
                       

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
