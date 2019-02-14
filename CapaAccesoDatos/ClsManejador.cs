using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ClsManejador
    {
        static ConexionDB conexionDatos = new ConexionDB();
        static string _user = conexionDatos.User;
        static string _password = conexionDatos.Password;
        static string _data_base = conexionDatos.DataBase;
        static string _server = conexionDatos.Server;

        SqlConnection Conexion = new SqlConnection("Data source = " + servidor + "; Initial Catalog = " + baseDeDatos + "; User Id = " + usuario + "; password=" + password);

        public bool cambiarDatosConexion(string usuario, string password, string bd, string servidor)
        {
            try
            {
                conexionDatos.User = usuario;
                conexionDatos.Password = password;
                conexionDatos.DataBase = bd;
                conexionDatos.Server = servidor;
                conexionDatos.Save();
                return validarConexion();
            }
            catch
            {
                return false;
            }

        }
    }
}
