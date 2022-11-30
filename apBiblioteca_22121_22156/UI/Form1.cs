using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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
                try
                {
                    string _conexaoSQLServer = $"Data Source=regulus.cotuca.unicamp.br;Initial Catalog={txtBanco.Text}; " +
                   $"User id={txtUsuario.Text}; Password={txtSenha.Text}";
                    SqlConnection _conexao = new SqlConnection(_conexaoSQLServer);
                    _conexao.Open();
                    formLivros.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.ToString());
                }
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
                try
                {
                    string _conexaoSQLServer = $"Data Source=regulus.cotuca.unicamp.br;Initial Catalog={txtBanco.Text}; " +
                   $"User id={txtUsuario.Text}; Password={txtSenha.Text}";
                    SqlConnection _conexao = new SqlConnection(_conexaoSQLServer);
                    _conexao.Open();
                    formLeitores.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.ToString());
                }
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
                try
                {
                    string _conexaoSQLServer = $"Data Source=regulus.cotuca.unicamp.br;Initial Catalog={txtBanco.Text}; " +
                   $"User id={txtUsuario.Text}; Password={txtSenha.Text}";
                    SqlConnection _conexao = new SqlConnection(_conexaoSQLServer);
                    _conexao.Open();
                    formOperacoes.Show();
                    formOperacoes.abrirPaginaEmprestimos(); // Vai diretamente para a pagina de emprestimos
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.ToString());
                }
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
                try
                {
                    string _conexaoSQLServer = $"Data Source=regulus.cotuca.unicamp.br;Initial Catalog={txtBanco.Text}; " +
                   $"User id={txtUsuario.Text}; Password={txtSenha.Text}";
                    SqlConnection _conexao = new SqlConnection(_conexaoSQLServer);
                    _conexao.Open();
                    formOperacoes.Show();
                    formOperacoes.abrirPaginaDevolucoes(); // Vai diretamente para a pagina de devolucoes
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.ToString());
                }
            }
        }
    }
}
