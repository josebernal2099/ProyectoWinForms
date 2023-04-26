using AplicacionEscritorio.ApiHelper;
using AplicacionEscritorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscritorio.AppCode.Modulos.Articulos
{
    public partial class frmCatalogoArticulos : Form
    {
        public frmCatalogoArticulos()
        {
            InitializeComponent();
        }

        private void frmCatalogoArticulos_Load(object sender, EventArgs e)
        {
            rbTodos.Checked = true;
            txtIdTienda.Enabled = false;
            btnBuscar.Enabled = false;
            LlenaGrid();
        }

        private async void LlenaGrid()
        {
            dgvArticulos.DataSource = null;
            lblRegistros.Text = string.Empty;
            
            ResponseArticles listado = new ResponseArticles();
            ResponseArticles obj = new ResponseArticles();
            Reply oReply = new Reply();
            if (rbTodos.Checked) {
                oReply = await Consumer.Execute<ResponseArticles>("https://localhost:44367/api/Services/articles", ApiHelper.methodHttp.GET, listado);
                obj = (ResponseArticles)oReply.Data;
                if (!obj.success)
                {
                    MessageBox.Show(obj.error_code + " - " + obj.error_msg, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            } else
            {                
                oReply = await Consumer.Execute<ResponseArticles>("https://localhost:44367/api/Services/articlesbystore?IdStore=" + txtIdTienda.Text, ApiHelper.methodHttp.POST, listado);
                obj = (ResponseArticles)oReply.Data;
                if (!obj.success)
                {
                    MessageBox.Show(obj.error_code + " - " + obj.error_msg, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }              
                 
            dgvArticulos.DataSource = obj.Articles;
            lblRegistros.Text = "Registros: " + obj.total_elements;            
        }

        private void rbPorId_CheckedChanged(object sender, EventArgs e)
        {
            if(rbPorId.Checked)
            {
                txtIdTienda.Enabled = true;
                btnBuscar.Enabled = true;
            }
            else
            {
                txtIdTienda.Enabled = false;
                btnBuscar.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdTienda.Text.Length > 0)
                LlenaGrid();
            else
                MessageBox.Show("Por favor capture un Id de tienda", "Validación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
