using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class HouseOperations
    {
        //Klasse members
        public List<_House> Houses;
        //Constructoren
        public HouseOperations(List<_House> houses)
        {
            this.Houses = houses;
        }
        //methodes
        public List<_House> Exercise1()
        {
            IEnumerable<_House> huizen = this.Houses.Where(x => x.Prijs > 150000);
            return huizen.ToList();
        }

        public List<_House> Exercise2()
        {
            IEnumerable<_House> huizen = this.Houses.Where(x => x.Prijs < 175000 && x.Bouwjaar > 2010);
            return huizen.ToList();
        }

        public IEnumerable<string> Exercise3()
        {

            IEnumerable<string> gemeenten = this.Houses.Select(x => x.Gemeente).Distinct();
            return gemeenten;
        }

        public List<string> Exercise4()
        {
            IEnumerable<string> gemeentenMetAppartement_en = this.Houses.Where(x => x.Type.Equals(Housetype.Appartement)).Select(x=>x.Gemeente).Distinct();
            return gemeentenMetAppartement_en.ToList();
        }

        public double Exercise5()
        {
            IEnumerable<double> halfOpenHouses = this.Houses.Where(x => x.Type.Equals(Housetype.Halfopen)).Select(x=>x.Prijs);
            return Math.Round( halfOpenHouses.Sum() / halfOpenHouses.Count(),2);

        }

        public double Exercise6()
        {
            IEnumerable<_House> huizenZonderEigenaars = this.Houses.Where(x => x.Eigenaar==null);
            IEnumerable<double> maxPrijs = huizenZonderEigenaars.Select(x => x.Prijs);
            return maxPrijs.Max();

        }

        public List<_House> Exercise7()
        {
            IEnumerable<_House> drieOudstehuizen = this.Houses.Where(x=>x.Gemeente.Equals("Brussel")).OrderByDescending(x => x.Bouwjaar).Reverse().Take(3);

            return drieOudstehuizen.ToList();
        }

        public int Exercise8()
        {
            IEnumerable<_House> halfopenHuizenvoor2000Gebouwd = this.Houses.Where(x => x.Bouwjaar < 2000&&x.Type==Housetype.Halfopen);
            return halfopenHuizenvoor2000Gebouwd.Count();
        }

        //public List<string> Exercise9() {
        

        //}

        public List<string> Exercise10()
        {
            IEnumerable<string> list = this.Houses.Where(x => x.Prijs > 120000&& x.Type==Housetype.Halfopen).Select(x=>x.Gemeente).Distinct();

            IEnumerable<string> sortAscendingQuery =
            from gemeente in list
            orderby gemeente 
            select gemeente;
            return sortAscendingQuery.ToList(); ;

           
        }
    }
}
