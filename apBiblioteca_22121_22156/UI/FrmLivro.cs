using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace apBiblioteca_22121_22156.UI
{
    public partial class FrmLivro : Form
    {
        public string banco, usuario, senha;

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtCodLivro.Text != "" || txtTituloLivro.Text != "" || txtAutorLivro.Text != "")
            {
                Livro livro = new Livro(0, "", "", "");
                livro.CodigoLivro = txtCodLivro.Text;
                livro.TituloLivro = txtTituloLivro.Text;
                livro.AutorLivro = txtAutorLivro.Text;
                try
                {

                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    bll.IncluirLivro(livro);
                    MessageBox.Show("Inclusão feita com sucesso!");
                    Livro aux = bll.SelecionarLivroPorCodigo(livro.CodigoLivro);
                    txtIdLivro.Text = aux.IdLivro.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Preencha todos os campos corretamente!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodLivro.Text != "" || txtTituloLivro.Text != "" || txtAutorLivro.Text != "")
            {
                Livro livro = new Livro(int.Parse(txtIdLivro.Text),
                                        txtCodLivro.Text,
                                        txtTituloLivro.Text,
                                        txtAutorLivro.Text);
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    bll.AlterarLivro(livro);
                    MessageBox.Show("Alteração feita com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Preencha os campos corretamente para realizar as alterações!");                  
        }

        private void btnExcluir_Click(object sender, EventArgs e)  // dando erro se nao passa o codigo
        {
            if (txtCodLivro.Text != "")
            {
                Livro livro = new Livro(Convert.ToInt32(txtIdLivro.Text), "", "", "");
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    bll.ExcluirLivro(livro);
                    MessageBox.Show("Exclusão feita com sucesso!");
                    LimparTela();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Digite o código do livro que deseja excluir!");
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtCodLivro.Text != "")
            {
                string codigo = txtCodLivro.Text;
                Livro livro = null;
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    livro = bll.SelecionarLivroPorCodigo(codigo);
                    txtIdLivro.Text = livro.IdLivro + "";
                    txtCodLivro.Text = livro.CodigoLivro;
                    txtTituloLivro.Text = livro.TituloLivro;
                    txtAutorLivro.Text = livro.AutorLivro;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
                MessageBox.Show("Digite o código do livro que deseja procurar!");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                LivroBLL bll        = new LivroBLL(banco, usuario, senha);
                //dgvLivro.DataSource = bll.SelecionarLivros();
                DataTable teste = bll.SelecionarLivros();
                 
                //dgvLivro.DataSource = teste;
                for (int i = 0; i < teste.Rows.Count; i++)
                {
                    if (i != teste.Rows.Count - 1)
                        dgvLivro.Rows.Add();

                    dgvLivro[0, i].Value = teste.Rows[i][0]; // Id
                    dgvLivro[1, i].Value = teste.Rows[i][1]; // Cod
                    dgvLivro[2, i].Value = teste.Rows[i][2]; // Titulo
                    dgvLivro[3, i].Value = teste.Rows[i][3]; // Autor   
                }
                tcLivro.SelectTab(tpLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        public void LimparTela()
        {
            txtIdLivro.Text     = "";
            txtTituloLivro.Text = "";
            txtCodLivro.Text    = "";
            txtAutorLivro.Text  = "";
        }

        public FrmLivro()
        {
            InitializeComponent();
        }

        
    }
}
