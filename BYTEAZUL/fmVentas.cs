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
    public partial class fmVentas : Form
    {
        CsConexion conexion;
        public fmVentas()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            fmProductos Productos = new fmProductos();
            this.Hide();
            Productos.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            fmProveedores Proveedores = new fmProveedores();
            this.Hide();
            Proveedores.ShowDialog();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            fmMovimientos Movimientos = new fmMovimientos();
            this.Hide();
            Movimientos.ShowDialog();
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

        private void btnProductos_MouseMove(object sender, MouseEventArgs e)
        {
            lblProductos.Visible = true;
        }

        private void btnProductos_MouseLeave(object sender, EventArgs e)
        {
            lblProductos.Visible = false;
        }

        private void btnProveedores_MouseMove(object sender, MouseEventArgs e)
        {
            lblProveedores.Visible = true;
        }

        private void btnProveedores_MouseLeave(object sender, EventArgs e)
        {
            lblProveedores.Visible = false;
        }

        private void btnMovimientos_MouseMove(object sender, MouseEventArgs e)
        {
            lblMovimientos.Visible = true;
        }

        private void btnMovimientos_MouseLeave(object sender, EventArgs e)
        {
            lblMovimientos.Visible = false;
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

        private void fmVentas_Load(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            conexion.abrirconexion();
            string cadena = "Select id_ventas As ID, vt_Fecha_de_venta As [Fecha de venta], id_clientes As Clientes, id_empleado As Empleado, vt_total As Total from Ventas";
            DataSet ds = conexion.Insertinto(cadena);
            dgvVentas.DataSource = ds.Tables["dsretorna"];
            conexion.cerrarconexion();
            for (int i = 0; i < dgvVentas.Columns.Count; i++)
            {
                dgvVentas.Columns[i].Width = dgvVentas.Width / dgvVentas.Columns.Count - 1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            conexion.abrirconexion();
            string cadena = "Select id_ventas As ID, vt_Fecha_de_venta As [Fecha de venta], id_clientes As Clientes, id_empleado As Empleado, vt_total As Total from Ventas where id_ventas = '" + txtBuscar.Text +
                "' or vt_Fecha_de_venta = '" + txtBuscar.Text + "' or id_clientes = '" + txtBuscar.Text + "' or id_empleado = '" + txtBuscar.Text + "' or vt_total = '" + txtBuscar.Text + "'";
            DataSet ds = conexion.Insertinto(cadena);
            dgvVentas.DataSource = ds.Tables["dsretorna"];
            conexion.cerrarconexion();
        }
    }
}
