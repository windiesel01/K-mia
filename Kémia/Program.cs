using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Kémia
{
    internal class Program
    {

        public static List<adatok> lista = new List<adatok>();

        static void Main(string[] args)
        {
            using (StreamReader beolvasas = new StreamReader("felfedezesek.csv"))
            {
                beolvasas.ReadLine();
                while (!beolvasas.EndOfStream)
                {
                    lista.Add(new adatok(beolvasas.ReadLine()));
                }
            }

            Console.Write($"3. feladat: {lista.Count}");

            Console.WriteLine($"\n4. feladat: Felfedezések száma az ókorban: {lista.Count(a => a.Ev == "Ókor")}");

            Console.Write("5. feladat: ");
            string vegyjel = vegyjelbekeres();

            Console.Write("6. feladat: Keresés");
            kereses(lista, vegyjel);

            Console.Write("7. feladat: ");
            HosszKettoElemKozt();

            Console.Write("8. feladat: Statisztika\n ");
            TobbMintHaromElem();

            Console.ReadKey();

        }

        private static void TobbMintHaromElem()
        {
            lista.GroupBy(a => a.Ev).Where(b => b.Count() > 3 && b.Key != "Ókor").ToList().ForEach(c => Console.WriteLine($"\t{c.Key}: {c.Count()} db"));
        }

        private static string vegyjelbekeres()
        {
            string abc = @"^[a-zA-Z]+$";
            Regex kereses = new Regex(abc);
            Match match;

            string vegyjel;

            do
            {
                Console.Write("Kérek egy vegyjelet: ");
                vegyjel = Console.ReadLine();

                match = kereses.Match(vegyjel);

            } while (!(vegyjel.Length == 1 || vegyjel.Length == 2) && match.Success);

            return vegyjel;
        }

        private static void kereses(List<adatok> lista, string vegyjel)
        {
            bool vane = false;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Vegyjel.ToUpper() == vegyjel.ToUpper())
                {
                    vane = true;
                    Console.WriteLine("\n\tAz elem vegyjele: " + lista[i].Vegyjel);
                    Console.WriteLine("\tAz elem neve: " + lista[i].Elem);
                    Console.WriteLine("\tRendszáma: " + lista[i].Rendszam);
                    Console.WriteLine("\tFelfedezés éve: " + lista[i].Ev);
                    Console.WriteLine("\tFelfedező: " + lista[i].Felfedezo);
                }
            }

            if (!vane)
            {
                Console.WriteLine("\n\tNincs ilyen elem az adatbázisban!");
            }
        }

        private static void HosszKettoElemKozt()
        {
            int LHEv = 0;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                if (lista[i].Ev != "Ókor")
                {
                    if (Convert.ToInt32(lista[i + 1].Ev) - Convert.ToInt32(lista[i].Ev) > LHEv)
                    {
                        LHEv = Convert.ToInt32(lista[i + 1].Ev) - Convert.ToInt32(lista[i].Ev);
                    }
                }
            }
            Console.WriteLine($"{LHEv} év volt a leghosszabb időszak két elem felfedezése között.");
        }
    }
}
