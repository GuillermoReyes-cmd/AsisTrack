namespace CapaPresentacion
{
    partial class UcAuditoria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
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
            this.grpAuditoria = new System.Windows.Forms.GroupBox();
            this.lblCreatedByT = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedAtT = new System.Windows.Forms.Label();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblModifiedByT = new System.Windows.Forms.Label();
            this.lblModifiedBy = new System.Windows.Forms.Label();
            this.lblModifiedAtT = new System.Windows.Forms.Label();
            this.lblModifiedAt = new System.Windows.Forms.Label();
            this.grpAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAuditoria
            // 
            this.grpAuditoria.Controls.Add(this.lblCreatedByT);
            this.grpAuditoria.Controls.Add(this.lblCreatedBy);
            this.grpAuditoria.Controls.Add(this.lblCreatedAtT);
            this.grpAuditoria.Controls.Add(this.lblCreatedAt);
            this.grpAuditoria.Controls.Add(this.lblModifiedByT);
            this.grpAuditoria.Controls.Add(this.lblModifiedBy);
            this.grpAuditoria.Controls.Add(this.lblModifiedAtT);
            this.grpAuditoria.Controls.Add(this.lblModifiedAt);
            this.grpAuditoria.Name = "grpAuditoria";
            this.grpAuditoria.TabIndex = 0;
            this.grpAuditoria.Text = "Auditoría (RNF-04)";
            this.grpAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // lblCreatedByT
            // 
            this.lblCreatedByT.Location = new System.Drawing.Point(12, 24);
            this.lblCreatedByT.Name = "lblCreatedByT";
            this.lblCreatedByT.TabIndex = 1;
            this.lblCreatedByT.Text = "CreatedBy:";
            this.lblCreatedByT.AutoSize = true;
            this.lblCreatedByT.ForeColor = System.Drawing.Color.Gray;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Location = new System.Drawing.Point(110, 24);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.TabIndex = 2;
            this.lblCreatedBy.Text = "—";
            this.lblCreatedBy.AutoSize = true;
            // 
            // lblCreatedAtT
            // 
            this.lblCreatedAtT.Location = new System.Drawing.Point(12, 46);
            this.lblCreatedAtT.Name = "lblCreatedAtT";
            this.lblCreatedAtT.TabIndex = 3;
            this.lblCreatedAtT.Text = "CreatedAt:";
            this.lblCreatedAtT.AutoSize = true;
            this.lblCreatedAtT.ForeColor = System.Drawing.Color.Gray;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Location = new System.Drawing.Point(110, 46);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.TabIndex = 4;
            this.lblCreatedAt.Text = "—";
            this.lblCreatedAt.AutoSize = true;
            // 
            // lblModifiedByT
            // 
            this.lblModifiedByT.Location = new System.Drawing.Point(12, 68);
            this.lblModifiedByT.Name = "lblModifiedByT";
            this.lblModifiedByT.TabIndex = 5;
            this.lblModifiedByT.Text = "ModifiedBy:";
            this.lblModifiedByT.AutoSize = true;
            this.lblModifiedByT.ForeColor = System.Drawing.Color.Gray;
            // 
            // lblModifiedBy
            // 
            this.lblModifiedBy.Location = new System.Drawing.Point(110, 68);
            this.lblModifiedBy.Name = "lblModifiedBy";
            this.lblModifiedBy.TabIndex = 6;
            this.lblModifiedBy.Text = "—";
            this.lblModifiedBy.AutoSize = true;
            // 
            // lblModifiedAtT
            // 
            this.lblModifiedAtT.Location = new System.Drawing.Point(12, 90);
            this.lblModifiedAtT.Name = "lblModifiedAtT";
            this.lblModifiedAtT.TabIndex = 7;
            this.lblModifiedAtT.Text = "ModifiedAt:";
            this.lblModifiedAtT.AutoSize = true;
            this.lblModifiedAtT.ForeColor = System.Drawing.Color.Gray;
            // 
            // lblModifiedAt
            // 
            this.lblModifiedAt.Location = new System.Drawing.Point(110, 90);
            this.lblModifiedAt.Name = "lblModifiedAt";
            this.lblModifiedAt.TabIndex = 8;
            this.lblModifiedAt.Text = "—";
            this.lblModifiedAt.AutoSize = true;
            // 
            // UcAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(340, 118);
            this.Controls.Add(this.grpAuditoria);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "UcAuditoria";
            this.grpAuditoria.ResumeLayout(false);
            this.grpAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpAuditoria;
        private System.Windows.Forms.Label lblCreatedByT;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCreatedAtT;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblModifiedByT;
        private System.Windows.Forms.Label lblModifiedBy;
        private System.Windows.Forms.Label lblModifiedAtT;
        private System.Windows.Forms.Label lblModifiedAt;
    }
}
