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
        string id_Proveedor;
        public fmProveedores(string prv_idProveedor, string prv_nombre, string prv_celular, string prv_servicios, string prv_direccion, string prv_email)
        {
            InitializeComponent();
            id_Proveedor = prv_idProveedor;
            txtNombreProveedor.Text = prv_nombre;
            txtCelular.Text = prv_celular;
            txtServicios.Text = prv_servicios;
            txtDireccion.Text = prv_direccion;
            txtEmail.Text = prv_email;
            btnAgregarProveedor.Enabled = false;
            txtNombreProveedor.Enabled = false;
            txtServicios.Enabled = false;
            btnModificarProveedor.Enabled = true;
        }
        fmVerProveedores Proveedores;
        string sentencia;
        CsConexion conexion;
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

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (txtNombreProveedor.Text == "" || txtCelular.Text == "" || txtDireccion.Text == "" || txtEmail.Text == "" || txtServicios.Text == "")
                MessageBox.Show("Algunos campos están vacíos");
            else
            {
                sentencia = "Insert into Proveedores (prv_nombre, prv_celular, prv_servicios, prv_direccion, prv_email) " +
                    "Values ('" + txtNombreProveedor.Text + "', '" + txtCelular.Text + "', '" + txtServicios.Text + "', '" + txtDireccion.Text + "', '" + txtEmail.Text + "')";
                conexion = new CsConexion();
                conexion.Ingresar_Modificar(sentencia);
                MessageBox.Show("Proveedor Agregado Exitosamente :D");
                this.Hide();
                Proveedores = new fmVerProveedores();
                Proveedores.ShowDialog();

            }
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "" || txtCelular.Text == "" || txtEmail.Text == "")
                MessageBox.Show("Algunos campos están vacíos");
            else
            {
                sentencia = "Update Proveedores set prv_direccion = '" + txtDireccion.Text + "', prv_celular = '" + txtCelular.Text + "', prv_email = '" + txtEmail.Text + "' where id_proveedor = '" + id_Proveedor + "'";
                conexion = new CsConexion();
                conexion.Ingresar_Modificar(sentencia);
                MessageBox.Show("Proveedor Modificado Exitosamente :D");
                this.Hide();
                Proveedores = new fmVerProveedores();
                Proveedores.ShowDialog();
            }
        }
    }
}
