using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekce_6__úkol_Banka__Interface
{
    // ucet dedi z IUcet, aby banka mohla zajistit, ze informace o uctu nejdou zmenit zvenku
    class Ucet : IUcet
{
         public double Zustatek { get; set; }
        public string Vlastnik { get; private set; }

        ////private string vlastnik;
        ////public string Vlastnik
        ////{
        //     get { return vlastnik; }
        //    set { vlastnik = value; }
        //  }

        public Ucet(string jmeno, double pocatecniZustatek)
        {
            Vlastnik = jmeno;
            Zustatek = pocatecniZustatek;
        }

        public override string ToString()
        {
            return Vlastnik.PadRight(10) + "---> " + Zustatek.ToString("0.00");
        }
    }
}
