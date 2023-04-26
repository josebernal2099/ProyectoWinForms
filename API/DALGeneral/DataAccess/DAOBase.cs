using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALGeneral
{
    [Serializable]
    public class DAOBase : ObjetoBase
    {
        /// <summary>
        /// Obtiene o establece si existe erorr en la ejecución
        /// </summary>
        /// 
        public bool Error { get; set; }
        /// <summary>
        /// Obtiene o establece el detalle del error ocurrido
        /// </summary>
        public string DetalleDeError { get; set; }

        /// <summary>
        /// Inicializa los datos del error como si no existiera error
        /// </summary>
        public void InicializaError()
        {
            this.Error = false;
            this.DetalleDeError = string.Empty;
            this.Resultado = new Resultado();
        }

        /// <summary>
        /// Obtiene o establece los resultados de la ejecucion del Query
        /// </summary>
        public Resultado Resultado { get; set; }

        #region Para uso de transacciones

        /// <summary>
        /// Miembro protegido para la cadena de conexión hacia la base de datos
        /// </summary>
        protected string _cadenaConexion = string.Empty;

        /// <summary>
        /// Miembro protegido para el manejo de la conexión a la base de datos
        /// </summary>
        protected AdoHelper _asistenteSql = null;

        /// <summary>
        /// Miembro protegido para el manejo de la conexión a la base de datos
        /// </summary>
        protected IDbConnection _conexion = null;

        /// <summary>
        /// Miembro protegido para el contexto transaccional.
        /// </summary>
        protected IDbTransaction _contextoTransaccional = null;

        /// <summary>
        /// Entidad de información del boleto
        /// </summary>
        public IDbTransaction ContextoTransaccional
        {
            get { return _contextoTransaccional; }
            set { _contextoTransaccional = value; }
        }

        /// <summary>
        /// Método que genera el contexto transaccional
        /// </summary>
        /// <returns>Devuelve el contexto donde se generará la transaccion</returns>
        protected virtual IDbTransaction GenerarContextoTransaccional()
        {
            if (this._contextoTransaccional == null)
            {
                this._asistenteSql = AdoHelper.CreateHelper();
                this._cadenaConexion = AdoHelper.ConnectionString;
                this._conexion = null;
                this._conexion = this._asistenteSql.GetConnection(this._cadenaConexion);
                this._conexion.Open();
                return this._conexion.BeginTransaction(IsolationLevel.RepeatableRead);
            }
            else
                return this._contextoTransaccional;
        }
        protected virtual void CommitTransaction()
        {
            if (this._contextoTransaccional != null)
            {
                this._contextoTransaccional.Commit();
                if (this._conexion != null)
                    this._conexion.Dispose();
                if (this._conexion != null)
                    this._conexion.Close();
            }
        }
        protected virtual void RollBackTransaction()
        {
            if (this._contextoTransaccional != null)
            {
                this._contextoTransaccional.Rollback();
                if (this._conexion != null)
                    this._conexion.Close();
                if (this._conexion != null)
                    this._conexion.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Obtiene la lista de parametros que se encuentran en el sqlcomman
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>        
        public System.Data.SqlClient.SqlParameter[] obtenerParametosDeSqlCommand(System.Data.SqlClient.SqlCommand cmd)
        {
            List<System.Data.SqlClient.SqlParameter> respuesta = new List<SqlParameter>();
            {
                foreach (System.Data.SqlClient.SqlParameter parametro in cmd.Parameters)
                {
                    System.Data.SqlClient.SqlParameter nuevoParametro = new SqlParameter();
                    nuevoParametro.ParameterName = parametro.ParameterName;
                    nuevoParametro.Size = parametro.Size;
                    nuevoParametro.SqlDbType = parametro.SqlDbType;
                    nuevoParametro.DbType = parametro.DbType;
                    nuevoParametro.Direction = parametro.Direction;
                    nuevoParametro.SqlValue = parametro.SqlValue;
                    nuevoParametro.Value = parametro.Value;
                    respuesta.Add(parametro);
                }
            }
            return respuesta.ToArray();
        }
    }
}
