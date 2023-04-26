using AplicacionEscritorio.ApiHelper;
using AplicacionEscritorio.Entidades;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscritorio.AppCode.Modulos.Tiendas
{
    public partial class frmCatalogoTiendas : Form
    {
        public frmCatalogoTiendas()
        {
            InitializeComponent();
        }

        private void frmCatalogoTiendas_Load(object sender, EventArgs e)
        {
            LlenaGrid();
        }
        private async void LlenaGrid()
        {
            //Creamos el listado de Posts a llenar
            ResponseStores listado = new ResponseStores();
            ResponseStores obj = new ResponseStores();
            //Instanciamos un objeto Reply
            Reply oReply = new Reply();
            //poblamos el objeto con el método generic Execute
            oReply = await Consumer.Execute<ResponseStores>("https://localhost:44367/api/Services/stores", ApiHelper.methodHttp.GET, listado);
                       
            obj = (ResponseStores)oReply.Data;
                        
            //Poblamos el datagridview
            this.dgvCatTiendas.DataSource = obj.Stores;
            lblRegistros.Text = "Registros: " + obj.total_elements;
            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            //MessageBox.Show(oReply.StatusCode);
        }
    }
}
