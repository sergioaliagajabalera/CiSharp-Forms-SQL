using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
            {


                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Usuaris WHERE username=\""+txbUsername.Text+"\"and contrasenya=\""+txtbPassword.Text+"\"", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                Usuari usuari = null;
                while (reader.Read())

                {
                    usuari=new Usuari((String)reader["username"],(String)reader["contrasenya"]);
                }
                reader.Close();
                con.Close();
                if (usuari == null) lError.Text = "Usuari o Contrasenya incorrecta";
                else {
                    Menu f = new Menu(usuari); // This is bad
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
