using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2
{
    class IdzDoWiezienia:Special
    {
        public override void Dzialaj(Gracz gracz,Random random)
        {
            Console.WriteLine("O nie, gracz " + gracz.Imie + " idzie do wiezienia!");
            gracz.DoWiezienia();
        }

        public IdzDoWiezienia()
        {
            nazwa = "Idz do wiezienia";
        }
    }
}
