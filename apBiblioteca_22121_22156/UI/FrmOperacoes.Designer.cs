namespace apBiblioteca_22121_22156.UI
{
    partial class FrmOperacoes
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbEmprestimo = new System.Windows.Forms.TabPage();
            this.dtpDataDevPrevista = new System.Windows.Forms.DateTimePicker();
            this.dtpDataEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.txtIdLivro = new System.Windows.Forms.TextBox();
            this.txtIdLeitor = new System.Windows.Forms.TextBox();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtIdEmprestimo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tpDevolucao = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tbEmprestimo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbEmprestimo);
            this.tabControl1.Controls.Add(this.tpDevolucao);
            this.tabControl1.Location = new System.Drawing.Point(13, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // tbEmprestimo
            // 
            this.tbEmprestimo.Controls.Add(this.dtpDataDevPrevista);
            this.tbEmprestimo.Controls.Add(this.dtpDataEmprestimo);
            this.tbEmprestimo.Controls.Add(this.txtIdLivro);
            this.tbEmprestimo.Controls.Add(this.txtIdLeitor);
            this.tbEmprestimo.Controls.Add(this.btnExibir);
            this.tbEmprestimo.Controls.Add(this.btnExcluir);
            this.tbEmprestimo.Controls.Add(this.txtIdEmprestimo);
            this.tbEmprestimo.Controls.Add(this.label5);
            this.tbEmprestimo.Controls.Add(this.btnAlterar);
            this.tbEmprestimo.Controls.Add(this.btnProcurar);
            this.tbEmprestimo.Controls.Add(this.btnNovo);
            this.tbEmprestimo.Controls.Add(this.label9);
            this.tbEmprestimo.Controls.Add(this.label4);
            this.tbEmprestimo.Controls.Add(this.label2);
            this.tbEmprestimo.Controls.Add(this.label3);
            this.tbEmprestimo.Location = new System.Drawing.Point(4, 29);
            this.tbEmprestimo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmprestimo.Name = "tbEmprestimo";
            this.tbEmprestimo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmprestimo.Size = new System.Drawing.Size(555, 335);
            this.tbEmprestimo.TabIndex = 0;
            this.tbEmprestimo.Text = "Empréstimos";
            this.tbEmprestimo.UseVisualStyleBackColor = true;
            // 
            // dtpDataDevPrevista
            // 
            this.dtpDataDevPrevista.CustomFormat = "dd/MM/yyyy";
            this.dtpDataDevPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDevPrevista.Location = new System.Drawing.Point(233, 212);
            this.dtpDataDevPrevista.Name = "dtpDataDevPrevista";
            this.dtpDataDevPrevista.Size = new System.Drawing.Size(128, 26);
            this.dtpDataDevPrevista.TabIndex = 45;
            // 
            // dtpDataEmprestimo
            // 
            this.dtpDataEmprestimo.CustomFormat = "dd/MMM/yyyy";
            this.dtpDataEmprestimo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmprestimo.Location = new System.Drawing.Point(233, 166);
            this.dtpDataEmprestimo.Name = "dtpDataEmprestimo";
            this.dtpDataEmprestimo.Size = new System.Drawing.Size(128, 26);
            this.dtpDataEmprestimo.TabIndex = 44;
            // 
            // txtIdLivro
            // 
            this.txtIdLivro.Location = new System.Drawing.Point(168, 117);
            this.txtIdLivro.Name = "txtIdLivro";
            this.txtIdLivro.ReadOnly = true;
            this.txtIdLivro.Size = new System.Drawing.Size(193, 26);
            this.txtIdLivro.TabIndex = 43;
            // 
            // txtIdLeitor
            // 
            this.txtIdLeitor.Location = new System.Drawing.Point(169, 64);
            this.txtIdLeitor.Name = "txtIdLeitor";
            this.txtIdLeitor.ReadOnly = true;
            this.txtIdLeitor.Size = new System.Drawing.Size(192, 26);
            this.txtIdLeitor.TabIndex = 42;
            // 
            // btnExibir
            // 
            this.btnExibir.Location = new System.Drawing.Point(409, 273);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(114, 38);
            this.btnExibir.TabIndex = 37;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(279, 273);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(114, 38);
            this.btnExcluir.TabIndex = 38;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtIdEmprestimo
            // 
            this.txtIdEmprestimo.Location = new System.Drawing.Point(168, 14);
            this.txtIdEmprestimo.Name = "txtIdEmprestimo";
            this.txtIdEmprestimo.ReadOnly = true;
            this.txtIdEmprestimo.Size = new System.Drawing.Size(193, 26);
            this.txtIdEmprestimo.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Data do Empréstimo:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(149, 273);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(114, 38);
            this.btnAlterar.TabIndex = 36;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(409, 8);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(114, 38);
            this.btnProcurar.TabIndex = 39;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(19, 273);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(114, 38);
            this.btnNovo.TabIndex = 35;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Identificação:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Data Prevista de Devolução:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Identificação Leitor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Identificação Livro:";
            // 
            // tpDevolucao
            // 
            this.tpDevolucao.Location = new System.Drawing.Point(4, 29);
            this.tpDevolucao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpDevolucao.Name = "tpDevolucao";
            this.tpDevolucao.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpDevolucao.Size = new System.Drawing.Size(555, 335);
            this.tpDevolucao.TabIndex = 1;
            this.tpDevolucao.Text = "Devoluções";
            this.tpDevolucao.UseVisualStyleBackColor = true;
            // 
            // FrmOperacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 389);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmOperacoes";
            this.Text = "FrmOperacoes";
            this.tabControl1.ResumeLayout(false);
            this.tbEmprestimo.ResumeLayout(false);
            this.tbEmprestimo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbEmprestimo;
        private System.Windows.Forms.TabPage tpDevolucao;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox txtIdEmprestimo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataEmprestimo;
        private System.Windows.Forms.TextBox txtIdLivro;
        private System.Windows.Forms.TextBox txtIdLeitor;
        private System.Windows.Forms.DateTimePicker dtpDataDevPrevista;
    }
}