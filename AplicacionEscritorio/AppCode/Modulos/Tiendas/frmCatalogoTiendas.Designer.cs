namespace AplicacionEscritorio.AppCode.Modulos.Tiendas
{
    partial class frmCatalogoTiendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCatTiendas = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatTiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCatTiendas
            // 
            this.dgvCatTiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatTiendas.Location = new System.Drawing.Point(12, 98);
            this.dgvCatTiendas.Name = "dgvCatTiendas";
            this.dgvCatTiendas.RowHeadersWidth = 62;
            this.dgvCatTiendas.RowTemplate.Height = 28;
            this.dgvCatTiendas.Size = new System.Drawing.Size(776, 272);
            this.dgvCatTiendas.TabIndex = 0;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(694, 393);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(94, 20);
            this.lblRegistros.TabIndex = 1;
            this.lblRegistros.Text = "Registros: 0";
            // 
            // frmCatalogoTiendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dgvCatTiendas);
            this.Name = "frmCatalogoTiendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de tiendas";
            this.Load += new System.EventHandler(this.frmCatalogoTiendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatTiendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCatTiendas;
        private System.Windows.Forms.Label lblRegistros;
    }
}