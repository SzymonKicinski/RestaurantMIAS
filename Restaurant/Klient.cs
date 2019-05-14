using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Klient
    {
        public DateTime dataRealizacji = DateTime.Now;
        public bool statusZamówienia = false;
        public string identyfikatorZamówienia = Guid.NewGuid().ToString();
        public List<PozycjaZamówienia> pozycjeZamówienia = new List<PozycjaZamówienia>(); /// Lista dań
        public bool potwierdzenieElektroniczne = true;
        public bool rezerwacja = true;
        public bool numerek;
        public Wieszak wieszak;
        public Zamówienie zamówienie;

       
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
            if (numerek)
            {
                 wieszak.ZwróćNumerek();
            }
        }
        public bool DodajPozycjeZamówienia(PozycjaZamówienia pozycjaZamówienia)
        {
            if (pozycjeZamówienia.Contains(pozycjaZamówienia))
            {
                return false;
            }

            pozycjeZamówienia.Add(pozycjaZamówienia);
            return true;
        }

        public List<PozycjaZamówienia> WyświetlePozycjeZamówienia(Zamówienie zamówienie)
        {
            return pozycjeZamówienia;
        }
    }
}
