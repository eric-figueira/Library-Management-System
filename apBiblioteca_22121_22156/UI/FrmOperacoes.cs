using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apBiblioteca_22121_22156.UI
{
    public partial class FrmOperacoes : Form
    {
        public string banco, usuario, senha;


        public FrmOperacoes()
        {
            InitializeComponent();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtIdEmprestimo.Text != "")
            {
                int id = int.Parse(txtIdEmprestimo.Text);
                Emprestimo emprestimo = null;
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    emprestimo = bll.SelecionarEmprestimoPorId(id);
                    txtIdLeitor.Text = emprestimo.IdLeitor + "";
                    txtIdLivro.Text = emprestimo.IdLivro + "";
                    dtpDataEmprestimo.Value = emprestimo.DataEmprestimo;
                    dtpDataDevPrevista.Value = emprestimo.DataDevolucaoPrevista;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
                txtIdEmprestimo.ReadOnly = true;
            }
            else
                MessageBox.Show("Erro: Dados de emprestimo inválidos!");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // Testamos se os valores nao sao vazios
            if (txtIdEmprestimo.Text != "" || txtIdLeitor.Text != "" || txtIdLivro.Text != "" || dtpDataDevPrevista.Value != null || dtpDataEmprestimo.Value != null)
            {
                Emprestimo emprestimo = new Emprestimo(0, 0, 0, new DateTime(), new DateTime(), new DateTime());
                // Precisamos testar se o id do leitor e do livro realmente existem
                try
                {
                    LivroBLL livBll = new LivroBLL(banco, usuario, senha);
                    if (livBll.SelecionarLivroPorId(int.Parse(txtIdLivro.Text)) == null)
                        MessageBox.Show("Erro: O livro com o ID informado não foi encontrado no banco de dados!");

                    LeitorBLL leiBll = new LeitorBLL(banco, usuario, senha);
                    if (leiBll.SelecionarLeitorPorId(int.Parse(txtIdLeitor.Text)) == null)
                        MessageBox.Show("Erro: O leitor com o ID informado não foi encontrado no banco de dados");
                }
                catch (Exception erro) { MessageBox.Show("Erro: " + erro.Message); }
                finally // Caso deu tudo certo
                {
                    emprestimo.IdLivro = int.Parse(txtIdLivro.Text);
                    emprestimo.IdLeitor = int.Parse(txtIdLeitor.Text);
                    emprestimo.DataEmprestimo = dtpDataEmprestimo.Value;
                    emprestimo.DataDevolucaoPrevista = dtpDataDevPrevista.Value;
                    emprestimo.DataDevolucaoEfetiva = new DateTime();

                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        List<Emprestimo> aux = bll.SelecionarListEmprestimos();

                        bool achouLivroJaEmprestado = false;
                        int contLivrosLeitor = 0;
                        for (int i = 0; i < aux.Count; i++)
                        {
                            if (aux[i].IdLivro == emprestimo.IdLivro)
                                achouLivroJaEmprestado = true; // Achamos esse mesmo livro ja emprestado

                            if (emprestimo.IdLeitor == aux[i].IdLeitor && aux[i].DataDevolucaoEfetiva != null) // Se o leitor que esta querendo o emprestimo for achado em outro emprestimo e se a data de devolucao desse emprestimo é null (a pessoa ainda esta com o livro)
                                contLivrosLeitor++; // Incrementamos a quantidade de emprestimos que essa pessoa tem
                        }

                        if (emprestimo.DataDevolucaoPrevista.CompareTo(emprestimo.DataEmprestimo) < 0) // Se a data de devolucao prevista for menor que a data de emprestimo
                            MessageBox.Show("Erro: Data de devolução prevista inválida!"); // Nao se pode fazer o emprestimo, pois a data é inválida
                        else if (achouLivroJaEmprestado) // Se esse livro ja esta emprestado nao se pode fazer o emprestimo
                            MessageBox.Show("Erro: Este livro já está emprestado! Volte a tentar mais tarde");
                        else if (contLivrosLeitor >= 5) // Se o leitor ja tem 5 ou mais emprestimos nao se pode fazer o emprestimo
                            MessageBox.Show("Erro: Este leitor já tem 5 livros emprestados, não pode mais fazer empréstimos!");
                        else
                        {
                            emprestimo.DataDevolucaoEfetiva = DateTime.MinValue;
                            bll.InserirEmprestimo(emprestimo);
                            MessageBox.Show("Empréstimo criado com sucesso!");
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro: " + erro.Message.ToString() + "\n" + erro.StackTrace);
                    }
                }
            }
            else
                MessageBox.Show("Erro: Dados de emprestimo inválidos!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Testamos se os valores nao sao vazios
            if (txtIdEmprestimo.Text != "" || txtIdLeitor.Text != "" || txtIdLivro.Text != "" || dtpDataDevPrevista.Value != null || dtpDataEmprestimo.Value != null)
            {
                Emprestimo emprestimo = new Emprestimo(int.Parse(txtIdEmprestimo.Text),
                                                    int.Parse(txtIdLeitor.Text),
                                                    int.Parse(txtIdLivro.Text),
                                                    dtpDataEmprestimo.Value,
                                                    dtpDataDevPrevista.Value,
                                                    new DateTime());
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    bll.AlterarEmprestimo(emprestimo);
                    MessageBox.Show("Empréstimo alterado com sucesso!");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
                MessageBox.Show("Erro: Dados de emprestimo inválidos!");
        }

        private void btnRegistarDevolucao_Click(object sender, EventArgs e)
        {
            if (txtIdDevolucao.Text != "")
            {
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    List<Emprestimo> aux = bll.SelecionarListEmprestimos();
                    Emprestimo emprestimo = null;
                    for (int i = 0; i < aux.Count; i++)
                    {
                        int j = aux[i].IdEmprestimo;
                        if (aux[i].IdEmprestimo == int.Parse(txtIdDevolucao.Text))
                        { 
                             emprestimo= new Emprestimo(aux[i].IdEmprestimo,
                                                   aux[i].IdLeitor,
                                                   aux[i].IdLivro,
                                                   aux[i].DataEmprestimo,
                                                   aux[i].DataDevolucaoPrevista,
                                                   dtpDataDevReal.Value);
                        }
                    }
                    bll.AlterarEmprestimo(emprestimo);
                    MessageBox.Show("Devolução feita com sucesso!");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
                MessageBox.Show("Erro: Dados de emprestimo inválidos!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdEmprestimo.Text != "")
            {
                Emprestimo emprestimo = new Emprestimo(int.Parse(txtIdEmprestimo.Text), 0, 0,
                                                   new DateTime(), new DateTime(), new DateTime());
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    bll.ExcluirEmprestimo(emprestimo);
                    MessageBox.Show("Exclusão feita com sucesso!");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
                MessageBox.Show("Erro: Dados de emprestimo inválidos!");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                dgvOperacoes.DataSource = bll.SelecionarListEmprestimos();
                tcOperacoes.SelectTab(tpLista);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        public void abrirPaginaEmprestimos() { tcOperacoes.SelectTab(tpEmprestimo); } // Abre a aba de emprestimos
        public void abrirPaginaDevolucoes() { tcOperacoes.SelectTab(tpDevolucao); } // Abre a aba de devolucoes

    }
}
