using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekce_6__úkol_Banka__Interface
{
    class Banka
    {
        // slovnik pro vzhledani uctu podle vlastnika
        Dictionary<string, Ucet> slovnikUctu = new Dictionary<string, Ucet>();

        //private Ucet ucet1;
        //private Ucet ucet2;
        //private Ucet ucet3;
        //public Banka()
        //{
        //ucet1 = new Ucet("Lada", 100000);
        //ucet2 = new Ucet("Angel", 200000);
        //ucet3 = new Ucet("Lucius", 50000);
        //}


        // metoda vraci nove vytvoreny ucet, aby vlastnik mohl snadno kontrolovat stav
        public IUcet ZalozUcet(string jmeno, double pocatecniZustatek)
        {
            Ucet novyUcet = new Ucet(jmeno, pocatecniZustatek);
            slovnikUctu.Add(novyUcet.Vlastnik, novyUcet); //tady nemůže být toto: (novyUcet.Vlastnik, novyUcet.Zustatek), parametry totiž po mě chce: string z IUcet, což je Vlastnik a class Ucet

            return novyUcet;

        }

        public IUcet ZalozUcetNačtenímZKonzole()
        {
            Console.WriteLine("Zadej vlastníka účtu: ");
            string novyVlastnik = Console.ReadLine();
            Console.WriteLine("Zadej výchozí částku: ");
            double vychoziCastka = double.Parse(Console.ReadLine());

            Console.WriteLine("Nový uživatel účtu: " + novyVlastnik + ", " + "připsaná částka je: " + vychoziCastka);

            Ucet novyUcet = new Ucet(novyVlastnik, vychoziCastka);
            slovnikUctu.Add(novyUcet.Vlastnik, novyUcet);

            return novyUcet;


        }

        // vraci bud existujici ucet nebo null
        public IUcet NajdiUcet(string vlastnikHledany)
        {
                                                        //Console.WriteLine("Zadej hledaného vlastníka účtu: ");
                                                        //string vlastnik = Console.ReadLine();

            Ucet nalezenyUcet;                          //záloha pro to, aby systém nespadl, když vlastníka nenajde
            if (!slovnikUctu.TryGetValue(vlastnikHledany, out nalezenyUcet))
            {
                Console.WriteLine("Toto jméno není v účtech. ");
            }
            return nalezenyUcet;

            //Ucet nalezenyUcet;
            //slovnikUctu.TryGetValue(vlastnik, out nalezenyUcet);
            //return nalezenyUcet;


        }

        // ulozi penize, pokud ucet existuje, a pokud je vklad zaporny, tak se nic neulozi, odolne proti neznamemu hackerovi
        public void UlozPenize(string vlastnikZBanky, double obnos)
        {
            Ucet nalezenyUcet;

            if (slovnikUctu.TryGetValue(vlastnikZBanky, out nalezenyUcet))
            {
                Console.WriteLine("Vklad na ucet: " + vlastnikZBanky + ", castka: " + obnos);
                nalezenyUcet.Zustatek += obnos;
                //nalezenyUcet.Zustatek += Math.Max(0, vklad); // osetreni, kdyby byl vklad zaporny
            }

            else
            {
                Console.WriteLine("Toto jméno není v bance. ");
            }

        }

        public void ZobrazInformaceOUctech()
        {
            Console.WriteLine("Stav účtů v bance: ");
                                                                        //Console.WriteLine("Vlastník účtu 1: {0}, zůstatek: {1}", ucet1.Vlastnik, ucet1.Zustatek);
                                                                        //Console.WriteLine("Vlastník účtu 2: {0}, zůstatek: {1}", ucet2.Vlastnik, ucet2.Zustatek);
                                                                        //Console.WriteLine("Vlastník účtu 3: {0}, zůstatek: {1}", ucet3.Vlastnik, ucet3.Zustatek);
            Console.WriteLine("-------------------------------------");

            foreach (string vlastniciUctu in slovnikUctu.Keys)                      //tady nemám class Ucet, proto mi s tím nic override string Tostring nic neudělá!
            {
                Ucet ucet = slovnikUctu[vlastniciUctu];
                Console.WriteLine("Vlastník účtu: {0}, \t zůstatek: {1}", vlastniciUctu, ucet.Zustatek);
            }

            foreach (Ucet vlastniciUctu in slovnikUctu.Values)
            {
                Console.WriteLine(vlastniciUctu);
            }

        }


    }
}
