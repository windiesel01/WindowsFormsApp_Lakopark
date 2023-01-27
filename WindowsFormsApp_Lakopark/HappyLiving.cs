using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp_Lakopark
{
    internal class HappyLiving
    {

        List<Lakopark> lakoparkok = new List<Lakopark>();
        private List<Lakopark> lakoparks;

        internal List<Lakopark> Lakoparkok { get => lakoparkok; set => lakoparkok = value; }


        public HappyLiving(List<Lakopark> lakoparks)
        {
            this.lakoparks = lakoparks;
        }

        public bool Mentes()
        {
            bool Success = false;
            try
            {
                File.Copy(@"..\..\lakoparkok.txt", "lakoparkok_" + DateTime.Now.ToString("yyyyMMdd_hhmm") + ".txt");
                using (StreamWriter sw = new StreamWriter(@"..\..\lakoparkok.txt"))
                {
                    foreach (Lakopark item in lakoparkok)
                    {
                        sw.WriteLine(item.Nev);
                        sw.WriteLine(string.Join(";", item.UtcakSzama, item.MaxhazSzam));
                        for (int i = 0; i < item.Hazak.GetLength(0); i++)
                        {
                            for (int j = 0; j < item.Hazak.GetLength(1); j++)
                            {
                                sw.WriteLine(string.Join(";", i, j, item.Hazak[i, j]));
                            }
                        }
                        sw.WriteLine();
                    }
                }

                Success = true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return Success;
        }
    }

}
