using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
    public partial class NotificacionsITV : Form
    {
        List<MissatgeITV> missatgesITVs;
        public NotificacionsITV(List<MissatgeITV> missatgeit)
        {
            InitializeComponent();
            this.missatgesITVs = missatgeit;
            gnListNoti();
        }

        public void gnListNoti()
        {
            foreach (MissatgeITV missatge in missatgesITVs)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ""+missatge.Matricula+": " + missatge.Missatge;
                listNoti.Items.Add(item);
            }
        }
    }
}
