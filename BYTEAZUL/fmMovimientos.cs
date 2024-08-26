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
    public partial class fmMovimientos : Form
    {
        CsConexion conexion;
        public fmMovimientos()
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

        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            





        }

        private void fmMovimientos_Load(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            //Insertinto
            DataSet ds = conexion.Insertinto("Select id_empleado as [ID Empleado], mov_accion as [Acción Realizada], mov_hora as Hora, mov_fecha as Fecha from Movimientos");
            dgvMovimientos.DataSource = ds.Tables["dsretorna"];
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.RowHeadersVisible = false;

            // Ajustar las columnas para que se llenen el ancho del DataGridView
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            if(!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                DataSet ds = conexion.Insertinto("Select id_empleado as [ID Empleado], mov_accion as [Acción Realizada], mov_hora as Hora, mov_fecha as Fecha from Movimientos where id_empleado like '%" + txtBuscar.Text + "%' or mov_accion like '%" + txtBuscar.Text + "%' or  mov_hora like '%" + txtBuscar.Text + "%' or mov_fecha like '%" + txtBuscar.Text + "%'");

                dgvMovimientos.DataSource = ds.Tables["dsretorna"];
                dgvMovimientos.ReadOnly = true;
                dgvMovimientos.AllowUserToAddRows = false;
                dgvMovimientos.RowHeadersVisible = false;
                // Ajustar las columnas para que se llenen el ancho del DataGridView
                dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
        }
    }
}
