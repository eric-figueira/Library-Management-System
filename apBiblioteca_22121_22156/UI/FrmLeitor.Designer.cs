﻿namespace apBiblioteca_22121_22156.UI
{
    partial class FrmLeitor
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
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtEnderecoLeitor = new System.Windows.Forms.TextBox();
            this.txtTelefoneLeitor = new System.Windows.Forms.TextBox();
            this.txtNomeLeitor = new System.Windows.Forms.TextBox();
            this.txtIdLeitor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmailLeitor = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCadastro = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tpLista = new System.Windows.Forms.TabPage();
            this.dgvLivro = new System.Windows.Forms.DataGridView();
            this.IdLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TituloLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutorLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpCadastro.SuspendLayout();
            this.tpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(303, 22);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(114, 38);
            this.btnProcurar.TabIndex = 24;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(290, 290);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(114, 38);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(160, 290);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(114, 38);
            this.btnAlterar.TabIndex = 21;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExibir
            // 
            this.btnExibir.Location = new System.Drawing.Point(420, 290);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(114, 38);
            this.btnExibir.TabIndex = 22;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(30, 290);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(114, 38);
            this.btnNovo.TabIndex = 20;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtEnderecoLeitor
            // 
            this.txtEnderecoLeitor.Location = new System.Drawing.Point(138, 228);
            this.txtEnderecoLeitor.MaxLength = 100;
            this.txtEnderecoLeitor.Name = "txtEnderecoLeitor";
            this.txtEnderecoLeitor.Size = new System.Drawing.Size(398, 26);
            this.txtEnderecoLeitor.TabIndex = 19;
            // 
            // txtTelefoneLeitor
            // 
            this.txtTelefoneLeitor.Location = new System.Drawing.Point(138, 128);
            this.txtTelefoneLeitor.MaxLength = 20;
            this.txtTelefoneLeitor.Name = "txtTelefoneLeitor";
            this.txtTelefoneLeitor.Size = new System.Drawing.Size(398, 26);
            this.txtTelefoneLeitor.TabIndex = 18;
            // 
            // txtNomeLeitor
            // 
            this.txtNomeLeitor.Location = new System.Drawing.Point(138, 78);
            this.txtNomeLeitor.MaxLength = 50;
            this.txtNomeLeitor.Name = "txtNomeLeitor";
            this.txtNomeLeitor.Size = new System.Drawing.Size(398, 26);
            this.txtNomeLeitor.TabIndex = 17;
            // 
            // txtIdLeitor
            // 
            this.txtIdLeitor.Location = new System.Drawing.Point(138, 28);
            this.txtIdLeitor.Name = "txtIdLeitor";
            this.txtIdLeitor.ReadOnly = true;
            this.txtIdLeitor.Size = new System.Drawing.Size(136, 26);
            this.txtIdLeitor.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Endereço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Telefone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Email:";
            // 
            // txtEmailLeitor
            // 
            this.txtEmailLeitor.Location = new System.Drawing.Point(138, 178);
            this.txtEmailLeitor.MaxLength = 50;
            this.txtEmailLeitor.Name = "txtEmailLeitor";
            this.txtEmailLeitor.Size = new System.Drawing.Size(398, 26);
            this.txtEmailLeitor.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpCadastro);
            this.tabControl1.Controls.Add(this.tpLista);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(679, 392);
            this.tabControl1.TabIndex = 27;
            // 
            // tpCadastro
            // 
            this.tpCadastro.Controls.Add(this.txtEmailLeitor);
            this.tpCadastro.Controls.Add(this.btnExibir);
            this.tpCadastro.Controls.Add(this.btnExcluir);
            this.tpCadastro.Controls.Add(this.txtIdLeitor);
            this.tpCadastro.Controls.Add(this.txtEnderecoLeitor);
            this.tpCadastro.Controls.Add(this.label5);
            this.tpCadastro.Controls.Add(this.btnAlterar);
            this.tpCadastro.Controls.Add(this.btnProcurar);
            this.tpCadastro.Controls.Add(this.txtTelefoneLeitor);
            this.tpCadastro.Controls.Add(this.btnNovo);
            this.tpCadastro.Controls.Add(this.txtNomeLeitor);
            this.tpCadastro.Controls.Add(this.label9);
            this.tpCadastro.Controls.Add(this.label4);
            this.tpCadastro.Controls.Add(this.label2);
            this.tpCadastro.Controls.Add(this.label3);
            this.tpCadastro.Location = new System.Drawing.Point(4, 29);
            this.tpCadastro.Name = "tpCadastro";
            this.tpCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tpCadastro.Size = new System.Drawing.Size(671, 359);
            this.tpCadastro.TabIndex = 0;
            this.tpCadastro.Text = "Cadastro";
            this.tpCadastro.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Identificação:";
            // 
            // tpLista
            // 
            this.tpLista.Controls.Add(this.dgvLivro);
            this.tpLista.Location = new System.Drawing.Point(4, 29);
            this.tpLista.Name = "tpLista";
            this.tpLista.Padding = new System.Windows.Forms.Padding(3);
            this.tpLista.Size = new System.Drawing.Size(671, 359);
            this.tpLista.TabIndex = 1;
            this.tpLista.Text = "Lista";
            this.tpLista.UseVisualStyleBackColor = true;
            // 
            // dgvLivro
            // 
            this.dgvLivro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLivro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdLivro,
            this.CodLivro,
            this.TituloLivro,
            this.AutorLivro});
            this.dgvLivro.Location = new System.Drawing.Point(0, 0);
            this.dgvLivro.Name = "dgvLivro";
            this.dgvLivro.Size = new System.Drawing.Size(671, 349);
            this.dgvLivro.TabIndex = 0;
            // 
            // IdLivro
            // 
            this.IdLivro.HeaderText = "Identificação";
            this.IdLivro.Name = "IdLivro";
            this.IdLivro.ReadOnly = true;
            this.IdLivro.Width = 110;
            // 
            // CodLivro
            // 
            this.CodLivro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodLivro.HeaderText = "Código";
            this.CodLivro.MaxInputLength = 10;
            this.CodLivro.Name = "CodLivro";
            this.CodLivro.Width = 110;
            // 
            // TituloLivro
            // 
            this.TituloLivro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TituloLivro.HeaderText = "Título";
            this.TituloLivro.MaxInputLength = 50;
            this.TituloLivro.Name = "TituloLivro";
            this.TituloLivro.Width = 200;
            // 
            // AutorLivro
            // 
            this.AutorLivro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AutorLivro.HeaderText = "Autor(es)";
            this.AutorLivro.MaxInputLength = 50;
            this.AutorLivro.Name = "AutorLivro";
            this.AutorLivro.Width = 200;
            // 
            // FrmLeitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(709, 422);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmLeitor";
            this.Text = "Manutenção de Leitores da Biblioteca";
            this.tabControl1.ResumeLayout(false);
            this.tpCadastro.ResumeLayout(false);
            this.tpCadastro.PerformLayout();
            this.tpLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TextBox txtEnderecoLeitor;
        private System.Windows.Forms.TextBox txtTelefoneLeitor;
        private System.Windows.Forms.TextBox txtNomeLeitor;
        private System.Windows.Forms.TextBox txtIdLeitor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmailLeitor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCadastro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tpLista;
        private System.Windows.Forms.DataGridView dgvLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TituloLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutorLivro;
    }
}