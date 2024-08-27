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
    public partial class fmVerProductos : Form
    {
        fmProductos Productos;
        CsConexion conexion;
        string sentencia;
        string id_producto, pr_producto, pr_rubro, id_proveedor, pr_descripcion, pr_cantidad, pr_precio_unidad;
        public fmVerProductos()
        {
            InitializeComponent();     
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            fmAcceso Login = new fmAcceso();
            this.Hide();
            Login.ShowDialog();
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
            fmEmpleados Empleado = new fmEmpleados();
            this.Hide();
            Empleado.ShowDialog();
        }

        private void btnMimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            fmClientes Clientes = new fmClientes();
            this.Hide();
            Clientes.ShowDialog();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Productos = new fmProductos();
            this.Hide();
            Productos.ShowDialog();
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

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Productos = new fmProductos();
            this.Hide();
            Productos.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                conexion = new CsConexion();
                if (txtBuscar.Text == "")
                {
                    sentencia = "Select * from Productos";
                    DataSet verProductosB = conexion.Insertinto(sentencia);
                    dgvVerProductos.DataSource = verProductosB.Tables[0];
                }
                else
                {
                    sentencia = "Select * from Productos where id_proveedor like '%" + txtBuscar.Text + "%' Or pr_cantidad like '%" + txtBuscar.Text + "%'";
                    DataSet verProductos = conexion.Insertinto(sentencia);
                    if (verProductos.Tables[0].Rows.Count == 0)
                    {
                        sentencia = "Select * from Productos where id_producto like '%" + txtBuscar.Text + "%' Or pr_producto like '%" + txtBuscar.Text + "%' Or pr_rubro like '%" + txtBuscar.Text + "%' Or pr_descripcion  like '%" + txtBuscar.Text + "%'";
                        verProductos = conexion.Insertinto(sentencia);
                        if (verProductos.Tables[0].Rows.Count == 0)
                        {
                            string busca = txtBuscar.Text;
                            if (busca.Contains(','))
                                busca = busca.Replace(',', '.');
                            sentencia = "Select * from Productos where pr_precio_unidad like '%" + busca + "%'";
                            verProductos = conexion.Insertinto(sentencia);
                        }
                    }
                    dgvVerProductos.DataSource = verProductos.Tables[0];
                }
                x = dgvVerProductos.Columns.Count;
                for (int i = 0; i < x; i++)
                    dgvVerProductos.Columns[i].Width = dgvVerProductos.Width / x - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fmVerProductos_Load(object sender, EventArgs e)
        {
            conexion = new CsConexion();
            DataSet verProducts = conexion.Insertinto("Select * from Productos");
            dgvVerProductos.DataSource = verProducts.Tables[0];
            int x = dgvVerProductos.ColumnCount;
            for (int i = 0; i < x; i++)
                dgvVerProductos.Columns[i].Width = dgvVerProductos.Width / x - 1;
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVerProductos.SelectedRows.Count == 1)
                {
                    int fila = dgvVerProductos.CurrentCell.RowIndex;
                    id_producto = dgvVerProductos.Rows[fila].Cells[0].Value.ToString();
                    pr_producto = dgvVerProductos.Rows[fila].Cells[1].Value.ToString();
                    pr_rubro = dgvVerProductos.Rows[fila].Cells[2].Value.ToString();
                    id_proveedor = dgvVerProductos.Rows[fila].Cells[3].Value.ToString();
                    pr_descripcion = dgvVerProductos.Rows[fila].Cells[4].Value.ToString();
                    pr_cantidad = dgvVerProductos.Rows[fila].Cells[5].Value.ToString();
                    pr_precio_unidad = dgvVerProductos.Rows[fila].Cells[6].Value.ToString();
                    fmProductos modifiproducts = new fmProductos(id_producto, pr_producto, pr_rubro, id_proveedor, pr_descripcion, pr_cantidad, pr_precio_unidad);
                    this.Hide();
                    modifiproducts.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
