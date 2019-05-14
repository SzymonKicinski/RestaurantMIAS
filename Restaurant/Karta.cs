using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Karta : Płatność
    {
        public string kontoBankowe;
        public string tytułPłatności;

        public override void Zapłać(Zamówienie zamówienie)
        {
            Console.WriteLine("Płacenie kartą");
        }
    }
}
