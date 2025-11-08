using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stat = new List<_House>();
            var h1 = new _House("abdelmounaim", "Laken", 2019, 250000, Housetype.Appartement);
            var h2 = new _House("Vriendin", "Evere", 2005, 270000, Housetype.Rijhuis);
            var h3 = new _House("Collega", "Etterbeek", 1995, 290000, Housetype.Rijhuis);
            var h4 = new _House("Bakker", "Schaarbeek", 2009, 140000, Housetype.Halfopen);
            var h5 = new _House("Slager", "Brussel", 1995, 290000, Housetype.Halfopen);
            var h6 = new _House("Kleermaker", "Schaarbeek", 1995, 100000, Housetype.Halfopen);
            var h7 = new _House("abdelmounaim", "Laken", 2019, 250000, Housetype.Appartement);
            var h8 = new _House("abdelmounaim", "Laken", 2019, 250000, Housetype.Appartement);
            //
            var h9 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var h10 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var h11 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var h12 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var h13 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var h14 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var h15 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var h16 = new _House("Hulk", "Brussel", 1970, 160000, Housetype.Halfopen);

            stat.Add(h1);
            stat.Add(h2);
            stat.Add(h3);
            stat.Add(h4);
            stat.Add(h5);
            stat.Add(h6);
            stat.Add(h7);
            stat.Add(h8);
            stat.Add(h9);
            stat.Add(h10);
            stat.Add(h11);
            stat.Add(h12);
            stat.Add(h13);
            stat.Add(h14);
            stat.Add(h15);
            stat.Add(h16);

            var op = new HouseOperations(stat);
            Console.WriteLine("Alle huizen die meer kosten dan €150.000,00");
            foreach(_House h in op.Exercise1())
            {
                Console.WriteLine(h.Eigenaar);
            }
            Console.WriteLine("Alle huizen die minder kosten dan €175.000,00 en die na 2010 gebouwd zijn");
            foreach (_House h in op.Exercise2())
            {
                Console.WriteLine(h.Eigenaar);
            }
            Console.WriteLine("alle gemeenten in de lijst");
            foreach (string h in op.Exercise3())
            {
                Console.WriteLine(h);
            }
            Console.WriteLine("de gemeenten waarin een appartement te vinden is");
            foreach (string h in op.Exercise4())
            {
                Console.WriteLine(h);
            }
            Console.WriteLine("De gemiddelde prijs van de halfopen bebouwingen.");
            Console.WriteLine(op.Exercise5());
            Console.WriteLine("Oefening9");

          
            Console.ReadLine();

        }
    }
}
