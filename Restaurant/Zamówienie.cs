using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Zamówienie
    {

        public bool statusZamówienia = false;
        public string identyfikatorZamówienia = Guid.NewGuid().ToString();
        public List<PozycjaDanie> pozycjeDań = new List<PozycjaDanie>();
        public List<Danie> dania = new List<Danie>();
        public bool potwierdzenieElektroniczne = true;


        public double WartośćZamówienia()
        {
            double wartość = 0;
            foreach (var pozycja in pozycjeDań)
            {
                wartość += pozycja.ObliczWartośćPozycji();
            }

            return wartość;
        }
        
        public bool OpłaćZamówienie(Płatność płatność)
        {
            płatność.Zapłać(this);
            statusZamówienia = true;
            return statusZamówienia;
        }
        
        public bool DodajDanieDoZamówienia(Danie danie)
        {

            if (dania.Contains(danie))
            {
                return false;
            }
            dania.Add(danie);
            return true;
        }

        public void UsunDanieZZamówienia(Zamówienie zamówienie, int numerDaniaDoUsuniecia)
        {
            if (numerDaniaDoUsuniecia != null )
            {
                zamówienie.dania[numerDaniaDoUsuniecia] = null;
            }
        }

        public List<Danie> WyświetlePozycjeZamówienia(Zamówienie zamówienie)
        {
            return zamówienie.dania;
        }
    }
}

