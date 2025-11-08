using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class _House
    {
        //Constructor
        
        public _House(string eigenaar, string gemeente, int bouwjaar, double prijs, Housetype type)
        {
            this.Eigenaar = eigenaar;
            this.Gemeente = gemeente;
            this.Bouwjaar = bouwjaar;
            this.Prijs = prijs;
            this.Type = type;
        }
        public _House(string gemeente, int bouwjaar, double prijs, Housetype type)
        {
            
            this.Gemeente = gemeente;
            this.Bouwjaar = bouwjaar;
            this.Prijs = prijs;
            this.Type = type;
        }
        //Klasse variabelen-properties
        private string _eigenaar;

        public string Eigenaar
        {
            get { return _eigenaar; }
            set { _eigenaar = value; }
        }


        private string _gemeente;

        public string Gemeente
        {
            get { return _gemeente; }
            set { _gemeente = value; }
        }
        private int _bouwjaar;

        public int Bouwjaar
        {
            get { return _bouwjaar; }
            set { _bouwjaar = value; }
        }

        private Double _prijs;

        public Double Prijs
        {
            get { return _prijs; }
            set { _prijs = value; }
        }

        private Housetype _type;

        public Housetype Type
        {
            get { return _type; }
            set { _type = value; }
        }


    }
}
