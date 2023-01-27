using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace WindowsFormsApp_Lakopark
{
    internal class Lakopark
    {
        int[,] hazak;
        int maxhazSzam;
        string nev;
        int utcakSzama;

        public Lakopark(int[,] hazak, int maxhazSzam, string nev, int utcakSzama)
        {
            this.hazak = hazak;
            this.maxhazSzam = maxhazSzam;
            this.nev = nev;
            this.utcakSzama = utcakSzama;
        }

        public int[,] Hazak { get => hazak; set => hazak = value; }
        public int MaxhazSzam { get => maxhazSzam; set => maxhazSzam = value; }
        public string Nev { get => nev; set => nev = value; }
        public int UtcakSzama { get => utcakSzama; set => utcakSzama = value; }

    }
}
