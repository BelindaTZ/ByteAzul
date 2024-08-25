using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZUL
{
    internal class csEmpleados
    {

        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Genero { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; }

        CsConexion conexion;

        public csEmpleados()
        {
            conexion = new CsConexion();
        }

        public bool Insertar()
        {
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = "Server= " + conexion.Servidor + "; Database= " + conexion.Database + "; User id= " + conexion.Usuario + "; Password= " + conexion.Pasword;
            conectar.Open();
            try
            {
                string comando = "INSERT INTO Empleados (em_nombres, em_apellidos, em_cedula, em_fecha_de_nacimiento, em_genero, em_cargo, em_fecha_de_ingreso, em_email, " +
                                 "em_direccion, em_celular, em_estado) VALUES (@Nombres, @Apellidos, @Cedula, @FechaNacimiento, @Genero, @Cargo, @FechaIngreso, @Email, " +
                                 "@Direccion, @Celular, @Estado)";

                using (SqlCommand insert = new SqlCommand(comando, conectar))
                {
                    insert.Parameters.AddWithValue("@Nombres", Nombres);
                    insert.Parameters.AddWithValue("@Apellidos", Apellidos);
                    insert.Parameters.AddWithValue("@Cedula", Cedula);
                    insert.Parameters.AddWithValue("@FechaNacimiento", FechaDeNacimiento);
                    insert.Parameters.AddWithValue("@Genero", Genero);
                    insert.Parameters.AddWithValue("@Cargo", Cargo);
                    insert.Parameters.AddWithValue("@FechaIngreso", FechaDeIngreso);
                    insert.Parameters.AddWithValue("@Email", Email);
                    insert.Parameters.AddWithValue("@Direccion", Direccion);
                    insert.Parameters.AddWithValue("@Celular", Celular);
                    insert.Parameters.AddWithValue("@Estado", Estado);

                    int filasAfectadas = insert.ExecuteNonQuery();
                    return filasAfectadas > 0; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (conectar != null && conectar.State == ConnectionState.Open)
                    conectar.Close();
                return false;
            }
        }
    
    }
}
