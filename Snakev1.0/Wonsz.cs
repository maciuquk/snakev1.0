using System;
using System.Collections;
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

        Queue dlugiWonsz = new Queue();

        

        public void RysujWonsza()
        {
            dlugiWonsz.Enqueue((WonszX +";"+WonszY).ToString());

            if (dlugiWonsz.Count > DlugoscWonsza)
            {
                string usunieteWspolrzedne = (dlugiWonsz.Dequeue()).ToString();
                string xxTekstowo = usunieteWspolrzedne.Substring(0, usunieteWspolrzedne.IndexOf(";"));
                string yyTekstowo = usunieteWspolrzedne.Substring(usunieteWspolrzedne.IndexOf(";") + 1);

                Console.SetCursorPosition(Convert.ToInt32(xxTekstowo), Convert.ToInt32(yyTekstowo));
                Console.Write(" ");


                // tutaj ma skasować znaka jako ostatniego
            }

            SprawdzKolizjeWonsza(); //rozszerzyć o kolizję wonsza z wonszem
           // Console.SetCursorPosition(WonszX, WonszY);
            
            
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write("*"); 
            foreach (var wspolrzedneWonsza in dlugiWonsz)
            {
                // rozdział stringa na współrzędne wonsza

                 string tekstowo = wspolrzedneWonsza.ToString();
                 string xxTekstowo = tekstowo.Substring(0, tekstowo.IndexOf(";"));
                 string yyTekstowo = tekstowo.Substring(tekstowo.IndexOf(";") + 1);

                
                
              

                Console.SetCursorPosition(Convert.ToInt32(xxTekstowo), Convert.ToInt32(yyTekstowo));
                Console.Write("*");
            }
          


            Thread.Sleep(PredkoscWonsza);
        }

        public void KasujWonsza()
        {
          //  Console.SetCursorPosition(WonszX, WonszY);
          //  Console.Write(" ");
        }

        public void SprawdzKolizjeWonsza()
        {
            if (WonszX < 1) KoniecGry();
            if (WonszY < 1) KoniecGry();
            if (WonszX > SzerokoscPlanszy - 2) KoniecGry();//WonszX = SzerokoscPlanszy - 2;
            if (WonszY > WysokoscPlanszy) KoniecGry();

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
            do
            {
                int losujXjabka = rnd.Next(1, SzerokoscPlanszy - 2);
                XJabka = losujXjabka;
            }
            while (XJabka == WonszX);

            do
            {
                int losujYjabka = rnd.Next(1, WysokoscPlanszy);
                YJabka = losujYjabka;
            }
            while (YJabka == WonszY);

            Console.SetCursorPosition(XJabka, YJabka);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ó");
        }

        public void KoniecGry()
        {
            Console.Clear();
            Plansza plansza = new Plansza();
            plansza.RysujPlansze();
            string koniecGry = "GAME OVER";

            int opoznienie = 50;
            int tendencja = 1;
            do
            {
               
                Console.SetCursorPosition(SzerokoscPlanszy / 2 - koniecGry.Length / 2, WysokoscPlanszy / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(koniecGry);
                Thread.Sleep(opoznienie);
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.SetCursorPosition(SzerokoscPlanszy / 2 - koniecGry.Length / 2, WysokoscPlanszy / 2);
                Console.WriteLine(koniecGry);
                Thread.Sleep(opoznienie);

                if (tendencja == -1) opoznienie--;
                if (tendencja == 1) opoznienie++;

                if (opoznienie > 100) tendencja = -1;
                if (opoznienie < 20) tendencja = 1;


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.Spacebar:
                            Environment.Exit(0);
                            break;


                    }
                }


                } while (true);
        }

    }
}
