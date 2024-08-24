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
    public partial class fmMenu : Form
    {
        public fmMenu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e) { Application.Exit(); }

        private void btnMimizar_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            fmProductos Producto = new fmProductos();
            this.Hide();
            Producto.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            fmProveedores Proveedores = new fmProveedores();
            this.Hide();
            Proveedores.ShowDialog();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            fmMovimientos Movmientos = new fmMovimientos();
            this.Hide();
            Movmientos.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            fmVentas Ventas = new fmVentas();
            this.Hide();
            Ventas.ShowDialog();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            fmCaja Caja = new fmCaja();
            this.Hide();
            Caja.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            fmEmpleados Empleados = new fmEmpleados();
            this.Hide();
            Empleados.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            fmClientes Clientes = new fmClientes();
            this.Hide();
            Clientes.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            fmAcceso Acceso = new fmAcceso();
            this.Hide();
            Acceso.ShowDialog();
        }
    }
}
