using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZUL
{
    public partial class fmAcceso : Form
    {
        public fmAcceso()
        {
            InitializeComponent();
            btnOcultar.Visible = false;
            btnVer.Visible = true;
        }
        private void btnSalir_Click(object sender, EventArgs e){Application.Exit();}
        private void btnMimizar_Click(object sender, EventArgs e){this.WindowState = FormWindowState.Minimized;}
        private void btnOcultar_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
            btnOcultar.Visible = false;
            btnVer.Visible = true;
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false;
            btnOcultar.Visible = true;
            btnVer.Visible = false;
        }

        private void btnIniciarsesion_Click(object sender, EventArgs e)
        {
            fmMenu menu = new fmMenu();
            this.Hide();
            menu.ShowDialog();
        }
    }
}
