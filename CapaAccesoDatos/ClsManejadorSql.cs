using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ClsManejadorSql
    {
        static ConexionDBSql conexionDatos = new ConexionDBSql();
        public static string _user_sql = conexionDatos.User;
        public static string _password_sql = conexionDatos.Password;
        public static string _data_base_sql = conexionDatos.DataBase;
        public static string _server_sql = conexionDatos.Server;

        SqlConnection Conexion = new SqlConnection("Data source = " + _server_sql + "; Initial Catalog = " + _data_base_sql + "; User Id = " + _user_sql + "; password=" + _password_sql);

        public bool cambiarDatosConexion(string usuario, string password, string bd, string servidor)
        {
            try
            {
                conexionDatos.User = usuario;
                conexionDatos.Password = password;
                conexionDatos.DataBase = bd;
                conexionDatos.Server = servidor;
                conexionDatos.Save();
                return validateConnection();
            }
            catch
            {
                return false;
            }

        }

        public bool validateConnection()
        {
            try
            {
                Conexion.Open();
                Conexion.Close();
                return true;
            }
            catch
            {
                Conexion.Close();
                return false;
            }
        }

        public string[] verDatosConexion()
        {
            string usuario = conexionDatos.User;
            string password = conexionDatos.Password;
            string baseDeDatos = conexionDatos.DataBase;
            string servidor = conexionDatos.Server;
            string[] datos = new string[4] { usuario, password, baseDeDatos, servidor };
            return datos;
        }

        // metodo para abrir coneccion
        void abrir_conexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();

        }

        void cerrar_conexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
        }

        // metodo para ejecutar el SP  Insert, update, delete 
        public void Ejecutar_sp(string NombreSP, List<ClsParametrosSql> lst)
        {
            SqlCommand cmd;

            try
            {


                abrir_conexion(); // intentamos abrir la conexion
                cmd = new SqlCommand(NombreSP, Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)   //recorremos la lista de parametros del SP en tratamiento
                    {
                        if (lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);

                        }
                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamano).Direction = ParameterDirection.Output;
                        }

                    }
                }
                cmd.ExecuteNonQuery();
                for (int ii = 0; ii < lst.Count; ii++)
                {
                    if (cmd.Parameters[ii].Direction == ParameterDirection.Output)
                        lst[ii].Valor = cmd.Parameters[ii].Value.ToString();  // else mensaje de salida del SP siempre va a ser cadena, mensaje de error
                }



            }
            catch (Exception ex)
            {
                throw ex;   // si hay error cachamos el error

            }
            cerrar_conexion();  // si no hay error cerramos la conexion
        }


        // Metodo para listado o consultas  select
        public DataTable Listado(string NombreSP, List<ClsParametros> lst)
        {
            DataTable dt = new DataTable();  // tipo de dato de visual studio contenedor de una tabla
            SqlDataAdapter Da;               // tipo de dato de visual studio contenedor de una tabla de SQL
            //mysqld
            try
            {
                Da = new SqlDataAdapter(NombreSP, Conexion);   // este adaptador lo reconoce la libreria de sql como un contenedor de datos
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;  // le decimos al adaptador que es un tipo SP
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        //agregamos los parametros del SP al SQLAdapter para ser ejecutado por fill
                        Da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                Da.Fill(dt);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            return dt;
        }
    }
}
