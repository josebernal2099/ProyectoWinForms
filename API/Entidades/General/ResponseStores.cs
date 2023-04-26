using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.General
{
    public class ResponseStores
    {
        public ResponseStores() { 
            this.Stores = new List<Store>();
            this.total_elements = 0;
            this.success = false;
            this.error_code = string.Empty;
            this.error_msg = string.Empty;
        }
        public List<Store> Stores { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
        public string error_msg { get; set; }
        public string error_code { get; set; }
    }
}
