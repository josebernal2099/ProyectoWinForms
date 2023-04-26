using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGeneral.Scripts
{
    class ScriptConsultas
    {
        public static ProcedimientoAlmacenado ObtenerTiendas()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado();
            sp.Nombre = "spCnObtenerTiendas";            
            return sp;

        }
        public static ProcedimientoAlmacenado ObtenerArticulos()
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado();
            sp.Nombre = "spCnObtenerArticulos";
            return sp;

        }
        public static ProcedimientoAlmacenado ObtenerArticulosPorTienda(int IdStore)
        {
            ProcedimientoAlmacenado sp = new ProcedimientoAlmacenado();
            sp.Nombre = "spCnObtenerArticulosPorTienda";
            sp.NuevoParametro("pIdStore", SqlDbType.Int, IdStore);
            return sp;

        }
    }
}
