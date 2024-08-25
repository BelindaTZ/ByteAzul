using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BYTEAZUL
{
    public partial class fmEmpleados : Form
    {
        fmVerEmpleados VerEmpleados;
        CsConexion conexion;
        csEmpleados empleados;
        bool borrar = false;
        bool modificar = false;
        public fmEmpleados()
        {
            InitializeComponent();
            dtpFechaIngreso.Enabled = false;
        }
        public fmEmpleados(string nombre, string apellido, string cedula, DateTime fechanacimiento, string genero, string cargo, 
            DateTime fechaingreso, string correo, string direccion, string celular, string estado)
        {
            InitializeComponent();

            txtNombres.Text = nombre;
            txtApellidos.Text = apellido;
            txtCedula.Text = cedula;
            dtpFechadeNacimiento.Value = fechanacimiento;
            dtpFechaIngreso.Value = fechaingreso;
            txtCelular.Text = celular;
            txtCorreo.Text = correo;
            txtDireccion.Text = direccion;

            if(cargo == "Adminhistrador")
                cmbCargo.SelectedIndex = 0;
            else if (cargo == "Gerente")
                cmbCargo.SelectedIndex = 1;
            else if (cargo == "Empleado")
                cmbCargo.SelectedIndex = 2;
            else 
                cmbCargo.SelectedIndex = 3;

            if(genero == "Masculino")
                cmbGenero.SelectedIndex = 0;
            else
                cmbGenero.SelectedIndex = 1;

            if(estado == "Activo")
                cmbEstado.SelectedIndex = 0;
            else
                cmbEstado.SelectedIndex = 1;

            dtpFechaIngreso.Enabled = false;
            txtNombres.Enabled = false;
            txtCedula.Enabled = false;
            txtApellidos.Enabled = false;
            dtpFechadeNacimiento.Enabled = false;
            cmbGenero.Enabled = false;

            borrar = true;
            modificar = true;
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

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            fmVerEmpleados VerEmpleados = new fmVerEmpleados();
            this.Hide();
            VerEmpleados.ShowDialog();
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

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {

            if (Validar() && EsCedulaValida(txtCedula.Text))
            {
                conexion = new CsConexion();
                empleados = new csEmpleados();

                // Verificar si la cédula ya existe
                string cad = "SELECT * FROM Empleados WHERE em_cedula = '" + txtCedula.Text + "'";
                DataSet ds = conexion.Insertinto(cad);

                if (ds.Tables[0].Rows.Count == 0) 
                {
                    empleados.Nombres = txtNombres.Text;
                    empleados.Apellidos = txtApellidos.Text;
                    empleados.Celular = txtCelular.Text;
                    empleados.Cedula = txtCedula.Text;
                    empleados.Estado = cmbEstado.Text;
                    empleados.Cargo = cmbCargo.Text;
                    empleados.Email = txtCorreo.Text;
                    empleados.Direccion = txtDireccion.Text;
                    empleados.FechaDeIngreso = dtpFechaIngreso.Value;
                    empleados.FechaDeNacimiento = dtpFechadeNacimiento.Value;
                    empleados.Genero = cmbGenero.Text;

                    if (empleados.Insertar())
                        MessageBox.Show("El nuevo empleado se ingreso correctamente");

                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtCedula.Clear();
                    dtpFechadeNacimiento.Value = new DateTime(2006, 5, 20);
                    dtpFechaIngreso.Value = dtpFechaIngreso.MaxDate;
                    txtCelular.Clear();
                    txtCorreo.Clear();
                    txtDireccion.Clear();

                    cmbCargo.SelectedIndex = -1;
                    cmbGenero.SelectedIndex = -1;
                    cmbEstado.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Cédula en uso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtCedula.Text)
                || string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text)
                || string.IsNullOrWhiteSpace(cmbGenero.Text) || string.IsNullOrWhiteSpace(cmbCargo.Text) || string.IsNullOrWhiteSpace(cmbEstado.Text))
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
            if (!EsCorreoValido(txtCorreo.Text))
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
            foreach(char c in cad)
            {
                if(!caracteres(c))
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

        private void btnModificarEmpleados_Click(object sender, EventArgs e)
        {
            if(modificar)
            {
                if(Validar())
                {
                    conexion = new CsConexion();
                    string modi = "UPDATE Empleados SET em_direccion = '" + txtDireccion.Text + "', em_cargo = '" + cmbCargo.Text + "' , em_celular = '" + txtCelular.Text + "' , em_email = '" + txtCorreo.Text + "' , em_estado = '" + cmbEstado.Text + "' WHERE em_cedula = '" + txtCedula.Text + "' ";
                    if (conexion.Ingresar_Modificar(modi))
                        MessageBox.Show("Se actualizaron los datos correctamente");
                    modificar = false;

                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtCedula.Clear();
                    dtpFechadeNacimiento.Value = new DateTime(2006, 5, 20); 
                    dtpFechaIngreso.Value = dtpFechaIngreso.MaxDate;
                    txtCelular.Clear();
                    txtCorreo.Clear();
                    txtDireccion.Clear();

                    cmbCargo.SelectedIndex = -1;
                    cmbGenero.SelectedIndex = -1;
                    cmbEstado.SelectedIndex = -1;

                    txtNombres.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtCedula.Enabled = true;
                    txtCorreo.Enabled = true;
                    txtCelular.Enabled = true;
                    cmbCargo.Enabled = true;
                    cmbGenero.Enabled = true;
                    cmbEstado.Enabled = true;
                    dtpFechadeNacimiento.Enabled = true;
                    txtDireccion.Enabled = true;
                }
            }
            else
            {
                fmVerEmpleados empleado = new fmVerEmpleados();
                this.Hide();
                empleado.ShowDialog();
            }
        }
    }
    
}
