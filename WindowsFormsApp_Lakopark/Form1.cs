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

namespace WindowsFormsApp_Lakopark
{
    public partial class Form1 : Form
    {
        HappyLiving happyLiving = new HappyLiving(@"..\..\lakoparkok.txt");
        readonly int buttonSize = 40;
        int CurrentPark = 0;
        List<Image> szintek = new List<Image>();

        public Form1()
        {
            InitializeComponent();
        }
        void PanelUpdate()
        {
            this.Text = happyLiving.Lakoparkok[CurrentPark].Nev + " lakópark";
            if (CurrentPark == 0)
            {
                button_Left.Enabled = false;
                button_Left.Hide();
            }
            else if (CurrentPark == happyLiving.Lakoparkok.Count - 1)
            {
                button_Right.Enabled = false;
                button_Right.Hide();
            }
            else
            {
                button_Left.Enabled = true;
                button_Left.Show();
                button_Right.Enabled = true;
                button_Right.Show();

            }
            pictureBox_StreetName.BackgroundImage = happyLiving.Lakoparkok[CurrentPark].ImageName;
            pictureBox_StreetName.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Street.Controls.Clear();
            for (int i = 0; i < happyLiving.Lakoparkok[CurrentPark].Hazak.GetLength(1); i++)
            {
                for (int j = 0; j < happyLiving.Lakoparkok[CurrentPark].Hazak.GetLength(0); j++)
                {
                    //-- Létrehozás ----------------------------------
                    Button g = new Button();
                    g.BackgroundImage = szintek[happyLiving.Lakoparkok[CurrentPark].Hazak[j, i]];
                    g.BackgroundImageLayout = ImageLayout.Stretch;
                    g.SetBounds(i * buttonSize, j * buttonSize, buttonSize, buttonSize);
                    //-- eseménykezelés ------------------------------
                    int utca = j;
                    int haz = i;
                    g.Click += (o, e) =>
                    {
                        happyLiving.Lakoparkok[CurrentPark].HouseLevel(utca, haz);
                        PanelUpdate();
                    };
                    panel_Street.Controls.Add(g);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            szintek.Add(Image.FromFile(@"..\..\Kepek\kereszt.jpg"));  
            szintek.Add(Image.FromFile(@"..\..\Kepek\Haz1.jpg"));     
            szintek.Add(Image.FromFile(@"..\..\Kepek\Haz2.jpg"));    
            szintek.Add(Image.FromFile(@"..\..\Kepek\Haz3.jpg"));   
            PanelUpdate();
        }




        private void button_Mentes_Click(object sender, EventArgs e)
        {
            if (happyLiving.Mentes())
            {
                MessageBox.Show("Sikeres Mentés");
            }
            else
            {
                MessageBox.Show("Adatok mentése nem sikerült!");
            }
        }

        private void button_Balra_Click_1(object sender, EventArgs e)
        {
            CurrentPark--;
            PanelUpdate();
        }

        private void button_Jobbra_Click_1(object sender, EventArgs e)
        {
            CurrentPark++;
            PanelUpdate();
        }
    }
}
