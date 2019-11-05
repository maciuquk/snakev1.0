using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakev1._0
{
   public class Plansza
    {
        public int SzerokoscPlanszy { get; set; }
        public int WysokoscPlanszy { get; set; }

        
        public void RysujPlansze()
        {
            for (int i = 0; i < SzerokoscPlanszy; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int j = 0; j < WysokoscPlanszy; j++)
            {
                Console.Write("*");

                for (int k = 0; k < SzerokoscPlanszy - 2; k++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine("*");
            }
            for (int l = 0; l < SzerokoscPlanszy; l++)
            {
                Console.Write("*");
            }

        }

        
    }
}
