using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Gotówka : Płatność
    {
        public override void Zapłać(Zamówienie zamówienie)
        {
            Console.WriteLine("Płacenie gotówką");
        }

    }
}


