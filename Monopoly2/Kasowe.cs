using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2
{
    class Kasowe:Special
    {
        protected int kasa;
        public override void Dzialaj(Gracz gracz, Random random)
        {
            if (kasa > 0)
            {
                Console.WriteLine("Gracz " + gracz.Imie + " otrzymal " + kasa + " dolarow");
            }
            else if (kasa < 0)
            {
                Console.WriteLine("Gracz " + gracz.Imie + " stracil " + -kasa + " dolarow");
            }
            gracz.DodajMamone(kasa);
        }

        public Kasowe(string tanazwa, int tkasa)
        {
            nazwa = tanazwa;
            kasa = tkasa;
        }
    }
}
