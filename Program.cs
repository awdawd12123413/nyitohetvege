using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningWeekend
{

    class mozik
    {

        public string eredetiCim { get; set; }
        public string magyarCim { get; set; }
        public DateTime bemutato { get; set; }
        public string forgalmazo { get; set; }
        public double bevetel { get; set; }
        public double latogato { get; set; }
        public mozik(string sor)
        {
            string[] sorelemek = sor.Split(';');
            eredetiCim = sorelemek[0];
            magyarCim = sorelemek[1];
            bemutato = Convert.ToDateTime(sorelemek[2]);
            forgalmazo = sorelemek[3];
            bevetel = Convert.ToDouble(sorelemek[4]);
            latogato = Convert.ToDouble(sorelemek[5]);

           
        }

    }
    class Program
    {
        public static List<mozik> adatok = new List<mozik>();
        static void Main(string[] args)
        {

            StreamReader olvas = new StreamReader("nyitohetvege.txt", Encoding.UTF8);
            string fejlec = olvas.ReadLine();//ha van fejléc
            while (!olvas.EndOfStream)
            {
                adatok.Add(new mozik(olvas.ReadLine()));
            }
            int adatokszama = adatok.Count();



            // 3. 



            Console.WriteLine($"3. feladat: filmek száma az állományban: {adatok.Count} db");

            double seged = 0;
            //4. 

            for (int i = 0; i < adatokszama; i++)
            {
                if (adatok[i].forgalmazo == "UIP")
                {
                    seged = seged + adatok[i].bevetel;
                }
            }
            Console.WriteLine($"4. Feladat : UIP Duna Film forgalmazó 1. hetes bevételeinek összege: {seged} Ft");


            //5.

            double max = 0;
            int max1 = 0;
            for (int i = 1; i < adatokszama; i++)
            {
                if (adatok[i].latogato > max)
                {
                    max = adatok[i].latogato;
                    max1++;
                }
            }
            Console.WriteLine("5. feladat: Legtöbb látogató az első héten:");

            Console.WriteLine($"Eredeti cím: {adatok[max1].eredetiCim}");
            Console.WriteLine($"Magyar cím: {adatok[max1].magyarCim}");
            Console.WriteLine($"Forgalmazó: {adatok[max1].forgalmazo}");
            Console.WriteLine($"Bevétel az első héten: { adatok[max1].bevetel} Ft");
            Console.WriteLine($"Látogatók száma: {adatok[max1].latogato} fő");

            Console.ReadKey();

            }
        }
    }


