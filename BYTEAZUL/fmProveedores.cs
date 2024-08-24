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
    public partial class fmProveedores : Form
    {
        public fmProveedores()
        {
            InitializeComponent();
        }
        fmVerProveedores Proveedores;
        private void btnProductos_Click(object sender, EventArgs e)
        {
            fmProductos Productos = new fmProductos();
            this.Hide();
            Productos.ShowDialog();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            fmMovimientos Movimientos = new fmMovimientos();
            this.Hide();
            Movimientos.ShowDialog();
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            fmMenu Menu = new fmMenu();
            this.Hide();
            Menu.ShowDialog();
        }

        private void btnMimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVerProveedor_Click(object sender, EventArgs e)
        {
            Proveedores = new fmVerProveedores();
            this.Hide();
            Proveedores.Show();
        }

        private void btnProductos_MouseMove(object sender, MouseEventArgs e)
        {
            lblProductos.Visible = true;
        }

        private void btnProductos_MouseLeave(object sender, EventArgs e)
        {
            lblProductos.Visible = false;
        }

        private void btnMovimientos_MouseMove(object sender, MouseEventArgs e)
        {
            lblMovimientos.Visible = true;
        }

        private void btnMovimientos_MouseLeave(object sender, EventArgs e)
        {
            lblMovimientos.Visible = false;
        }

        private void btnVentas_MouseMove(object sender, MouseEventArgs e)
        {
            lblVentas.Visible = true;
        }

        private void btnVentas_MouseLeave(object sender, EventArgs e)
        {
            lblVentas.Visible = false;
        }

        private void btnCaja_MouseMove(object sender, MouseEventArgs e)
        {
            lblCaja.Visible = true;
        }

        private void btnCaja_MouseLeave(object sender, EventArgs e)
        {
            lblCaja.Visible = false;
        }

        private void btnEmpleados_MouseMove(object sender, MouseEventArgs e)
        {
            lblEmpleados.Visible = true;
        }

        private void btnEmpleados_MouseLeave(object sender, EventArgs e)
        {
            lblEmpleados.Visible = false;
        }

        private void btnClientes_MouseMove(object sender, MouseEventArgs e)
        {
            lblClientes.Visible = true;
        }

        private void btnClientes_MouseLeave(object sender, EventArgs e)
        {
            lblClientes.Visible = false;
        }

        private void btnCerrarSesion_MouseMove(object sender, MouseEventArgs e)
        {
            lblCerrarSesion.Visible = true;
        }

        private void btnCerrarSesion_MouseLeave(object sender, EventArgs e)
        {
            lblCerrarSesion.Visible = false;
        }
    }
}
