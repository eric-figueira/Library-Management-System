using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apBiblioteca_22121_22156
{
    public partial class FrmPrincipal : Form
    {
        UI.FrmLivro formLivros           = null;
        UI.FrmLeitor formLeitores        = null;
        UI.FrmOperacoes formOperacoes    = null;
   

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void simToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão");
            else
            {
                formLivros         = new UI.FrmLivro();
                formLivros.banco   = txtBanco.Text;
                formLivros.usuario = txtUsuario.Text;
                formLivros.senha   = txtSenha.Text;
                formLivros.Show();
            }
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão");
            else
            {
                formLeitores         = new UI.FrmLeitor();
                formLeitores.banco   = txtBanco.Text;
                formLeitores.usuario = txtUsuario.Text;
                formLeitores.senha   = txtSenha.Text;
                formLivros.Show();
            }
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão");
            else
            {
                formOperacoes = new UI.FrmOperacoes();
                formOperacoes.banco = txtBanco.Text;
                formOperacoes.usuario = txtUsuario.Text;
                formOperacoes.senha = txtSenha.Text;
                formOperacoes.Show();
                formOperacoes.abrirPaginaEmprestimos(); // Vai diretamente para a pagina de emprestimos
            }
        }

        private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão");
            else
            {
                formOperacoes = new UI.FrmOperacoes();
                formOperacoes.banco = txtBanco.Text;
                formOperacoes.usuario = txtUsuario.Text;
                formOperacoes.senha = txtSenha.Text;
                formOperacoes.Show();
                formOperacoes.abrirPaginaDevolucoes(); // Vai diretamente para a pagina de devolucoes
            }
        }
    }
}
