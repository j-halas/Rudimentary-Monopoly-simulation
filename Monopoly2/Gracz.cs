using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2
{
    class Gracz
    {
        string imie;
        int pozycja;
        int last_rzut1, last_rzut2;
        public List<Nieruchomosc> posiadlosci = new List<Nieruchomosc>();



        public string Imie
        {
            get
            {
                return imie;
            }
            private set
            {
                if (value.Length > 2 && value.Length < 9)
                {
                    imie = value;
                }
                else if (value.Length > 8)
                {
                    imie = value.Substring(0,8);
                }
                else if (value.Length < 3)
                {
                    Random random = new Random();
                    Kosci kosc = new Kosci(99);
                    imie = "Gracz" + kosc.Rzuc(random).ToString();
                }
            }
        }
        public int Pozycja
        {
            get
            {
                return pozycja;
            }
            internal set
            {
                if ((value >= 0) && (value < 40))
                {
                    pozycja = value;
                }
                else if (value > 40)
                {
                    pozycja = value%40;
                }
            }
        }
        public int PozycjaDL //dla ludzi
        {
            get
            {
                return pozycja + 1;
            }
        }

        public bool Bankrut { get; private set; }
        public int Tury_w_kiciu { set; get; }
        public int Mamona { get; private set; }
        public bool Jailed { get; set; }

        public void DoWiezienia()
        {
            Pozycja = 9;
            Jailed = true;
        }

        public bool RuszSiem(Kosci kosc, Random random)
        {
            last_rzut1 = kosc.Rzuc(random);
            Pozycja = Pozycja + last_rzut1;
            return false;
        }
        public bool RuszSiem(Kosci kosc1, Kosci kosc2, Random random)
        {
            last_rzut1 = kosc1.Rzuc(random);
            last_rzut2 = kosc1.Rzuc(random);
            Pozycja = Pozycja + (last_rzut1 + last_rzut2);
            if (last_rzut1 == last_rzut2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Bankrutuj()
        {
            Console.WriteLine("Gracz " + Imie + " zbankrutowal!");
            Bankrut = true;
            foreach(Nieruchomosc posiadlosc in posiadlosci)
            {
                posiadlosc.ZwrocDoBanku();
            }
        }
        public void DodajMamone(int kasa)
        {
            Mamona += kasa;
            if (Mamona < 0)
            {
                Bankrutuj();
            }
        }
        public bool Decyduj(Random random)
        {
            Kosci moneta = new Kosci(2);
            int rzut = moneta.Rzuc(random)-1;
            if (rzut==1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Wyswietl(Plansza plansza)
        {
            if (!Jailed)
            {
                Console.Write(nameof(Pozycja) + " gracza " + Imie + " po wyrzuceniu " + last_rzut1);
                if (last_rzut2 != 0)
                {
                    Console.Write(" i " + last_rzut2);
                }
                Console.WriteLine(": " + plansza.pola[Pozycja].Nazwa);
            }
            else
            {
                Console.WriteLine("Gracz " + Imie + " jest w wiezieniu");
            }
            Console.WriteLine("Stan jego portfela wynosi " + Mamona);
        }
        public Gracz(string toimie)
        {
            Imie = toimie;
            last_rzut1 = 0;
            last_rzut2 = 0;
            Mamona = 2000;
            Jailed = false;
            Bankrut = false;
            Tury_w_kiciu = 0;
        }
        public Gracz()
        {
            Imie = "no";
            last_rzut1 = 0;
            last_rzut2 = 0;
            Mamona = 2000;
            Jailed = false;
            Bankrut = false;
            Tury_w_kiciu = 0;
        }
    }
}
