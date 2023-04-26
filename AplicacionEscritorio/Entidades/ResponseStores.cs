using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace AplicacionEscritorio.Entidades
{
    public class ResponseStores
    {
        public ResponseStores()
        {
            this.Stores = new List<store>();
            this.total_elements = 0;
            this.success = false;
            this.error_code = string.Empty;
            this.error_msg = string.Empty;
        }
        public List<store> Stores { get; set; }
        public bool success { get; set; }
        public int total_elements { get; set; }
        public string error_msg { get; set; }
        public string error_code { get; set; }
    }
}
