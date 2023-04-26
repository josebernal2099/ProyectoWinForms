using System;
using System.ComponentModel;
using System.Data;

namespace DALGeneral
{
    [Serializable]
    public abstract class ObjetoBase : Object, IDisposable
    {
        private bool disposed = false;

        #region Propiedades para uso de transacciones con base de datos

        /// <summary>
        /// Obtiene o establece la transacción
        /// </summary>
        [Category("NoBusqueda")]
        public IDbTransaction Transaction { get; set; }
        /// <summary>
        /// Indica si el objeto está dentro de una transacción
        /// </summary>
        [Category("NoBusqueda")]
        public bool IsTransaction { get; set; }

        #endregion
                  
        #region Metodos base de IDisponsable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion          
    }
}
