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
    public partial class fmVerProveedores : Form
    {
        public fmVerProveedores()
        {
            InitializeComponent();
        }
        int y;
        string pr_producto, pr_rubro, id_proveedor, pr_descripcion, pr_cantidad, pr_precio_unidad;
        string prv_IdProveedor, prv_nombre, prv_celular, prv_servicios, prv_direccion, prv_email;
        public fmVerProveedores(int z, string pr_produ, string  pr_rub, string id_proveed, string pr_descrip, string pr_canti, string pr_precio)
        {
            InitializeComponent();
            y = z;
            pr_producto = pr_produ;
            pr_rubro = pr_rub;
            id_proveedor = id_proveed;
            pr_descripcion = pr_descrip;
            pr_cantidad = pr_canti;
            pr_precio_unidad = pr_precio;
            btnAgregarProveedor.Enabled = false;
            btnAgregarProveedor.Visible = false;
            btnModificarProveedor.Enabled = false;
            btnModificarProveedor.Visible = false;
            btnCerrarSesion.Enabled = false;
            btnClientes.Enabled = false;
            btnEmpleados.Enabled = false;
            btnMovimientos.Enabled = false;
            btnProductos.Enabled = false;
            btnRegresar.Enabled = false;
            btnSalir.Enabled = false;
            btnVentas.Enabled = false;
            btnCaja.Enabled = false;
        }

        fmProveedores Proveedores;
        fmProductos Productos;
        CsConexion conexion;
        string sentencia;

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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Proveedores = new fmProveedores();
            this.Hide();
            Proveedores.Show();
        }

        private void btnProductos_MouseMove(object sender, MouseEventArgs e)
        {
            lblProductos.Visible= true;
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

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVerProveedores.SelectedRows.Count == 1)
                {
                    int fila = dgvVerProveedores.CurrentCell.RowIndex;
                    prv_IdProveedor = dgvVerProveedores.Rows[fila].Cells[0].Value.ToString();
                    prv_nombre = dgvVerProveedores.Rows[fila].Cells[1].Value.ToString();
                    prv_celular = dgvVerProveedores.Rows[fila].Cells[2].Value.ToString();
                    prv_servicios = dgvVerProveedores.Rows[fila].Cells[3].Value.ToString();
                    prv_direccion = dgvVerProveedores.Rows[fila].Cells[4].Value.ToString();
                    prv_email = dgvVerProveedores.Rows[fila].Cells[5].Value.ToString();
                    Proveedores = new fmProveedores(prv_IdProveedor, prv_nombre, prv_celular, prv_servicios, prv_direccion, prv_email);
                    this.Hide();
                    Proveedores.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrarSesion_MouseLeave(object sender, EventArgs e)
        {
            lblCerrarSesion.Visible = false;
        }

        private void fmVerProveedores_Load(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            sentencia = "Select * from Proveedores";
            DataSet verProveedores = conexion.Insertinto(sentencia);
            dgvVerProveedores.DataSource = verProveedores.Tables[0];
            int x = dgvVerProveedores.Columns.Count;
            for (int i = 0; i < x; i++)
                dgvVerProveedores.Columns[i].Width = dgvVerProveedores.Width / x - 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                conexion = new CsConexion();
                if (txtBuscar.Text == "")
                {
                    sentencia = "Select * from Proveedores";
                    DataSet verProveedoresB = conexion.Insertinto(sentencia);
                    dgvVerProveedores.DataSource = verProveedoresB.Tables[0];
                }
                else
                {
                    sentencia = "Select * from Proveedores where id_proveedor like '%" + txtBuscar.Text + "%'";
                    DataSet verProveedores = conexion.Insertinto(sentencia);
                    if (verProveedores.Tables[0].Rows.Count == 0)
                    {
                        sentencia = "Select * from Proveedores where prv_nombre like '%" + txtBuscar.Text + "%' Or prv_celular like '%" + txtBuscar.Text + "%' Or prv_servicios like '%" + txtBuscar.Text + "%' Or prv_direccion like '%" + txtBuscar.Text + "%' Or prv_email like '%" + txtBuscar.Text + "%'";
                        verProveedores = conexion.Insertinto(sentencia);
                    }

                    dgvVerProveedores.DataSource = verProveedores.Tables[0];

                }
                x = dgvVerProveedores.Columns.Count;
                for (int i = 0; i < x; i++)
                    dgvVerProveedores.Columns[i].Width = dgvVerProveedores.Width / x - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Proveedores = new fmProveedores();
            this.Hide();
            Proveedores.Show();
        }

        private void dgvVerProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(y == 1)
            {
                int fila = dgvVerProveedores.CurrentCell.RowIndex;
                id_proveedor = dgvVerProveedores.Rows[fila].Cells[0].Value.ToString();
                Productos = new fmProductos(pr_producto, pr_rubro, id_proveedor, pr_descripcion, pr_cantidad, pr_precio_unidad);
                this.Hide();
                Productos.ShowDialog();
            }
        }
    }
}
