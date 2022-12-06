namespace apBiblioteca_22121_22156.UI
{
    partial class FrmRelatorio
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
            this.lbRelatorio = new System.Windows.Forms.Label();
            this.cbRelatorio = new System.Windows.Forms.ComboBox();
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRelatorio
            // 
            this.lbRelatorio.AutoSize = true;
            this.lbRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRelatorio.Location = new System.Drawing.Point(10, 13);
            this.lbRelatorio.Name = "lbRelatorio";
            this.lbRelatorio.Size = new System.Drawing.Size(127, 25);
            this.lbRelatorio.TabIndex = 6;
            this.lbRelatorio.Text = "Relatório por:";
            // 
            // cbRelatorio
            // 
            this.cbRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRelatorio.FormattingEnabled = true;
            this.cbRelatorio.Items.AddRange(new object[] {
            "Livro",
            "Leitor"});
            this.cbRelatorio.Location = new System.Drawing.Point(143, 10);
            this.cbRelatorio.Name = "cbRelatorio";
            this.cbRelatorio.Size = new System.Drawing.Size(121, 28);
            this.cbRelatorio.TabIndex = 7;
            this.cbRelatorio.SelectedValueChanged += new System.EventHandler(this.cbRelatorio_SelectedValueChanged);
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.Location = new System.Drawing.Point(13, 51);
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.Size = new System.Drawing.Size(689, 363);
            this.dgvRelatorio.TabIndex = 8;
            // 
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 426);
            this.Controls.Add(this.dgvRelatorio);
            this.Controls.Add(this.cbRelatorio);
            this.Controls.Add(this.lbRelatorio);
            this.Name = "FrmRelatorio";
            this.Text = "FrmRelatorio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRelatorio;
        private System.Windows.Forms.ComboBox cbRelatorio;
        private System.Windows.Forms.DataGridView dgvRelatorio;
    }
}