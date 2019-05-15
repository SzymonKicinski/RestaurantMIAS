using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Klient
    {
        public bool statusZamówienia = false;
        public string identyfikatorZamówienia = Guid.NewGuid().ToString();
        public List<PozycjaDanie> pozycjaDanie = new List<PozycjaDanie>(); /// Lista pozycjiDań
        public List<Danie> dania = new List<Danie>();
        public bool potwierdzenieElektroniczne = true;
        public bool rezerwacja = true;
        public int numerek;
        public Wieszak wieszak;
        public Zamówienie zamówienie = new Zamówienie();

       
        public bool OpłaćZamówienie(Płatność płatność)
        {
            płatność.Zapłać(zamówienie);
            statusZamówienia = true;
            return statusZamówienia;
        }
        public void Rezerwacja()
        {
            if (rezerwacja)
            {
                new Karta().WydrukPotwierdzenia();
            }
        }

        public void WydajNumerekZSzatni()
        {
            if (numerek == 1 || numerek == 2)
            {
                 wieszak.ZwróćNumerek();
            }
        }
        

        public List<Danie> WyświetlePozycjeZamówienia(Zamówienie zamówienie)
        {
            return zamówienie.dania;
        }
    }
}
