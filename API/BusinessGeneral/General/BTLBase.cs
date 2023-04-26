using DALGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessGeneral.General
{
    public class BTLBase : DAOBase
    {
        public void IniciarTransaccion()
        {
            _contextoTransaccional = GenerarContextoTransaccional();
        }

        public void ConfirmarTransaccion()
        {
            CommitTransaction();
        }

        public void DeshacerTransaccion()
        {
            RollBackTransaction();
        }
    }
}
