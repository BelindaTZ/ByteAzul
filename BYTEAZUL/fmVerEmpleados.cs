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
    public partial class fmVerEmpleados : Form
    {
        CsConexion conexion;
        public fmVerEmpleados()
        {
            InitializeComponent();
            
        }
        fmEmpleados Empleados;
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Empleados = new fmEmpleados();
            this.Hide();
            Empleados.Show();
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

        private void btnVenta_Click(object sender, EventArgs e)
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

        private void btnVenta_MouseMove(object sender, MouseEventArgs e)
        {
            lblVentas.Visible = true;
        }

        private void btnVenta_MouseLeave(object sender, EventArgs e)
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

        private void fmVerEmpleados_Load(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            string comando = @"SELECT  id_empleado AS [ID Empleado], em_nombres AS Nombres, em_apellidos AS Apellidos, em_cedula AS Cédula, em_fecha_de_nacimiento AS [Fecha de Nacimiento], em_genero AS Género, 
                            em_cargo AS Cargo, em_fecha_de_ingreso AS [Fecha de Ingreso], em_email AS Email, em_direccion AS Dirección, em_celular AS Celular, em_estado AS Estado 
                            FROM Empleados";
            DataSet ds = conexion.Insertinto(comando);

            dgvVerEmpleados.DataSource = ds.Tables["dsRetorna"];

            dgvVerEmpleados.AllowUserToAddRows = false;
            dgvVerEmpleados.ReadOnly = true;
            dgvVerEmpleados.RowHeadersVisible = false;

            dgvVerEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVerEmpleados.MultiSelect = false;
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            Empleados = new fmEmpleados();
            this.Hide();
            Empleados.Show();
        }

        private void btnModificarEmpleados_Click(object sender, EventArgs e)
        {

            if (dgvVerEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvVerEmpleados.SelectedRows[0];

                string nombre = filaSeleccionada.Cells["Nombres"].Value.ToString();
                string apellido = filaSeleccionada.Cells["Apellidos"].Value.ToString();
                string cedula = filaSeleccionada.Cells["Cédula"].Value.ToString();
                DateTime fechanacimiento = (DateTime)filaSeleccionada.Cells["Fecha de Nacimiento"].Value;
                string genero = filaSeleccionada.Cells["Género"].Value.ToString();
                string cargo = filaSeleccionada.Cells["Cargo"].Value.ToString();
                DateTime fechaingreso = (DateTime)filaSeleccionada.Cells["Fecha de Ingreso"].Value;
                string correo = filaSeleccionada.Cells["Email"].Value.ToString();
                string direccion = filaSeleccionada.Cells["Dirección"].Value.ToString();
                string celular = filaSeleccionada.Cells["Celular"].Value.ToString();
                string estado = filaSeleccionada.Cells["Estado"].Value.ToString();

                fmEmpleados empleado = new fmEmpleados(nombre, apellido, cedula, fechanacimiento, genero, cargo, fechaingreso, correo, direccion, celular, estado);
                this.Hide();
                empleado.Show();
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            string cad = "SELECT id_empleado AS [ID Empleados], em_nombres AS Nombres, em_apellidos AS Apellidos, em_cedula AS Cédula, em_fecha_de_nacimiento AS [Fecha de Nacimiento],  em_genero AS Género,    em_cargo AS Cargo,     em_fecha_de_ingreso AS [Fecha de Ingreso],    em_email AS Email,   em_direccion AS Dirección,    em_celular AS Celular, em_estado AS Estado FROM   Empleados WHERE   em_nombres LIKE '%" + txtBuscar.Text + "%' OR  em_apellidos LIKE '%" + txtBuscar.Text + "%' OR em_cedula LIKE '%" + txtBuscar.Text + "%' OR CONVERT(VARCHAR, em_fecha_de_nacimiento, 103) LIKE '%" + txtBuscar.Text + "%' OR  em_genero LIKE '%" + txtBuscar.Text + "%' OR em_cargo LIKE '%" + txtBuscar.Text + "%' OR CONVERT(VARCHAR, em_fecha_de_ingreso, 103) LIKE '%" + txtBuscar.Text + "%' OR em_email LIKE '%" + txtBuscar.Text + "%' OR em_direccion LIKE '%" + txtBuscar.Text + "%' OR em_celular LIKE '%" + txtBuscar.Text + "%' OR em_estado LIKE '%" + txtBuscar.Text + "%';";
            DataSet ds = conexion.Insertinto(cad);

            dgvVerEmpleados.DataSource = ds.Tables["dsretorna"];
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvVerEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
