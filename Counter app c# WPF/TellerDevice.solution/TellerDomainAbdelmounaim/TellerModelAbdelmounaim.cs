using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellerDomainAbdelmounaim
{
    public class TellerModelAbdelmounaim
    {
        //Begin Constructors
        public TellerModelAbdelmounaim()
        {
            this._tellerWaarde = 0;
        }
        //End constructors
        //Begin van properties hieronder
        private int _tellerWaarde;

        public int TellerWaarde
        {
            get { return _tellerWaarde; }
            set { _tellerWaarde = value; }
        }

        private bool _statusteller;

        public bool StatusTeller
        {
            get { return _statusteller; }
            set { _statusteller = value; }
        }

        //einde van properties hierboven

        //begin methods
        public void Verhogen()
        {
            this._tellerWaarde = _tellerWaarde + 1;

        }


        public void Resetten()
        {
            this._tellerWaarde = 0;

        }
        public int LeesTeller()
        {
            return this.TellerWaarde;
        }

        public bool SetStatusTeller(bool waarOfVals)
        {
            return  this.StatusTeller = waarOfVals;
            
        }
   
        //End Methods
    }
}
