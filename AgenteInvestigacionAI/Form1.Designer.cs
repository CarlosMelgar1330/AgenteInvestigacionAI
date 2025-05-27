namespace AgenteInvestigacionAI
{
    partial class SearchIA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchIA));
            this.txtTema = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnInvestigar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTema
            // 
            this.txtTema.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            resources.ApplyResources(this.txtTema, "txtTema");
            this.txtTema.ForeColor = System.Drawing.SystemColors.Window;
            this.txtTema.Name = "txtTema";
            this.txtTema.TextChanged += new System.EventHandler(this.txtTema_TextChanged);
            // 
            // txtResultado
            // 
            this.txtResultado.AcceptsReturn = true;
            resources.ApplyResources(this.txtResultado, "txtResultado");
            this.txtResultado.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtResultado.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtResultado.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.TextChanged += new System.EventHandler(this.txtResultado_TextChanged);
            // 
            // btnInvestigar
            // 
            this.btnInvestigar.BackgroundImage = global::AgenteInvestigacionAI.Properties.Resources.descarga__35_;
            this.btnInvestigar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInvestigar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btnInvestigar, "btnInvestigar");
            this.btnInvestigar.Name = "btnInvestigar";
            this.btnInvestigar.UseVisualStyleBackColor = true;
            this.btnInvestigar.Click += new System.EventHandler(this.btnInvestigar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoEllipsis = true;
            this.lblEstado.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblEstado.Image = global::AgenteInvestigacionAI.Properties.Resources.descarga__35_2;
            resources.ApplyResources(this.lblEstado, "lblEstado");
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // SearchIA
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AgenteInvestigacionAI.Properties.Resources.descarga__35_1;
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnInvestigar);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.txtTema);
            this.MaximizeBox = false;
            this.Name = "SearchIA";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnInvestigar;
        private System.Windows.Forms.Label lblEstado;
    }
}

