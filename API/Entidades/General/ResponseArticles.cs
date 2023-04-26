using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class ResponseArticles
    {
        public ResponseArticles() { 
            this.success = false;
            this.Articles = new List<article> ();
            this.error_code = string.Empty;
            this.error_msg = string.Empty;            
            this.total_elements = 0;
        }
        public List<article> Articles { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
        public string error_msg { get; set; }
        public string error_code { get; set; }        
    }
}
