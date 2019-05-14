using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class PozycjaZamówienia
    {
        public int numer;
        public string nazwaPozycji;
        public double cena;
        public double ilość;

        public double ObliczWartośćPozycji() { return ilość * cena; }
    }
}


