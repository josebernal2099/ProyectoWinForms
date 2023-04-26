namespace AplicacionEscritorio.AppCode.Modulos.MainPanel
{
    partial class MDIMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuTiendas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCatalogoTiendas = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoDeArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTiendas,
            this.articulosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1159, 81);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuTiendas
            // 
            this.mnuTiendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnCatalogoTiendas});
            this.mnuTiendas.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTiendas.Image = ((System.Drawing.Image)(resources.GetObject("mnuTiendas.Image")));
            this.mnuTiendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mnuTiendas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuTiendas.Name = "mnuTiendas";
            this.mnuTiendas.Size = new System.Drawing.Size(95, 77);
            this.mnuTiendas.Text = "Tiendas";
            this.mnuTiendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnCatalogoTiendas
            // 
            this.mnCatalogoTiendas.Image = ((System.Drawing.Image)(resources.GetObject("mnCatalogoTiendas.Image")));
            this.mnCatalogoTiendas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnCatalogoTiendas.Name = "mnCatalogoTiendas";
            this.mnCatalogoTiendas.Size = new System.Drawing.Size(308, 58);
            this.mnCatalogoTiendas.Text = "Catálogo de tiendas";
            this.mnCatalogoTiendas.Click += new System.EventHandler(this.mnConsultaTiendas_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 665);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1159, 32);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(66, 25);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogoDeArticulosToolStripMenuItem});
            this.articulosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.articulosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("articulosToolStripMenuItem.Image")));
            this.articulosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(104, 77);
            this.articulosToolStripMenuItem.Text = "Articulos";
            this.articulosToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // catálogoDeArticulosToolStripMenuItem
            // 
            this.catálogoDeArticulosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("catálogoDeArticulosToolStripMenuItem.Image")));
            this.catálogoDeArticulosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.catálogoDeArticulosToolStripMenuItem.Name = "catálogoDeArticulosToolStripMenuItem";
            this.catálogoDeArticulosToolStripMenuItem.Size = new System.Drawing.Size(319, 58);
            this.catálogoDeArticulosToolStripMenuItem.Text = "Catálogo de articulos";
            this.catálogoDeArticulosToolStripMenuItem.Click += new System.EventHandler(this.catálogoDeArticulosToolStripMenuItem_Click);
            // 
            // MDIMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MDIMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuTiendas;
        private System.Windows.Forms.ToolStripMenuItem mnCatalogoTiendas;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoDeArticulosToolStripMenuItem;
    }
}



