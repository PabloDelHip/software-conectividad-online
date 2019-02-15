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
    }
}
