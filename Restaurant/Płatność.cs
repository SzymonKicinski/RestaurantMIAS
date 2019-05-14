using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    abstract class Płatność
    {
        public abstract void Zapłać(Zamówienie zamówienie);
        public virtual void WydrukPotwierdzenia()
        {
            Console.WriteLine("Wydruk potwierdzenia");
        }

        protected double kwotaPłatności;
    }
}
