/*
    PARTICIPANTES:
    1 - Beatriz Juliato Coutinho - RA: 22121
    2 - Éric Carvalho Figueira   - RA: 22156
*/

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

        private void btnExcluir_Click(object sender, EventArgs e) 
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
                    if (livro != null)
                    {
                        txtIdLivro.Text     = livro.IdLivro + "";
                        txtCodLivro.Text    = livro.CodigoLivro;
                        txtTituloLivro.Text = livro.TituloLivro;
                        txtAutorLivro.Text  = livro.AutorLivro;
                    }
                    else
                    {
                        MessageBox.Show("Erro: Livro não encontrado no banco de dados");
                        LimparTela();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
                MessageBox.Show("Digite o código do livro que deseja procurar!");
        }

        private void btnExibir_Click(object sender, EventArgs e) // Mesmo evento para o Enter do tpLista
        {
            try
            {
                LivroBLL bll        = new LivroBLL(banco, usuario, senha);

                DataTable aux = bll.SelecionarLivros(); // aux é um DataTable auxiliar

                dgvLivro.Rows.Clear(); // Limpamos as linhas do dgvLivro para nao ficarem acumulando
                for (int i = 0; i < aux.Rows.Count; i++) // Percorremos as linha de aux
                {
                    if (i != aux.Rows.Count - 1) // Adicionamos uma linha ao final do dgvLivro caso nao seja o ultimo registro
                        dgvLivro.Rows.Add();

                    dgvLivro[0, i].Value = aux.Rows[i][0]; // Na coluna 0 da linha i do dgvLeitor adicionamos o valor que esta em aux na linha i coluna 0 (Id Livro)
                    dgvLivro[1, i].Value = aux.Rows[i][1]; // Codigo Livro
                    dgvLivro[2, i].Value = aux.Rows[i][2]; // Titulo Livro
                    dgvLivro[3, i].Value = aux.Rows[i][3]; // Autor  Livro
                }
                tcLivro.SelectTab(tpLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }

        private void dgvLivro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vamos pegar os dados das celulas da linha na qual o usuario clicou, redirecionar este para a aba de cadastro, e colocar
            // os dados referentes ao livro nos textboxes
            txtIdLivro.Text     = dgvLivro.CurrentRow.Cells[0].Value.ToString(); // 0 -> IdLivro
            txtCodLivro.Text    = dgvLivro.CurrentRow.Cells[1].Value.ToString(); // 1 -> Codigo Livro
            txtTituloLivro.Text = dgvLivro.CurrentRow.Cells[2].Value.ToString(); // 2 -> Titulo Livro
            txtAutorLivro.Text  = dgvLivro.CurrentRow.Cells[3].Value.ToString(); // 3 -> Autor Livro

            tcLivro.SelectTab(tpCadastro);
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
