using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ClsParametrosSql
    {
        // declaramos parametros
        public String Nombre { get; set; }
        public Object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamano { get; set; }
        public ParameterDirection Direccion { get; set; }


        // Estos son los constructores
        // C. Entrada de datos
        public ClsParametrosSql(string objNombre, object objValor)
        {
            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        }

        // C. Salida de datos
        public ClsParametrosSql(String objNombre, SqlDbType objTipoDato, Int32 objTamano)
        {
            Nombre = objNombre;
            TipoDato = objTipoDato;
            Tamano = objTamano;
            Direccion = ParameterDirection.Output;

        }
    }
}
