using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GestionInterLigas
{
    internal class conexion
    {



        string cadena1 = ConfigurationManager.ConnectionStrings["MySqlConnection1"].ConnectionString;
        string cadena2 = ConfigurationManager.ConnectionStrings["MySqlConnection2"].ConnectionString;
        string cadena3 = ConfigurationManager.ConnectionStrings["MySqlConnection3"].ConnectionString;
        string cadena4 = ConfigurationManager.ConnectionStrings["MySqlConnection4"].ConnectionString;

        public MySqlConnection conectarbd = new MySqlConnection();

        public conexion(int league_id)
        {
            switch (league_id)
            {
                case 0:
                    conectarbd.ConnectionString = cadena1;
                    break;

                case 1:
                    conectarbd.ConnectionString = cadena2;
                    break;

                case 2:
                    conectarbd.ConnectionString = cadena3;
                    break;

                default:
                    conectarbd.ConnectionString = cadena4;
                    break;

            }
            

        }

        public void abrirconexion()
        {
            try
            {
                conectarbd.Open();
                MessageBox.Show("Conexion abierta");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void cerrarconexion()
        {
            conectarbd.Close();
        }
    }
}
