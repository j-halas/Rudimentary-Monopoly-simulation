using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly2
{
    class Gra
    {
        int il_graczy, il_tur,doubles, max_doubles;
        Plansza plansza = new Plansza();
        List<Gracz> gracze = new List<Gracz>();
        Kosci kosc1=new Kosci(), kosc2=new Kosci();
        Random random = new Random();
        bool doubles_check;

        public int Lim_tur { get; set; }

        public void DodajGracza(Gracz gracz)
        {
            if (il_graczy == 4)
            {
                Console.WriteLine("Wiecej graczy dodac nie mozna");
            }
            else
            {
                gracze.Add(gracz);
                il_graczy++;
            }
        }

        public void Graj()
        {
            Console.WriteLine("Podaj limit tur, tylko zeby byl nie wiekszy niz 1000");
            Lim_tur = Console.Read();
            ConsoleKeyInfo decyzja = new ConsoleKeyInfo();
            while (!(decyzja.Key == ConsoleKey.Escape)&&il_tur<=Lim_tur)
            {
                Console.Clear();
                il_tur++;
                Console.WriteLine("Tura nr " + il_tur+"\n");
                foreach (Gracz gracz in gracze)
                {
                    if (!gracz.Bankrut)
                    {
                        do
                        {
                            if (!gracz.Jailed)
                            {
                                doubles_check = gracz.RuszSiem(kosc1, kosc2, random);
                            }
                            gracz.Wyswietl(plansza);
                            plansza.pola[gracz.Pozycja].Dzialaj(gracz, random);
                            if (doubles_check)
                            {
                                doubles++;
                                Console.WriteLine("Doubles! " + gracz.Imie + " rzuca jeszcze raz.\n");

                            }
                            

                        } while ((doubles < max_doubles) && doubles_check && !gracz.Bankrut && !gracz.Jailed);
                        if (doubles == max_doubles)
                        {
                            Console.WriteLine("3 doubles z rzedu, gracz " + gracz.Imie + " idzie do wiezienia!");
                            gracz.DoWiezienia();
                        }
                        Console.WriteLine();
                        doubles = 0;


                    }
                }
                    Console.WriteLine("Wcisnij dowolny przycisk by zasymulowac nastepna ture lub escape by zakonczyc");
                    decyzja = Console.ReadKey(true);
                
            }
            Console.WriteLine("Koniec symulacji");
        }

         public Gra(Plansza taplansza)
        {
            Lim_tur = 50;
            max_doubles = 3;
            plansza = taplansza;
        }
    }
}
