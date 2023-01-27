using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp_Lakopark
{
    internal class Database
    {
        static public MySqlCommand command;
        static public MySqlConnection connection;

        public Database(string server = "localhost", string user = "root", string password = "", string db = "lakopark")
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Password = password;
            builder.Database = db;
            connection = new MySqlConnection(builder.ConnectionString);
            if (Kapcsolatok())
            {
                command = connection.CreateCommand();
            }
        }

        private void Nyitas()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private void Zaras()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        private bool Kapcsolatok()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public HappyLiving AllLakopark()
        {
            HappyLiving happyliving = new HappyLiving(new List<Lakopark>());
            command.CommandText = "SELECT * FROM lakoparkok;";
            connection.Open();
            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int[] split = Array.ConvertAll(dr.GetString("utca_nagysaga").Split(';'), int.Parse);
                    string[] hazSplit = dr.GetString("hazak").Split(';');
                    int[,] hazak = new int[split[0], split[1]];
                    foreach (string h in hazSplit)
                    {
                        int[] haram = Array.ConvertAll(h.Split(','), int.Parse);
                        hazak[haram[0] - 1, haram[1] - 1] = haram[2];
                    }
                    Lakopark lakopark = new Lakopark(hazak, split[0], dr.GetString("utca_nev"), split[1]);
                    happyliving.Lakoparkok.Add(lakopark);
                }
            }
            connection.Close();
            return happyliving;
        }
        public bool Save(HappyLiving happy)
        {
            foreach (Lakopark item in happy.Lakoparkok)
            {
                string saving = "";
                for (int i = 0; i < item.Hazak.GetLength(0); i++)
                {
                    for (int j = 0; j < item.Hazak.GetLength(1); j++)
                    {
                        if (item.Hazak[i, j] != 0)
                        {
                            saving += $"{i + 1},{j + 1},{item.Hazak[i, j]};";
                        }
                    }
                }
                saving = saving.Remove(saving.Length - 1);
                connection.Open();

                command.CommandText = "UPDATE lakopark SET hazak = @hazak WHERE utca_nev = @utca_nev;";
                command.Parameters.AddWithValue("@utca_nev", item.Nev);
                command.Parameters.AddWithValue("@hazak", saving);

                command.ExecuteNonQuery();
                command.Parameters.Clear();
                connection.Close();
            }
            return true;
        }
    }
}
