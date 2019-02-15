using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace CapaAccesoDatos
{
    public class ClsManejador
    {
        static ConexionDB conexionDatos = new ConexionDB();
        public static string _user = conexionDatos.User;
        public static string _password = conexionDatos.Password;
        public static string _data_base = conexionDatos.DataBase;
        public static string _server = conexionDatos.Server;

        MySqlConnection Conexion = new MySqlConnection("Data source = " + _server + "; Initial Catalog = " + _data_base + "; User Id = " + _user + "; password=" + _password);

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
        public void Ejecutar_sp(string NombreSP, List<ClsParametros> lst)
        {
            MySqlCommand cmd;

            try
            {


                abrir_conexion(); // intentamos abrir la conexion
                cmd = new MySqlCommand(NombreSP, Conexion);
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
            MySqlDataAdapter Da;               // tipo de dato de visual studio contenedor de una tabla de SQL
            mysqld
            try
            {
                Da = new MySqlDataAdapter(NombreSP, Conexion);   // este adaptador lo reconoce la libreria de sql como un contenedor de datos
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
