using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALGeneral
{
    public class SQLBulkCopy
    {
        private static string _CadenaDeConexion;
        private static bool _ErrorEnBulkCopy;
        private static string _DescripcionDeErrorBulkCopy;

        /// <summary>   
        /// Obtiene o establece la descripcion del error producido en el proceso de Bulkcopy
        /// </summary>
        public static string DescripcionDeErrorBulkCopy
        {
            get { return SQLBulkCopy._DescripcionDeErrorBulkCopy; }
            set { SQLBulkCopy._DescripcionDeErrorBulkCopy = value; }
        }

        /// <summary>
        /// Obtiene o establece si ocurrio un error en el proceso de Bulkcopy
        /// </summary>
        public static bool ErrorEnBulkCopy
        {
            get { return SQLBulkCopy._ErrorEnBulkCopy; }
            set { SQLBulkCopy._ErrorEnBulkCopy = value; }
        }

        /// <summary>
        /// Obtiene o establece la cadena de conexión para poder realizar la conexión con SQL
        /// </summary>
        public static string CadenaDeConexion
        {
            get { return AdoHelper.ConnectionString; }
        }


        private static List<SqlBulkCopyColumnMapping> ColumnasMapeadas(DataTable omContenedor)
        {
            List<SqlBulkCopyColumnMapping> Respuesta = new List<SqlBulkCopyColumnMapping>();
            foreach (DataColumn omColumna in omContenedor.Columns)
            {
                SqlBulkCopyColumnMapping oMapeo = new SqlBulkCopyColumnMapping(omColumna.ColumnName, omColumna.ColumnName);
                Respuesta.Add(oMapeo);
            }
            return Respuesta;
        }

        public static void BulkCopyMasivo(string smNombreDeTablaDeBaseDeDatos, DataTable omDtContenedorDeInformacion)
        {
            SqlConnection oCn = SQLBulkCopy.TraerConexion();
            SqlBulkCopy omBk = null;

            try
            {
                oCn.Open();
                omBk = new SqlBulkCopy(AdoHelper.ConnectionString);
                omBk.DestinationTableName = smNombreDeTablaDeBaseDeDatos;
                omBk.WriteToServer(omDtContenedorDeInformacion);
                omBk.Close();
                oCn.Close();
                oCn.Dispose();
                _ErrorEnBulkCopy = false;
            }
            catch (Exception Error)
            {
                omBk.Close();
                oCn.Close();
                oCn.Dispose();
                _ErrorEnBulkCopy = true;
                _DescripcionDeErrorBulkCopy = Error.Message;
            }
        }

        /// <summary>
        /// Inicia la Inserción masiva de datos contenidos en un contenedor DataTable, el cual
        /// debe contener la estructura de la tabla física de la base de datos en SQL
        /// </summary>
        /// <param name="smNombreDeTablaDeBaseDeDatos">Nombre de la Tabla talcual está en la base de datos SQL</param>
        /// <param name="omDtContenedorDeInformacion">Contenedor de datos con estructura de la tabla física en SQL
        /// cuidando el Nombre de la columna de la tabla fisica Vs Nombre de la columna en el contenedor
        /// ya que ambos deben ser iguales, 
        /// cuidando el orden en el que se encuentran las columnas en la tabla Vs Contenedor</param>
        /// <param name="descripcionDeColumnaLlaveParaMensaje">Nombre de la columna que está como llave Primaria
        /// en la tabla fisica</param>
        public static void BulkCopy(string smNombreDeTablaDeBaseDeDatos, DataTable omDtContenedorDeInformacion, string descripcionDeColumnaLlaveParaMensaje)
        {
            SqlConnection oCn = SQLBulkCopy.TraerConexion();
            SqlBulkCopy omBk = null;

            try
            {
                oCn.Open();
                omBk = new SqlBulkCopy(oCn.ConnectionString);
                omBk.DestinationTableName = smNombreDeTablaDeBaseDeDatos;
                omBk.WriteToServer(omDtContenedorDeInformacion);
                omBk.Close();
                oCn.Close();
                oCn.Dispose();
                _ErrorEnBulkCopy = false;
            }
            catch (Exception Error)
            {
                omBk.Close();
                oCn.Close();
                oCn.Dispose();
                _ErrorEnBulkCopy = true;
                if (Error.Message.ToUpper().Contains("PRIMARY KEY"))
                    _DescripcionDeErrorBulkCopy = string.Format("De la carga realizada por lo menos un(a) {0} ya existe en la base de datos \r VERIFICAR {1}", descripcionDeColumnaLlaveParaMensaje, descripcionDeColumnaLlaveParaMensaje.ToUpper());
                else
                    _DescripcionDeErrorBulkCopy = Error.Message;
            }
        }

        /// <summary>
        /// Obtiene la conexión de la base de datos
        /// </summary>
        /// <returns></returns>
        public static SqlConnection TraerConexion()
        {
            SQLBulkCopy._CadenaDeConexion = AdoHelper.ConnectionString;
            SqlConnection conn = new SqlConnection(SQLBulkCopy._CadenaDeConexion);
            return conn;
        }
    }
}
