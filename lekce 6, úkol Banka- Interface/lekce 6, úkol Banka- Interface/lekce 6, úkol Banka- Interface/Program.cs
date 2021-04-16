using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekce_6__úkol_Banka__Interface
{
    //1. Vytvořte interface IUcet, který bude mít property Zustatek s get (bez set) a property Vlastnik s get (také bez set)
    //2. Vytvořte třídu Ucet, která bude dědit interface IUcet, implementovat properties Zustatek (get i set) a Vlastník, který bude nastaven jen z konstruktoru.
    //	a) Vytvořte konstruktor Uctu, který bude brát jako parametry jméno vlastníka a počáteční zůstatek.
    //3. Vytvořte třídu Banka, která bude mít funkci ZalozUcet s parametry počátečního zůstatku a jména vlastníka.
    //	a) Vytvořte bance funkci NajdiUcet, která vrátí IUcet podle jména vlastníka.
    //	b) Vytvořte bance funkci UložPeníze, která přidá do účtu vlastníka odpovídající obnos.
    //4. Vytvořte program, který bude mít instanci Banky, vytvoří 3 účty (nemusíte dělat načítání z konzole, klidně v kodu vytvořit)
    //5. Vypište aktuální stav účtů v Bance
    //6. Uložte do jednoho účtu další peníze a opět vypište aktuální stav účtů
    //7. Získejte jeden účet z Banky do proměnné typu IUcet pomocí NajdiUcet.Nesmí mu jít změnit Zustatek, musí jít jedině přes příkaz v bance :)
    class Program
    {
        static void Main(string[] args)
        {
            Banka banka = new Banka();
            banka.ZalozUcet("Lada", 100000);
            banka.ZalozUcet("Angel", 200000);
            banka.ZalozUcet("Lucius", 50000);


            //Dictionary<string, Ucet> slovnikUctu = new Dictionary<string, Ucet>();
            //Ucet ucet1 = new Ucet("Lada", 100000);
            //Ucet ucet2 = new Ucet("Angel", 200000);
            //Ucet ucet3 = new Ucet("Lucius", 50000);

            //slovnikUctu.Add(ucet1.Vlastnik, ucet1);
            //slovnikUctu.Add(ucet2.Vlastnik, ucet2);
            //slovnikUctu.Add(ucet3.Vlastnik, ucet3);

            //foreach (string vlastniciUctu in seznamUctu.Keys)
            //{
            //    Ucet ucet = slovnikUctu[vlastniciUctu];
            //    Console.WriteLine("Vlastník účtu: {0}, zůstatek: {1}", vlastniciUctu, ucet.Zustatek);
            //}

            //Console.WriteLine();
            //Console.WriteLine("Aktuální stavy účtů:");
            //foreach (Ucet ucet in seznamUctu.Values)
            //{
            //    Console.WriteLine("{0}", ucet.Zustatek);
            //}



            banka.ZobrazInformaceOUctech();
            banka.ZalozUcetNačtenímZKonzole();
            banka.ZobrazInformaceOUctech();
            banka.NajdiUcet("Lada");
            banka.UlozPenize("Angel", 500);
            banka.ZobrazInformaceOUctech();


            // banka obsahuje ucty vsech lidi na svete
            // hackera pokousejiciho se hackovat Ladu se nepovedlo dohledat
            // banka ma nastesti nejlepsi zabezpeceni a hacker svuj umysl zvladl jen okomentovat
            IUcet hackovanyUcet = banka.NajdiUcet("Lada");
            //hackovanyUcet.Zustatek = 0; // nejde, jde jen cist hodnota


            Console.ReadLine();
        }
    }
}
