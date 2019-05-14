using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Zamówienie
    {
        public DateTime dataRealizacji = DateTime.Now;
        public bool statusZamówienia = false;
        public string identyfikatorZamówienia = Guid.NewGuid().ToString();
        public List<PozycjaZamówienia> pozycjeZamówienia = new List<PozycjaZamówienia>();
        public bool potwierdzenieElektroniczne = true;


        public double WartośćZamówienia()
        {
            double wartość = 0;
            foreach (var pozycjaZamówienia in pozycjeZamówienia)
            {
                wartość += pozycjaZamówienia.ObliczWartośćPozycji();
            }

            return wartość;
        }
        
        public bool OpłaćZamówienie(Płatność płatność)
        {
            płatność.Zapłać(this);
            statusZamówienia = true;
            return statusZamówienia;
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

