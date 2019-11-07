using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snakev1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int szerokoscPlanszy = 20;
            int wysokoscPlanszy = 15;
            int dlugoscWonsza = 1;
            int kierunekXWonsza = 1;
            int kierunekYWonsza = 0;
            int wonszX = szerokoscPlanszy / 2;
            int wonszY = wysokoscPlanszy / 2;
            int predkoscWonsza = 300;
            Console.CursorVisible = false;
                       
            Plansza plansza = new Plansza();
            plansza.SzerokoscPlanszy = szerokoscPlanszy;
            plansza.WysokoscPlanszy = wysokoscPlanszy;
            plansza.RysujPlansze();

            Wonsz wonsz = new Wonsz();
            wonsz.KierunekXWonsza = kierunekXWonsza;
            wonsz.KierunekYWonsza = kierunekYWonsza;
            wonsz.DlugoscWonsza = dlugoscWonsza;
            wonsz.WonszX = wonszX;
            wonsz.WonszY = wonszY;
            wonsz.SzerokoscPlanszy = szerokoscPlanszy;
            wonsz.WysokoscPlanszy = wysokoscPlanszy;
            wonsz.PredkoscWonsza = predkoscWonsza;

            wonsz.LosujJabko();

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            kierunekXWonsza = -1;
                            kierunekYWonsza = 0;
                            break;
                            
                        case ConsoleKey.RightArrow:
                            kierunekXWonsza = 1;
                            kierunekYWonsza = 0;
                            break;
                            
                        case ConsoleKey.UpArrow:
                            kierunekXWonsza = 0;
                            kierunekYWonsza = -1;
                            break; 
                            
                        case ConsoleKey.DownArrow:
                            kierunekXWonsza = 0;
                            kierunekYWonsza = 1;
                            break;  
                            
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;


                    }

                

                }

                wonsz.WonszX = wonsz.WonszX + kierunekXWonsza;
                wonsz.WonszY = wonsz.WonszY + kierunekYWonsza;
                wonsz.RysujWonsza();
                
                wonsz.KasujWonsza();
            }


        }
    }
}
