using BusinessGeneral.Consultas;
using Entidades.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ServicesController : ApiController
    {
        [HttpGet]
        public ResponseStores stores()
        {
            return new BTLConsultas().ObtieneTiendas();            
        }
        [HttpGet]
        public ResponseArticles articles()
        {
            return new BTLConsultas().ObtieneArticulos();
        }

        [HttpPost]
        public ResponseArticles articlesbystore(string IdStore)
        {
            return new BTLConsultas().ObtieneArticulosPorTienda(IdStore);
        }
    }
}