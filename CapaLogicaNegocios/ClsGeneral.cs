using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
    public class ClsGeneral
    {

        public int m_idcat_web_productos { get; set; }
        public int m_noref { get; set; }
        public string m_descipcion { get; set; }
        public string m_imagen { get; set; }
        public string m_manual { get; set; }
        public int m_gm { get; set; }
        public int m_ww { get; set; }
        public int m_nissan { get; set; }
        public int m_cpt_idlastedit { get; set; }
        public int m_cpt_timestamp { get; set; }
        public int m_status { get; set; }


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

        public DataTable verProductos()
        {
            //List<ClsParametros> lst = new List<ClsParametros>();
            return M.Listado("cat_web_productos_back_select", null);
        }

        public DataTable eliminarProductos()
        {
            //List<ClsParametros> lst = new List<ClsParametros>();
            return M.Listado("cat_web_productos_back_delete", null);
        }

        public string guardarProductos()
        {
            try
            {
                string respuesta="se guardo de forma correcta";
                List<ClsParametrosSql> lst = new List<ClsParametrosSql>();

                //Parametro de entrada
                lst.Add(new ClsParametrosSql("@idcat_web_productos", m_idcat_web_productos));
                lst.Add(new ClsParametrosSql("@noref", m_noref));
                lst.Add(new ClsParametrosSql("@descipcion", m_descipcion));
                lst.Add(new ClsParametrosSql("@imagen", m_imagen));
                lst.Add(new ClsParametrosSql("@manual", m_manual));
                lst.Add(new ClsParametrosSql("@gm", m_gm));
                lst.Add(new ClsParametrosSql("@ww", m_ww));
                lst.Add(new ClsParametrosSql("@nissan", m_nissan));
                lst.Add(new ClsParametrosSql("@cpt_idlastedit", m_cpt_idlastedit));
                lst.Add(new ClsParametrosSql("@cpt_timestamp", m_cpt_timestamp));
                lst.Add(new ClsParametrosSql("@status", m_status));
                M_sql.Ejecutar_sp("guardarProductos", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[2].Valor.ToString();/////.valor 
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
