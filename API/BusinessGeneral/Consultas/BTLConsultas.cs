using BusinessGeneral.General;
using DALGeneral.DAO;
using Entidades.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BusinessGeneral.Consultas
{
    public class BTLConsultas : BTLBase
    {
        protected DALConsultas daoConsultas;
        public BTLConsultas()
        {
            daoConsultas = new DALConsultas();
        }
        public BTLConsultas(System.Data.IDbTransaction transaccion)
        {
            daoConsultas = new DALConsultas();
            this.ContextoTransaccional = transaccion;
        }
        public ResponseStores ObtieneTiendas()
        {
            ResponseStores responseStores = new ResponseStores();
            List<Store> lstStores = daoConsultas.ObtieneTiendas();
            if (lstStores.Count > 0)
            {
                responseStores.Stores = lstStores;
                responseStores.success = true;
                responseStores.total_elements = lstStores.Count;
            }
           
            return responseStores;
        }
        public ResponseArticles ObtieneArticulos()
        {

            ResponseArticles responseArticle = new ResponseArticles();
            List<article> lstArticles = daoConsultas.ObtieneArticulos();
            if (lstArticles.Count > 0)
            {
                responseArticle.Articles = lstArticles;
                responseArticle.success = true;
                responseArticle.total_elements = lstArticles.Count;
            }
            
            return responseArticle;            
        }

        public ResponseArticles ObtieneArticulosPorTienda(string IdStore)
        {
            ResponseArticles responseArticle = new ResponseArticles();
            int numericValue;
            bool isNumber = int.TryParse(IdStore, out numericValue);
            if (isNumber)
            {
                List<article> lstArticles = daoConsultas.ObtieneArticulosPorTienda(numericValue);
                if (lstArticles.Count > 0)
                {
                    responseArticle.Articles = lstArticles;
                    responseArticle.success = true;
                    responseArticle.total_elements = lstArticles.Count;
                }
                else {
                    responseArticle.error_msg = "Record not Found";
                    responseArticle.success = false;
                    responseArticle.total_elements = 0;
                    responseArticle.error_code = "404";
               }
            }  else {
                responseArticle.error_msg = "Bad Request";
                responseArticle.success = false;
                responseArticle.total_elements = 0;
                responseArticle.error_code = "400";
            }
            
            return responseArticle;
        }
    }
}
