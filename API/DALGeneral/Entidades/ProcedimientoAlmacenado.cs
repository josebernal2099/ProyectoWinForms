using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DALGeneral
{
    public class ProcedimientoAlmacenado
    {
        private List<SqlParameter> parametros;
        public ProcedimientoAlmacenado()
        {
            this.parametros = new List<SqlParameter>();
            this.Nombre = string.Empty;
        }
        public ProcedimientoAlmacenado(string nombreDeProcedimiento)
        {
            this.parametros = new List<SqlParameter>();
            this.Nombre = nombreDeProcedimiento;
        }

        /// <summary>
        /// Obtiene o establece el nombre del procedimiento almacenado que se va a ejecutar
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Obtiene la lista de los parametros que recibe el procedimiento almacenado
        /// </summary>
        public List<SqlParameter> Parametros
        {
            get { return parametros; }
        }
        /// <summary>
        /// Obtiene la lista de los parametros del procedimiento almacenado como arreglo, si no existen datos
        /// regresa nulo
        /// </summary>
        public SqlParameter[] ParametrosEnArreglo
        {
            get { return this.parametros.Count > 0 ? this.parametros.ToArray() : null; }
        }

        /// <summary>
        /// Obtiene la sentencia SQL que se va a ejecutar o fue ejecutada, Ejemplo: si el spPrueba @parametro1 = 1,@parametro2 = 'Dato',@parametro3 = '01/01/1900'
        /// segun sea la cantidad de parametros que tenga el Procedimiento almacenado
        /// </summary>
        /// <returns></returns>
        public string SentenciaSQL
        {
            get
            {
                StringBuilder sbCadena = new StringBuilder();
                string respuesta = string.Empty;
                if (!string.IsNullOrEmpty(this.Nombre))
                {
                    sbCadena.AppendFormat("{0} ", this.Nombre);
                    foreach (SqlParameter parametro in parametros)
                    {
                        sbCadena.AppendFormat("{0},", this.getParametroParaSp(parametro));
                    }

                    if (parametros.Count > 0)
                    {
                        respuesta = sbCadena.ToString().Substring(0, sbCadena.ToString().Length - 1);
                    }
                    else
                        respuesta = sbCadena.ToString();
                }
                return respuesta;
            }
        }

        public void NuevoParametro(string nombreDeParametro, SqlDbType tipoDeDato, object valor)
        {
            if (string.IsNullOrEmpty(nombreDeParametro.Trim()))
            {
                throw new Exception("Se requiere del nombre del nuevo parametro para el procedimiento amlacenado");
            }

            if (valor == null)
                this.parametros.Add(getNuevoParametro(nombreDeParametro, tipoDeDato, null, true));
            else
                this.parametros.Add(getNuevoParametro(nombreDeParametro, tipoDeDato, valor));
        }
        public void NuevoParametro(string nombreDeParametro, string nombreTipoDeDato, object valor)
        {
            if (string.IsNullOrEmpty(nombreDeParametro.Trim()))
            {
                throw new Exception("Se requiere del nombre del nuevo parametro para el procedimiento amlacenado");
            }

            if (string.IsNullOrEmpty(nombreTipoDeDato.Trim()))
            {
                throw new Exception("Se requiere del nombre de tipo de datos que fue declarado en SQL");
            }

            if (valor == null)
            {
                throw new Exception("La estructura de datos no puede ser nulo, se require del dato");
            }

            this.parametros.Add(getNuevoParametroTipoTabla(nombreDeParametro, nombreTipoDeDato, valor));
        }


        #region Propiedades Publicas y estaticas

        /// <summary>
        /// Genera y obtine una parametro
        /// </summary>
        /// <param name="nombreDeParametro">Nombre que tendra el parametro, sin la @</param>
        /// <param name="tipoDeDato">tipo de dato que almacena</param>
        /// <param name="valor">Valor que se asigna</param>
        /// <returns></returns>
        public static SqlParameter getNuevoParametro(string nombreDeParametro, SqlDbType tipoDeDato, object valor)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = string.Format("@{0}", nombreDeParametro);
            param.SqlDbType = tipoDeDato;
            param.Value = valor;

            return param;
        }
        /// <summary>
        /// Genera y obtine una parametro
        /// </summary>
        /// <param name="nombreDeParametro">Nombre que tendra el parametro, sin la @</param>
        /// <param name="tipoDeDato">tipo de dato que almacena</param>
        /// <param name="valor">Valor que se asigna</param>
        /// <param name="permiteValorNulo">Indica si el campo permite valores Nulos</param>
        /// <returns></returns>
        public static SqlParameter getNuevoParametro(string nombreDeParametro, SqlDbType tipoDeDato, object valor, bool permiteValorNulo)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = string.Format("@{0}", nombreDeParametro);
            param.SqlDbType = tipoDeDato;
            param.IsNullable = permiteValorNulo;
            switch (tipoDeDato)
            {
                case SqlDbType.Bit:
                    break;
                case SqlDbType.Decimal:
                case SqlDbType.Float:
                case SqlDbType.BigInt:
                case SqlDbType.Money:
                case SqlDbType.Real:
                case SqlDbType.SmallInt:
                case SqlDbType.SmallMoney:
                case SqlDbType.TinyInt:
                case SqlDbType.Variant:
                case SqlDbType.Int:
                    param.Value = permiteValorNulo ? null : valor;
                    break;
                case SqlDbType.NChar:
                case SqlDbType.Char:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.UniqueIdentifier:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                case SqlDbType.Udt:
                case SqlDbType.VarBinary:
                case SqlDbType.Image:
                case SqlDbType.Binary:
                    param.Value = permiteValorNulo ? null : valor;
                    break;
                case SqlDbType.SmallDateTime:
                case SqlDbType.Timestamp:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                case SqlDbType.DateTime:
                    param.Value = valor;
                    break;

                case SqlDbType.Structured:
                    param.Value = permiteValorNulo ? null : valor;
                    break;
                default:
                    param.Value = permiteValorNulo ? null : valor;
                    break;
            }
            return param;
        }
        /// <summary>
        /// Genera y obtine una parametro especificamente de estructura de tabla
        /// </summary>
        /// <param name="nombreDeParametro">Nombre que tendra el parametro, si la @</param>
        /// <param name="nombreTipoDeDato">Nombre del tipo de dato creado en la base de datos, esto implica el esquema
        /// alque pertense  seguido del nombre del tipo Ejemplos dbo.NombbreDeTipo o miEsquema.NombbreDeTipo</param>
        /// <param name="valor">Datos que se van a asignar al parametro</param>
        /// <returns></returns>
        public static SqlParameter getNuevoParametroTipoTabla(string nombreDeParametro, string nombreTipoDeDato, object valor)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = string.Format("@{0}", nombreDeParametro);
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = nombreTipoDeDato;
            param.Value = valor;
            return param;
        }


        #endregion

        /// <summary>
        /// Obtiene la cadena del procedimiento almacenado que se ejecuta, con los datos que se envian para ejecucion
        /// </summary>
        /// <param name="Sqlparametro"></param>
        /// <returns></returns>
        private string getParametroParaSp(SqlParameter Sqlparametro)
        {
            StringBuilder respuesta = new StringBuilder();
            if (Sqlparametro.SqlDbType != null)
            {
                switch (Sqlparametro.SqlDbType)
                {
                    case SqlDbType.Bit:
                        if (Sqlparametro.Value != null)
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, (bool)Sqlparametro.Value ? 1 : 0);
                        else
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, "NULL");
                        break;
                    case SqlDbType.Decimal:
                    case SqlDbType.Float:
                    case SqlDbType.BigInt:
                    case SqlDbType.Money:
                    case SqlDbType.Real:
                    case SqlDbType.SmallInt:
                    case SqlDbType.SmallMoney:
                    case SqlDbType.TinyInt:
                    case SqlDbType.Variant:
                    case SqlDbType.Int:
                        if (Sqlparametro.Value != null)
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, Sqlparametro.Value);
                        else
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, "NULL");
                        break;
                    case SqlDbType.NChar:
                    case SqlDbType.Char:
                    case SqlDbType.NText:
                    case SqlDbType.NVarChar:
                    case SqlDbType.UniqueIdentifier:
                    case SqlDbType.Text:
                    case SqlDbType.VarChar:
                    case SqlDbType.Xml:
                    case SqlDbType.Udt:
                    case SqlDbType.VarBinary:
                    case SqlDbType.Image:
                    case SqlDbType.Binary:
                        if (Sqlparametro.Value != null)
                            respuesta.AppendFormat("{0}='{1}'", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                        else
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, "NULL");
                        break;
                    case SqlDbType.SmallDateTime:
                    case SqlDbType.Timestamp:
                    case SqlDbType.Date:
                    case SqlDbType.Time:
                    case SqlDbType.DateTime2:
                    case SqlDbType.DateTimeOffset:
                    case SqlDbType.DateTime:
                        if (Sqlparametro.Value != null)
                            respuesta.AppendFormat("{0}='{1}'", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                        else
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, "NULL");
                        break;

                    case SqlDbType.Structured:
                        if (Sqlparametro.Value != null)
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                        else
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, "NULL");
                        break;
                    default:
                        if (Sqlparametro.Value != null)
                            respuesta.AppendFormat("{0}='{1}'", Sqlparametro.ParameterName, Sqlparametro.Value.ToString());
                        else
                            respuesta.AppendFormat("{0}={1}", Sqlparametro.ParameterName, "NULL");
                        break;
                }
            }
            return respuesta.ToString();
        }




    }
}
