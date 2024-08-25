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
    public partial class fmVerClientes : Form
    {
        fmClientes Clientes;
        CsConexion conexion;
        public fmVerClientes()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Clientes = new fmClientes();
            this.Hide();
            Clientes.Show();
        }

        private void btnMimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            fmAcceso Acceso = new fmAcceso();
            this.Hide();
            Acceso.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            fmEmpleados Empleados = new fmEmpleados();
            this.Hide();
            Empleados.ShowDialog();
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

        private void btnEmpleados_MouseMove(object sender, MouseEventArgs e)
        {
            lblEmpleados.Visible = true;
        }

        private void btnEmpleados_MouseLeave(object sender, EventArgs e)
        {
            lblEmpleados.Visible = false;
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

        private void btnCerrarSesion_MouseMove(object sender, MouseEventArgs e)
        {
            lblCerrarSesion.Visible = true;
        }

        private void btnCerrarSesion_MouseLeave(object sender, EventArgs e)
        {
            lblCerrarSesion.Visible = false;
        }

        private void fmVerClientes_Load(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            string consulta = "Select id_clientes AS [ID Cliente], cl_cedula AS Cédula, cl_nombre AS Nombres, cl_apellido AS Apellidos, cl_Celular AS Celular, cl_Email AS Email, cl_Direccion AS Dirección from Clientes";
            DataSet ds = conexion.Insertinto(consulta);

            dgvVerProductos.DataSource = ds.Tables["dsretorna"];

            dgvVerProductos.ReadOnly = true;
            dgvVerProductos.AllowUserToAddRows = false;
            dgvVerProductos.RowHeadersVisible = false;

            dgvVerProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVerProductos.MultiSelect = false;
        }

        private void btnAgregarClientes_Click(object sender, EventArgs e)
        {
            fmClientes clientes = new fmClientes();
            this.Hide();
            clientes.Show();
        }

        private void btnModificarClientes_Click(object sender, EventArgs e)
        {
            if (dgvVerProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvVerProductos.SelectedRows[0];

                string nombre = filaSeleccionada.Cells["Nombres"].Value.ToString();
                string apellido = filaSeleccionada.Cells["Apellidos"].Value.ToString();
                string cedula = filaSeleccionada.Cells["Cédula"].Value.ToString();
                string correo = filaSeleccionada.Cells["Email"].Value.ToString();
                string direccion = filaSeleccionada.Cells["Dirección"].Value.ToString();
                string celular = filaSeleccionada.Cells["Celular"].Value.ToString();

                fmClientes cliente = new fmClientes(nombre, apellido, cedula, correo, direccion, celular);
                this.Hide();
                cliente.Show();
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                conexion = new CsConexion();
                string comand = "select id_clientes as [ID Clientes] , cl_cedula as Cedula, cl_nombre as Nombre, cl_apellido as Apellido, cl_celular as Celular, cl_email as Email, cl_direccion as Dirección from Clientes where id_clientes like '%" + txtBuscar.Text + "%' or cl_cedula like '%" + txtBuscar.Text + "%' or cl_apellido like '%" + txtBuscar.Text + "%' or cl_celular like '%" + txtBuscar.Text + "%' or cl_email like '%" + txtBuscar.Text + "%' or cl_direccion like '%" + txtBuscar.Text + "%'";
                DataSet ds = conexion.Insertinto(comand);

                dgvVerProductos.DataSource = ds.Tables["dsretorna"];
            }
        }
    }
}
