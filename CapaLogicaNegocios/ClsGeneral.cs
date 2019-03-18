using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
    public class ClsGeneral
    {

        ClsManejador M = new ClsManejador();
        ClsManejadorSql M_sql = new ClsManejadorSql();

        //metodo para cambiar los datos de conexion
        public bool CambiardatosConexion(string usuario, string password, string bd, string servidor)
        {
           

             if(M.cambiarDatosConexion(usuario, password, bd, servidor))
            {
                ClsManejador._user = usuario;
                ClsManejador._password = password;
                ClsManejador._data_base = bd;
                ClsManejador._server = servidor;
                return true;
            }
            return false;
        }
        //metodo que regresa los datos de conexion
        public string[] verDatosConexion()
        {
            return M.verDatosConexion();
        }

        //metodo para cambiar los datos de conexion
        public bool CambiardatosConexionSql(string usuario, string password, string bd, string servidor)
        {


            if (M_sql.cambiarDatosConexion(usuario, password, bd, servidor))
            {
                ClsManejadorSql._user_sql = usuario;
                ClsManejadorSql._password_sql = password;
                ClsManejadorSql._data_base_sql = bd;
                ClsManejadorSql._server_sql = servidor;
                return true;
            }
            return false;
        }
        //metodo que regresa los datos de conexion
        public string[] verDatosConexionSql()
        {
            return M_sql.verDatosConexion();
        }
    }
}
