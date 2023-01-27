using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Renci.SshNet.Security;

namespace WindowsFormsApp_Lakopark
{
    public partial class Form1 : Form
    {
        HappyLiving happyLiving = new Database().AllLakopark();
        string imagePath = @"..//../Kepek/";
        int pageNumber = 0;
        int pictureSize = 40;

        public Form1()
        {
            InitializeComponent();
        }
        private void ImageLoad(PictureBox pictureBox, int i, int j)
        {
            string House = imagePath + @"hazak" + happyLiving.Lakoparkok[pageNumber].Hazak[i, j] + ".jpg";
            if (File.Exists(House))
            {
                pictureBox.ImageLocation = House;
            }
            else
            {
                pictureBox.ImageLocation = "..//../Kepek/kereszt.jpg";
            }
        }
        void PanelUpdate(Lakopark lakopark)
        {
            panel_Street.Controls.Clear();
            pictureBox_StreetName.ImageLocation = imagePath + happyLiving.Lakoparkok[pageNumber].Nev + ".jpg";

            for (int i = 0; i < happyLiving.Lakoparkok[pageNumber].MaxhazSzam; i++)
            {
                for (int j = 0; j < happyLiving.Lakoparkok[pageNumber].UtcakSzama; j++)
                {
                    PictureBox picturebox = new PictureBox();
                    picturebox.ImageLocation = "..//../Kepek/kereszt.jpg";
                    picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox.SetBounds(j * pictureSize, i * pictureSize, pictureSize, pictureSize);
                    picturebox.Name = $"{i};{j}";

                    ImageLoad(picturebox, i, j);
                    picturebox.Click += (o, ev) => {
                        PictureBox picture = (PictureBox)o;

                        int[] hazak = Array.ConvertAll(picture.Name.Split(';'), int.Parse);
                        int path_i = hazak[0];
                        int path_j = hazak[1];

                        if (happyLiving.Lakoparkok[pageNumber].Hazak[path_i, path_j] + 1 > 3)
                        {
                            happyLiving.Lakoparkok[pageNumber].Hazak[path_i, path_j] = 0;
                        }
                        else
                        {
                            happyLiving.Lakoparkok[pageNumber].Hazak[path_i, path_j] += 1;
                        }
                        ImageLoad(picturebox, path_i, path_j);

                    };
                    panel_Street.Controls.Add(picturebox);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PanelUpdate(happyLiving.Lakoparkok[pageNumber]);
            nyilak();
        }

        private void button_Mentes_Click(object sender, EventArgs e)
        {
            bool siker = new Database().Save(happyLiving);
        }

        private void nyilak()
        {

            
        }
        private void button_Balra_Click_1(object sender, EventArgs e)
        {
            if (pageNumber - 1 > -1)
            {
                pageNumber--;
            }
            PanelUpdate(happyLiving.Lakoparkok[pageNumber]);
            nyilak();
        }

        private void button_Jobbra_Click_1(object sender, EventArgs e)
        {
            if (pageNumber + 1 < 3)
            {
                pageNumber++;
            }
            PanelUpdate(happyLiving.Lakoparkok[pageNumber]);
            nyilak();
        }
    }
}
