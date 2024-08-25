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
    public partial class fmClientes : Form
    {
        fmVerClientes VerClientes;
        CsConexion conexion;
        bool confir = false;
        public fmClientes()
        {
            InitializeComponent();
        }
        public fmClientes(string nombre, string apellido, string cedula, string correo, string direccion, string celular)
        {
            InitializeComponent();
            txtNombres.Text = nombre;
            txtApellidos.Text = apellido;
            txtCedula.Text = cedula;
            txtCelular.Text = celular;
            txtDireccion.Text = direccion;
            txtEmail.Text = correo;

            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtCedula.Enabled = false;

            confir = true;
        }
        private void btnVerClientes_Click(object sender, EventArgs e)
        {
            VerClientes = new fmVerClientes();
            this.Hide();
            VerClientes.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            fmEmpleados Empleado = new fmEmpleados();
            this.Hide();
            Empleado.ShowDialog();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAgregarClientes_Click(object sender, EventArgs e)
        {
            if(Validar() && EsCedulaValida(txtCedula.Text))
            {
                conexion = new CsConexion();
                string ingreso = "Insert into Clientes (cl_nombre, cl_apellido, cl_cedula, cl_celular, cl_email, cl_direccion) values ('" + txtNombres.Text +"' , '" + 
                    txtApellidos.Text + "', '" + txtCedula.Text + "' , '" + txtCelular.Text +"', '" + txtEmail.Text +"' , '" + txtDireccion.Text + "')";

                if (conexion.Ingresar_Modificar(ingreso))
                {
                    MessageBox.Show("El cliente se ingreso correctamente");

                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtCedula.Clear();
                    txtCelular.Clear();
                    txtDireccion.Clear();
                    txtEmail.Clear();
                }

            }
        }

        private void btnModificarClientes_Click(object sender, EventArgs e)
        {
            if(confir)
            {
                if (Validar())
                {
                    conexion = new CsConexion();
                    string orden = "UPDATE Clientes SET cl_celular = '" + txtCelular.Text + "', cl_direccion = '" + txtDireccion.Text + "' , cl_email = '" + txtEmail.Text
                        + "' WHERE cl_cedula = '" + txtCedula.Text + "'";
                    if (conexion.Ingresar_Modificar(orden))
                        MessageBox.Show("Los datos se actualizaron correctamente");
                    confir = false;

                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtCedula.Clear();
                    txtCelular.Clear();
                    txtDireccion.Clear();
                    txtEmail.Clear();

                    txtNombres.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtCedula.Enabled = true;
                }
            }
            else
            {
                fmVerClientes clientes = new fmVerClientes();
                this.Hide();
                clientes.Show();
            }
        }
        bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtCedula.Text)
                || string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese todos los valores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!buscar(txtNombres.Text))
            {
                MessageBox.Show("Ingrese caracteres validos en el campo 'Nombres'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!buscar(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese caracteres validos en el campo 'Apellidos'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EsCorreoValido(txtEmail.Text))
            {
                MessageBox.Show("Correo no valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EsNumeroValido(txtCelular.Text))
            {
                MessageBox.Show("Celular no valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool EsNumeroValido(string texto)
        {
            foreach (char c in texto)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }
        private bool EsCedulaValida(string cedula)
        {
            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                MessageBox.Show("La cédula debe contener 10 dígitos numéricos.");
                return false;
            }

            int[] digitos = cedula.Take(9).Select(c => int.Parse(c.ToString())).ToArray();

            int sumaPares = 0;
            int sumaImpares = 0;

            for (int i = 0; i < digitos.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int resultado = digitos[i] * 2;
                    sumaImpares += resultado > 9 ? resultado - 9 : resultado;
                }
                else
                {
                    sumaPares += digitos[i];
                }
            }

            int sumaTotal = sumaPares + sumaImpares;

            int verificadorCalculado = (sumaTotal % 10 == 0) ? 0 : 10 - (sumaTotal % 10);

            int verificadorCedula = int.Parse(cedula.Substring(9, 1));

            if (verificadorCedula != verificadorCalculado)
            {
                MessageBox.Show("La cédula no es válida, no es una cedula real.");
                return false;
            }

            return true;
        }
        bool buscar(string cad)
        {
            foreach (char c in cad)
            {
                if (!caracteres(c))
                    return false;

            }
            return true;
        }
        bool caracteres(char c)
        {
            if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c == 'ñ') || (c == 'Ñ') || (c == ' '))
            {
                return true;
            }
            return false;
        }
    }
}
