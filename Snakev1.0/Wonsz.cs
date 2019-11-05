using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snakev1._0
{
   public class Wonsz
    {
        public int KierunekXWonsza { get; set; }
        public int KierunekYWonsza { get; set; }
        public int DlugoscWonsza { get; set; }
        public int PredkoscWonsza { get; set; }
        public int WonszX { get; set; }
        public int WonszY { get; set; }
        public int SzerokoscPlanszy { get; set; }
        public int WysokoscPlanszy { get; set; }
        public int XJabka { get; set; }
        public int YJabka { get; set; }



        public void RysujWonsza()
        {

            SprawdzKolizjeWonsza();
            Console.SetCursorPosition(WonszX, WonszY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");
            Thread.Sleep(PredkoscWonsza);
        }

        public void KasujWonsza()
        {
            Console.SetCursorPosition(WonszX, WonszY);
            Console.Write(" ");
        }

        public void SprawdzKolizjeWonsza()
        {
            if (WonszX < 1) WonszX = 1;
            if (WonszY < 1) WonszY = 1;
            if (WonszX > SzerokoscPlanszy - 2) WonszX = SzerokoscPlanszy - 2;
            if (WonszY > WysokoscPlanszy) WonszY = WysokoscPlanszy;

            if ((WonszX == XJabka) && (WonszY == YJabka))
            {
                DlugoscWonsza++;
                LosujJabko();
                if (PredkoscWonsza > 100) PredkoscWonsza -= 10;
            }

            
        }
        public void LosujJabko()
        {
            Random rnd = new Random();
            
            
            int losujXjabka = rnd.Next(1, SzerokoscPlanszy - 2);
            int losujYjabka = rnd.Next(1, WysokoscPlanszy);
            
            
            
            
            XJabka = losujXjabka;
            YJabka = losujYjabka;

            Console.SetCursorPosition(losujXjabka, losujYjabka);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ó");
        }

    }
}
