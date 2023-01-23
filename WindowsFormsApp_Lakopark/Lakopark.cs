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
        readonly int maxHazSzam;
        readonly string nev;
        readonly int utcakSzama;
        private readonly Image imageName;
        public int FirstFullyBuiltStreet = 0;
        public bool ThereIsAFullyBuiltStreet = false;


        public int[,] Hazak { get => hazak; set => hazak = value; }

        public int MaxHazSzam => maxHazSzam;

        public string Nev => nev;

        public int UtcakSzama => utcakSzama;

        public Image ImageName => imageName;

        public Lakopark(string nev, int utcakSzama, int maxHazSzam, int[,] hazak)
        {
            this.Hazak = hazak;
            this.maxHazSzam = maxHazSzam;
            this.nev = nev;
            this.utcakSzama = utcakSzama;
            this.imageName = Image.FromFile(@"..\..\kepek\" + nev + ".jpg");
            BuiltWithHouseFully();
        }

        public void HouseLevel(int utca, int haz)
        {
            hazak[utca, haz] = (hazak[utca, haz] == 3) ? 0 : ++hazak[utca, haz];
        }

        public void BuiltWithHouseFully()
        {
            bool Built;
            for (int i = 0; i < hazak.GetLength(0); i++)
            {
                Built = true;

                for (int j = 0; j < hazak.GetLength(1); j++)
                {
                    if (hazak[i, j] == 0)
                    {
                        Built = false;
                        break;
                    }
                }
                if (Built)
                { 
                    this.ThereIsAFullyBuiltStreet = true;
                    this.FirstFullyBuiltStreet = ++i;
                    break;
                }
            }
        }

    }
}
