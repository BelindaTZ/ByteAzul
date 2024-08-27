﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BYTEAZUL
{
    class CsConexion
    {
        SqlConnection conectar;
        SqlCommand sqlcoman;
        SqlDataAdapter sqladap;
        DataTable sqldatable;
        DataSet datset; 
        string serve, database, usuario, pasword;
        public string Servidor { get { return serve; } set { serve = value; } }
        public string Database { get { return database; } set { database = value; } }
        public string Usuario { get { return usuario; } set { usuario = value; } }
        public string Pasword { get { return pasword; } set { pasword = value; } }
        public CsConexion() 
        {
            serve = @"(localdb)\.";
            database = "ByteAzul";
            usuario = "Byteazul";
            pasword = "12345";
        }
        public bool abrirconexion()
        {
            try
            {
                conectar = new SqlConnection();
                conectar.ConnectionString = "Server= " + Servidor + "; Database= " + Database + "; User id= " + Usuario + "; Password= " + Pasword;
                conectar.Open();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }
        public bool cerrarconexion()
        {
            try
            {
                if (conectar != null && conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }
        public DataSet Insertinto(string cade)
        {
            try
            {
                if (cade.Length > 0)
                {
                    abrirconexion();
                    sqlcoman = new SqlCommand(cade, conectar);
                    sqladap = new SqlDataAdapter(sqlcoman);
                    datset = new DataSet("dsretorna");  
                    sqladap.Fill(datset, "dsretorna");
                    cerrarconexion();
                }
            }
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.Message);
                if (conectar != null && conectar.State == ConnectionState.Open)
                    cerrarconexion();
            }
            return datset;
        }
        public bool Ingresar_Modificar(string consulta)
        {
            try
            {
                if (consulta.Length > 0)
                {
                    abrirconexion();
                    sqlcoman = new SqlCommand(consulta, conectar);
                    int filasAfectadas = sqlcoman.ExecuteNonQuery();
                    cerrarconexion();
                    return filasAfectadas > 0;
                }
                else 
                    return false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                if (conectar != null && conectar.State == ConnectionState.Open)
                    cerrarconexion();
                return false;
            }
        }
    }
}