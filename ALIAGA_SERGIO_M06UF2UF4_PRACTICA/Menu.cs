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
    public partial class Menu : Form
    {
        Usuari usuari;
        List<Cotxe> cotxes;
        List<Moto> motos;
        List<MissatgeITV> missatgesITVs;
        BindingSource sourceCotxe = new BindingSource();
        BindingSource sourceMoto = new BindingSource();
        public Menu(Usuari usuari)
        {
            InitializeComponent();
            this.usuari = usuari;
            tx_User.Text = this.usuari.username;
            cotxes = new List<Cotxe>();
            motos = new List<Moto>();
            missatgesITVs = new List<MissatgeITV>();
            dbVehicles();

            txbITV_matricula.Enabled = false;
        }

        public void dbVehicles()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Cotxes C, Vehicles V where (C.matricula = V.matricula) and V.propietari = \""+this.usuari.username+"\"", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cotxe cotxe = new Cotxe((String)reader["matricula"], (String)reader["propietari"], (String)reader["marca"], (String)reader["model"]
                       , (int)reader["caballs"], (String)reader["motor"], (String)reader["t_neumatics"], (Boolean)reader["binfoITV"], (String)reader["t_sostre"], (String)reader["t_porta"]);
                    cotxes.Add(cotxe);
                }
                reader.Close();

                this.fillDataGridViewCotxe(dtGridView_cotxes, cotxes);

                cmd = new MySqlCommand("select * from Motos M, Vehicles V where (M.matricula = V.matricula) and V.propietari = \"" + this.usuari.username + "\"", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Moto moto = new Moto((String)reader["matricula"], (String)reader["propietari"], (String)reader["marca"], (String)reader["model"]
                       , (int)reader["caballs"], (String)reader["motor"], (String)reader["t_neumatics"], (Boolean)reader["binfoITV"], (String)reader["t_cupula"], (Boolean)reader["bmaleta"]);
                    motos.Add(moto);
                }
                reader.Close();

                this.fillDataGridViewMoto(dtGridView_motos,motos);

                cmd = new MySqlCommand("select * from MissatgesITV M, Vehicles V where (M.matricula = V.matricula) and V.propietari = \"" + this.usuari.username + "\"", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MissatgeITV missatgeITV = new MissatgeITV((String)reader["matricula"], (String)reader["missatge"]);
                    missatgesITVs.Add(missatgeITV);
                }
                reader.Close();
                if (missatgesITVs.Count > 0) {
                    lk_notifi.Text="NOTIFICACIONS ("+missatgesITVs.Count+")";
                    lk_notifi.Visible = true;
                 };
                con.Close();

            }
        }

        private void dtGridView_cotxes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int row = e.RowIndex;
            if (row <0) row =0;
            if (cotxes.Count > 0)
            {
                groupCotxe.Enabled = true;
                groupMoto.Enabled = false;
                txbITV_matricula.Text = dtGridView_cotxes.Rows[row].Cells["matricula"].FormattedValue.ToString();
                txbITV_matricula.Enabled = false;
                tbMatricula.Enabled = false;
                tbCupula.Text = "";
                tbMaleta.Checked = false;

                this.fillinFormBasic(dtGridView_cotxes.Rows[row]);
                tbT_sostre.Text = dtGridView_cotxes.Rows[row].Cells["T_sostre"].FormattedValue.ToString();
                tbT_porta.Text = dtGridView_cotxes.Rows[row].Cells["T_porta"].FormattedValue.ToString();
            }
        }

        private void lk_notifi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NotificacionsITV f = new NotificacionsITV(missatgesITVs); // This is bad
            f.ShowDialog();
        }

        private void dtGridView_motos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) row = 0;
            if (motos.Count > 0)
            {
                groupMoto.Enabled = true;
                groupCotxe.Enabled = false;
                txbITV_matricula.Text = dtGridView_motos.Rows[row].Cells["matricula"].FormattedValue.ToString();
                txbITV_matricula.Enabled = false;
                tbMatricula.Enabled = false;
                tbT_sostre.Text = "";
                tbT_porta.Text = "";
                this.fillinFormBasic(dtGridView_motos.Rows[row]);
                tbCupula.Text= dtGridView_motos.Rows[row].Cells["t_cupula"].FormattedValue.ToString();
                tbMaleta.Checked = Convert.ToBoolean(dtGridView_motos.Rows[row].Cells["Bmaleta"].FormattedValue.ToString());

            }
        }

        private void btSendMITV_Click(object sender, EventArgs e)
        {
            if(cotxes.FirstOrDefault(t => t.Matricula == txbITV_matricula.Text && t.BinfoITV==true)!=null || motos.FirstOrDefault(t => t.Matricula == txbITV_matricula.Text && t.BinfoITV == true) != null)
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
                {

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into MissatgesITV(matricula,missatge)values(\""+txbITV_matricula.Text+"\", \""+txbITV_missatge.Text+"\") ", con);
                    int nRowsAffect=cmd.ExecuteNonQuery();
                    lk_notifi.Text = "hola";
                    if (nRowsAffect > 0)
                    {
                        MissatgeITV missatgeITV = new MissatgeITV(txbITV_matricula.Text, txbITV_missatge.Text);
                        missatgesITVs.Add(missatgeITV);
                        lk_notifi.Visible = true;
                        lk_notifi.Text = "NOTIFICACIONS (" + missatgesITVs.Count() + ")";
                        txbITV_matricula.Text = "";
                        txbITV_missatge.Text = "";
                    }
                    con.Close();
                }

            }
        }

        private void btClearITV_Click(object sender, EventArgs e)
        {
            if (missatgesITVs.Count > 0)
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
                {
                    con.Open();
                    foreach (MissatgeITV missatge in missatgesITVs) {

                        MySqlCommand cmd = new MySqlCommand("delete from MissatgesITV where matricula=\""+ missatge.Matricula+"\"", con);
                        cmd.ExecuteNonQuery();  
                    }
                    con.Close();
                }
                missatgesITVs.Clear();
                lk_notifi.Visible = false;
            }
        }

        private void ClearMessageITVVehicle(String matricula)
        {
            if (missatgesITVs.Count > 0)
            {
                List<MissatgeITV> tempMissatge = new List<MissatgeITV>();
                tempMissatge.AddRange(missatgesITVs.Where(t => t.Matricula == matricula));
                foreach (MissatgeITV missatge in tempMissatge) missatgesITVs.Remove(missatge);
                if (missatgesITVs.Count > 0) lk_notifi.Text = "NOTIFICACIONS (" + missatgesITVs.Count + ")";
                else lk_notifi.Visible = false;
            }
        }

        private void fillinFormBasic(DataGridViewRow dataGridViewRow)
        {
            tbMatricula.Text = dataGridViewRow.Cells["matricula"].FormattedValue.ToString();
            tbMarca.Text = dataGridViewRow.Cells["marca"].FormattedValue.ToString();
            tbModel.Text= dataGridViewRow.Cells["model"].FormattedValue.ToString();
            tbCaballs.Value = Convert.ToDecimal(dataGridViewRow.Cells["caballs"].FormattedValue.ToString());
            tbMotor.Text = dataGridViewRow.Cells["motor"].FormattedValue.ToString();
            tbNeumatics.Text = dataGridViewRow.Cells["t_neumatics"].FormattedValue.ToString();
            tbInfoITV.Checked = Convert.ToBoolean(dataGridViewRow.Cells["binfoITV"].FormattedValue.ToString());
        }

        private void btClearForm_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void clearForm() {
            //enables
            tbMatricula.Enabled = true;
            groupCotxe.Enabled = true;
            groupMoto.Enabled = true;

            // clear form basic
            tbMatricula.Text = "";
            tbMarca.Text = "";
            tbModel.Text = "";
            tbCaballs.Value = 0;
            tbMotor.Text = "";
            tbNeumatics.Text = "";
            tbInfoITV.Checked = false;

            //clear form Moto
            tbCupula.Text = "";
            tbMaleta.Checked = false;

            //clear form Cotxe
            tbT_sostre.Text = "";
            tbT_porta.Text = "";

        }

        
        private void fillDataGridViewCotxe(DataGridView dataGridViewCotxe, List<Cotxe> cotxe)
        {
            sourceCotxe.DataSource = cotxe;
            dataGridViewCotxe.DataSource = null;
            dataGridViewCotxe.Refresh();
            dataGridViewCotxe.DataSource = sourceCotxe.DataSource;
        }
        private void fillDataGridViewMoto(DataGridView dataGridViewMoto, List<Moto> moto)
        {
            sourceMoto.DataSource = moto;
            dataGridViewMoto.DataSource = null;
            dataGridViewMoto.Refresh();
            dataGridViewMoto.DataSource = sourceMoto.DataSource;
        }


        private void btDeleteForm_Click(object sender, EventArgs e)
        {
            if (tbMatricula.Enabled == false) {
                using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("delete from Vehicles where matricula=\"" + tbMatricula.Text + "\"", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (cotxes.FirstOrDefault(t => t.Matricula == tbMatricula.Text) != null)
                {
                    Cotxe cotxe = cotxes.FirstOrDefault(t => t.Matricula == tbMatricula.Text);
                    cotxes.Remove(cotxe);
                    this.fillDataGridViewCotxe(dtGridView_cotxes, cotxes);
                }
                else
                {
                    Moto moto = motos.FirstOrDefault(t => t.Matricula == tbMatricula.Text);
                    motos.Remove(moto);
                    this.fillDataGridViewMoto(dtGridView_motos, motos);
                }
                this.ClearMessageITVVehicle(tbMatricula.Text);
                txbITV_matricula.Clear();
                txbITV_missatge.Clear();
                this.clearForm();
            }
        }

        private void btAddForm_Click(object sender, EventArgs e)
        {
            if (tbMatricula.Enabled == true && tbMatricula.Text!="" && (tbT_sostre.Text!="" || tbCupula.Text!=""))
            {
                if (cotxes.FirstOrDefault(t => t.Matricula == tbMatricula.Text) == null)
                {
                    if (motos.FirstOrDefault(t => t.Matricula == tbMatricula.Text) == null)
                    {
                        using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
                        {
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("insert into Vehicles(matricula, propietari, marca, model, caballs, motor, t_neumatics, binfoITV) values(\"" + tbMatricula.Text + "\", \"" + usuari.username + "\", \"" + tbMarca.Text + "\", \"" + tbModel.Text + "\"," + Decimal.ToInt32(tbCaballs.Value) + ", \"" + tbMotor.Text + "\",\"" + tbNeumatics.Text + "\", " + tbInfoITV.Checked + ")", con);
                            int nRowsAffect = cmd.ExecuteNonQuery();
                            
                            if (nRowsAffect > 0)
                            {
                                if (tbT_sostre.Text != "")
                                {
                                    MySqlCommand cmd2 = new MySqlCommand("insert into Cotxes(matricula, t_sostre, t_porta) values(\"" + tbMatricula.Text + "\", \"" + tbT_sostre.Text + "\", \"" + tbT_porta.Text + "\")", con);
                                    int nRowsAffect2 = cmd2.ExecuteNonQuery();
                                    if (nRowsAffect2 > 0)
                                    {
                                        Cotxe cotxe = new Cotxe(tbMatricula.Text, usuari.username, tbMarca.Text, tbModel.Text, Decimal.ToInt32(tbCaballs.Value), tbMotor.Text, tbNeumatics.Text, tbInfoITV.Checked, tbT_sostre.Text, tbT_porta.Text);
                                        cotxes.Add(cotxe);
                                        fillDataGridViewCotxe(dtGridView_cotxes, cotxes);
                                        clearForm();
                                    }
                                }
                                else
                                {
                                    if (nRowsAffect > 0)
                                    {
                                        MySqlCommand cmd2 = new MySqlCommand("insert into Motos(matricula, t_cupula, bmaleta)values(\""+tbMatricula.Text+"\", \""+tbCupula.Text+"\", "+tbMaleta.Checked+")", con);
                                        int nRowsAffect2 = cmd2.ExecuteNonQuery();
                                        if (nRowsAffect2 > 0)
                                        {
                                            Moto moto = new Moto(tbMatricula.Text, usuari.username, tbMarca.Text, tbModel.Text, Decimal.ToInt32(tbCaballs.Value), tbMotor.Text, tbNeumatics.Text, tbInfoITV.Checked, tbCupula.Text,tbMaleta.Checked);
                                            motos.Add(moto);
                                            fillDataGridViewMoto(dtGridView_motos, motos);
                                            clearForm();
                                        }
                                    }
                                }

                            }
                            con.Close();
                        }
                    }
                }
            }
        }

        private void btUpdateForm_Click(object sender, EventArgs e)
        {
            if (tbMatricula.Enabled != true && (tbT_sostre.Text != "" || tbCupula.Text != ""))
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost;" + "user=adminm09uf4;" + "database=ALIAGA_SERGIO_M09UF4_PRACTICA;" + "port=3306;" + "password=adminm09uf4"))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE Vehicles SET  marca=\"" + tbMarca.Text + "\", model=\"" + tbModel.Text + "\",caballs=" + Decimal.ToInt32(tbCaballs.Value) + ",motor=\"" + tbMotor.Text + "\", t_neumatics=\"" + tbNeumatics.Text + "\",binfoITV=" + tbInfoITV.Checked + " WHERE matricula=\"" + tbMatricula.Text + "\"", con);
                    cmd.ExecuteNonQuery();
                    if (tbT_sostre.Text != "")
                    {
                        MySqlCommand cmd2 = new MySqlCommand("UPDATE  Cotxes SET t_sostre=\"" + tbT_sostre.Text + "\",t_porta=\"" + tbT_porta.Text+"\" WHERE matricula=\"" + tbMatricula.Text + "\"", con);
                        int nRowsAffect2 = cmd2.ExecuteNonQuery();

                        var cotxeRef=cotxes.FirstOrDefault(x => x.Matricula == tbMatricula.Text);
                        cotxeRef.Matricula=tbMatricula.Text;
                        cotxeRef.Marca = tbMarca.Text;
                        cotxeRef.Model = tbModel.Text;
                        cotxeRef.Caballs = Decimal.ToInt32(tbCaballs.Value);
                        cotxeRef.Motor = tbMotor.Text;
                        cotxeRef.T_neumatics = tbNeumatics.Text;
                        cotxeRef.BinfoITV = tbInfoITV.Checked;
                        cotxeRef.T_sostre = tbT_sostre.Text;
                        cotxeRef.T_porta = tbT_porta.Text;
                        fillDataGridViewCotxe(dtGridView_cotxes, cotxes);
                        clearForm();
                    }
                    else
                    {
                        MySqlCommand cmd2 = new MySqlCommand("UPDATE  Motos SET t_cupula=\"" + tbCupula.Text + "\",bmaleta=" + tbMaleta.Checked+ " WHERE matricula=\"" + tbMatricula.Text + "\"", con);
                        cmd2.ExecuteNonQuery();
                        var motoRef= motos.FirstOrDefault(x => x.Matricula == tbMatricula.Text);
                        motoRef.Matricula = tbMatricula.Text;
                        motoRef.Marca = tbMarca.Text;
                        motoRef.Model = tbModel.Text;
                        motoRef.Caballs = Decimal.ToInt32(tbCaballs.Value);
                        motoRef.Motor = tbMotor.Text;
                        motoRef.T_neumatics = tbNeumatics.Text;
                        motoRef.BinfoITV = tbInfoITV.Checked;
                        motoRef.T_cupula = tbCupula.Text;
                        motoRef.Bmaleta = tbMaleta.Checked;
                        fillDataGridViewMoto(dtGridView_motos, motos);
                        clearForm();
                    }
                    con.Close();
                }
            }
        }
    }
}
