using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekce_6__úkol_Banka__Interface
{
    interface IUcet
    {
        // interface pro omezeni pristupu k uctu
        double Zustatek { get; }
        string Vlastnik { get; }

    }
}
