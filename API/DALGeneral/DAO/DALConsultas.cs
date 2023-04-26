using DALGeneral.Scripts;
using Entidades.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGeneral.DAO
{
    public class DALConsultas : DAOBase
    {
        private AdoHelper adoHelper;
        private readonly string _strConexion;
        public DALConsultas()
        {
            adoHelper = AdoHelper.CreateHelper();
            _strConexion = AdoHelper.ConnectionString;
            base.InicializaError();
            base.Resultado = new DALGeneral.Resultado();
        }
        //public DataTable ObtieneConsulta()
        //{
        //    DataTable Ejec;
        //    ProcedimientoAlmacenado sp = ScriptConsultas.ObtenerConsulta();
        //    base.Resultado.ComandoEjecutado = sp.SentenciaSQL;
        //    if (_contextoTransaccional == null)
        //        Ejec = adoHelper.ExecuteDataset(_strConexion, sp.Nombre, sp.ParametrosEnArreglo).Tables[0];
        //    else
        //    {
        //        Ejec = adoHelper.ExecuteDataset(_contextoTransaccional, sp.Nombre, sp.ParametrosEnArreglo).Tables[0];
        //    }

        //    return Ejec;
        //}

        public List<Store> ObtieneTiendas()
        {
            IDataReader Ejec;
            List<Store> lstStores = new List<Store>();
            ProcedimientoAlmacenado sp = ScriptConsultas.ObtenerTiendas();
            base.Resultado.ComandoEjecutado = sp.SentenciaSQL;
            if (_contextoTransaccional == null)
                Ejec = adoHelper.ExecuteReader(_strConexion, sp.Nombre, sp.ParametrosEnArreglo);
            else
            {
                Ejec = adoHelper.ExecuteReader(_contextoTransaccional, sp.Nombre, sp.ParametrosEnArreglo);
            }

            while (Ejec.Read())
            {
                Store objStore = new Store();

                objStore.id = Ejec.GetInt32(Ejec.GetOrdinal("id"));
                objStore.name = Ejec.GetString(Ejec.GetOrdinal("name"));
                objStore.address = Ejec.GetString(Ejec.GetOrdinal("address"));

                lstStores.Add(objStore);
            }
            return lstStores;
        }
        public List<article> ObtieneArticulos()
        {
            IDataReader Ejec;
            List<article> lstArticles = new List<article>();
            ProcedimientoAlmacenado sp = ScriptConsultas.ObtenerArticulos();
            base.Resultado.ComandoEjecutado = sp.SentenciaSQL;
            if (_contextoTransaccional == null)
                Ejec = adoHelper.ExecuteReader(_strConexion, sp.Nombre, sp.ParametrosEnArreglo);
            else
            {
                Ejec = adoHelper.ExecuteReader(_contextoTransaccional, sp.Nombre, sp.ParametrosEnArreglo);
            }

            while (Ejec.Read())
            {
                article objArticle = new article();

                objArticle.id = Ejec.GetInt32(Ejec.GetOrdinal("id"));
                objArticle.name = Ejec.GetString(Ejec.GetOrdinal("name"));
                objArticle.description = Ejec.GetString(Ejec.GetOrdinal("description"));
                objArticle.price = Ejec.GetDouble(Ejec.GetOrdinal("price"));
                objArticle.total_in_shelf = Ejec.GetInt32(Ejec.GetOrdinal("total_in_shelf"));
                objArticle.total_in_vault = Ejec.GetInt32(Ejec.GetOrdinal("total_in_vault"));
                objArticle.store_name = Ejec.GetString(Ejec.GetOrdinal("store_name"));

                lstArticles.Add(objArticle);
            }
            return lstArticles;
        }

        public List<article> ObtieneArticulosPorTienda(int IdStore)
        {
            IDataReader Ejec;
            List<article> lstArticles = new List<article>();
            ProcedimientoAlmacenado sp = ScriptConsultas.ObtenerArticulosPorTienda(IdStore);
            base.Resultado.ComandoEjecutado = sp.SentenciaSQL;
            if (_contextoTransaccional == null)
                Ejec = adoHelper.ExecuteReader(_strConexion, sp.Nombre, sp.ParametrosEnArreglo);
            else
            {
                Ejec = adoHelper.ExecuteReader(_contextoTransaccional, sp.Nombre, sp.ParametrosEnArreglo);
            }

            while (Ejec.Read())
            {
                article objArticle = new article();

                objArticle.id = Ejec.GetInt32(Ejec.GetOrdinal("id"));
                objArticle.description = Ejec.GetString(Ejec.GetOrdinal("name"));
                objArticle.price = Ejec.GetDouble(Ejec.GetOrdinal("price"));
                objArticle.total_in_shelf = Ejec.GetInt32(Ejec.GetOrdinal("total_in_shelf"));
                objArticle.total_in_vault = Ejec.GetInt32(Ejec.GetOrdinal("total_in_vault"));
                objArticle.store_name = Ejec.GetString(Ejec.GetOrdinal("store_name"));

                lstArticles.Add(objArticle);
            }
            return lstArticles;
        }
    }
}
