using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Wieszak
    {
        public int Numerek;

        Random rnd = new Random();
        public int ZwróćNumerek() { return rnd.Next(1, 100); }
    }
}
