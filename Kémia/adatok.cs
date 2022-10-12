using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kémia
{
    internal class adatok
    {
        string ev;
        string elem;
        string vegyjel;
        int rendszam;
        string felfedezo;

        public string Ev { get => ev; set => ev = value; }
        public string Elem { get => elem; set => elem = value; }
        public string Vegyjel { get => vegyjel; set => vegyjel = value; }
        public int Rendszam { get => rendszam; set => rendszam = value; }
        public string Felfedezo { get => felfedezo; set => felfedezo = value; }

        public adatok(string ev, string elem, string vegyjel, int rendszam, string felfedezo)
        {
            Ev = ev;
            Elem = elem;
            Vegyjel = vegyjel;
            Rendszam = rendszam;
            Felfedezo = felfedezo;
        }

        public adatok(string sor)
        {
            string[] tomb = sor.Split(';');
            Ev = tomb[0];
            Elem = tomb[1];
            Vegyjel = tomb[2];
            Rendszam = int.Parse(tomb[3]);
            Felfedezo = tomb[4];

        }
    }
}
