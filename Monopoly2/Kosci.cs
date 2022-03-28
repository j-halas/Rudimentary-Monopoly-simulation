using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2
{
    class Kosci
    {
        int il_scian;

        int Il_scian
        {
            set
            {

                il_scian = value;
            }
                
        }

        public int Rzuc(Random random)
        {
            return random.Next(il_scian)+1;
        }

        public Kosci()
        {
            Il_scian = 6;
        }
        public Kosci(int Tailosc)
        {
            Il_scian = Tailosc;
        }
    }
}
