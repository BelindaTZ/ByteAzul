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
    public partial class fmProductos : Form
    {
        fmVerProductos VerProductos;
        fmVerProveedores VerProveedores;
        string sentencia;
        CsConexion conexion;
        static Random rnd = new Random(DateTime.Now.Millisecond);
        public fmProductos()
        {
            InitializeComponent();
        }
        public fmProductos(string id_producto, string pr_producto, string pr_rubro, string id_proveedor, string pr_descripcion, string pr_cantidad, string pr_precio_unidad)
        {
            InitializeComponent();
            btnAgregarProducto.Enabled = false;
            btnModificarProducto.Enabled = true;
            txtProductos.Text = pr_producto;
            txtProductos.Enabled = false;
            txtDescripcion.Text = pr_descripcion;
            txt_Idproducto.Text = id_producto;
            txtRubros.Text = pr_rubro;
            txtCantidad.Text = pr_cantidad;
            txtIdProveedor.Text = id_proveedor;
            btnBuscar.Enabled = false;
            txtPrecios.Text = pr_precio_unidad;
        }
        public fmProductos(string pr_producto, string pr_rubro, string id_proveedor, string pr_descripcion, string pr_cantidad, string pr_precio_unidad)
        {
            InitializeComponent();
            txtProductos.Text = pr_producto;
            txtDescripcion.Text = pr_descripcion;
            txtRubros.Text = pr_rubro;
            txtCantidad.Text = pr_cantidad;
            txtIdProveedor.Text = id_proveedor;
            txtPrecios.Text = pr_precio_unidad;
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

        private void btnCerrarSesion_MouseLeave(object sender, EventArgs e){lblCerrarSesion.Visible = false;}

        private void btnCerrarSesion_MouseMove(object sender, MouseEventArgs e){lblCerrarSesion.Visible = true;}

        private void btnProveedores_MouseMove(object sender, MouseEventArgs e) { lblProveedores.Visible = true; }

        private void btnProveedores_MouseLeave(object sender, EventArgs e) { lblProveedores.Visible = false; }

        private void btnMovimientos_MouseLeave(object sender, EventArgs e){lblMovimientos.Visible = false;}

        private void btnMovimientos_MouseMove(object sender, MouseEventArgs e){lblMovimientos.Visible = true;}

        private void btnVentas_MouseMove(object sender, MouseEventArgs e){lblVentas.Visible = true;}

        private void btnVentas_MouseLeave(object sender, EventArgs e){lblVentas.Visible = false;}

        private void btnCaja_MouseLeave(object sender, EventArgs e){lblCaja.Visible = false;}

        private void btnCaja_MouseMove(object sender, MouseEventArgs e){ lblCaja.Visible = true;}

        private void btnEmpleados_MouseMove(object sender, MouseEventArgs e){lblEmpleados.Visible = true;}

        private void btnEmpleados_MouseLeave(object sender, EventArgs e){lblEmpleados.Visible = false;}

        private void btnClientes_MouseMove(object sender, MouseEventArgs e){lblClientes.Visible = true;}

        private void btnClientes_MouseLeave(object sender, EventArgs e){lblClientes.Visible = false;}

        private void btnMimizar_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void btnSalir_Click(object sender, EventArgs e){Application.Exit();}

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "" || txtRubros.Text == "" || txtCantidad.Text == "" || txtPrecios.Text == "")
                MessageBox.Show("Algunos campos están vacíos");
            else if (double.Parse(txtPrecios.Text) <= 0 || int.Parse(txtCantidad.Text) <= 0)
                MessageBox.Show("Los valores deben ser mayor 0");
            else
            {
                sentencia = "Update Productos set pr_rubro = '" + txtRubros.Text + "', pr_descripcion = '" + txtDescripcion.Text + "', pr_cantidad = '" + txtCantidad.Text + "', pr_precio_unidad = '" + txtPrecios.Text + "' where id_producto = '" + txt_Idproducto.Text + "'";
                conexion = new CsConexion();
                conexion.Ingresar_Modificar(sentencia);
                MessageBox.Show("Producto Modificado Exitosamente :D");
                this.Hide();
                VerProductos = new fmVerProductos();
                VerProductos.ShowDialog();
            }
        }

        private void btnVerProductos_Click(object sender, EventArgs e)
        {
           VerProductos = new fmVerProductos();
           this.Hide();
           VerProductos.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            fmMenu Menu = new fmMenu();
            this.Hide();
            Menu.ShowDialog();
        }

        private void fmProductos_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (txtProductos.Text == "" || txtIdProveedor.Text == "" || txtDescripcion.Text == "" || txtRubros.Text == "" || txtCantidad.Text == "" || txtPrecios.Text == "")
                MessageBox.Show("Algunos campos están vacíos");
            else if (double.Parse(txtPrecios.Text) <= 0 || int.Parse(txtCantidad.Text) <= 0)
                MessageBox.Show("Los valores deben ser mayor 0");
            else
            {
                string idProdu = (txtProductos.Text.Substring(0, 3) + rnd.Next(100, 1000)).ToUpper();
                txt_Idproducto.Text = idProdu;
                sentencia = "Insert into Productos (id_producto, pr_producto, pr_rubro, id_proveedor, pr_descripcion, pr_cantidad, pr_precio_unidad)" +
                    " Values ('" + idProdu + "', '" + txtProductos.Text + "', '" + txtRubros.Text + "', '" + txtIdProveedor.Text + "', '" + txtDescripcion.Text + "', '" + txtCantidad.Text + "', '" + txtPrecios.Text + "')";
                conexion = new CsConexion();
                conexion.Ingresar_Modificar(sentencia);
                MessageBox.Show("Producto Ingresado Exitosamente :D");
                this.Hide();
                VerProductos = new fmVerProductos();
                VerProductos.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            VerProveedores = new fmVerProveedores(1, txtProductos.Text, txtRubros.Text, txtIdProveedor.Text, txtDescripcion.Text, txtCantidad.Text, txtPrecios.Text);
            this.Hide();
            VerProveedores.ShowDialog();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPrecios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
