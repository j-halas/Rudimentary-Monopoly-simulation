using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2
{
    class Nieruchomosc : Pole
    {
        protected string nazwa;
        protected string wlasciciel;
        protected int cena;
        protected int czynsz;

        public override string Nazwa
        {
            get { return nazwa; }
        }
        public void ZwrocDoBanku()
        {
            
                wlasciciel = "Bank";
            
        }
        public override void Dzialaj(Gracz gracz, Random random)
        {
            if (wlasciciel == "Bank" && gracz.Decyduj(random))
            {
                Console.WriteLine("Gracz " + gracz.Imie + " kupil " + nameof(Nieruchomosc) + " " + Nazwa + " za " + cena + " dolarow");
                wlasciciel = gracz.Imie;
                gracz.DodajMamone(-cena);
                gracz.posiadlosci.Add(this);
            }
        }
        public Nieruchomosc(string tanazwa, int tacena, int tenczynsz)
        {
            wlasciciel = "Bank";
            cena = tacena;
            nazwa = tanazwa;
            czynsz = tenczynsz;
        }
    }
}
