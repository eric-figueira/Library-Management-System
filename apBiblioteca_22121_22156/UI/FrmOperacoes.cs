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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Emprestimo emprestimo = new Emprestimo(0,0,0, new DateTime(),new DateTime(), new DateTime()); //?
            emprestimo.IdEmprestimo = int.Parse(txtIdEmprestimo.Text);
            emprestimo.IdLeitor = int.Parse(txtIdLeitor.Text);
            emprestimo.IdLivro = int.Parse(txtIdLivro.Text);
            emprestimo.DataEmprestimo = dtpDataEmprestimo.Value;
            emprestimo.DataDevolucaoPrevista = dtpDataDevPrevista.Value;
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

                    if (emprestimo.IdLeitor == aux[i].IdLeitor) // Se o leitor que esta querendo o emprestimo for achado em outro emprestimo
                        contLivrosLeitor++; // Incrementamos a quantidade de emprestimos que essa pessoa tem
                }
                
                if (emprestimo.DataDevolucaoPrevista.CompareTo(emprestimo.DataEmprestimo) < 0) // Se a data de devolucao prevista for menor que a data de emprestimo
                    MessageBox.Show("Data de devolução prevista inválida!"); // Nao se pode fazer o emprestimo, pois a data é inválida
                else if (achouLivroJaEmprestado) // Se esse livro ja esta emprestado
                    MessageBox.Show("Este livro já está emprestado! Volte a tentar mais tarde"); // Nao se pode fazer o emprestimo
                else if (contLivrosLeitor >= 5) // Se o leitor ja tem 5 ou mais emprestimos
                    MessageBox.Show("Este leitor já tem 5 livros emprestados, não pode mais fazer empréstimos!"); // Nao se pode fazer o emprestimo
                else 
                    bll.InserirEmprestimo(emprestimo); // Caso contrario, esse emprestimo sera criado
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Emprestimo emprestimo = new Emprestimo(int.Parse(txtIdEmprestimo.Text),
                                                    int.Parse(txtIdLeitor.Text),
                                                    int.Parse(txtIdLivro.Text),
                                                    dtpDataEmprestimo.Value,
                                                    dtpDataDevPrevista.Value,
                                                    dtpDataDevReal.Value);
            try
            {
                EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                bll.AlterarEmprestimo(emprestimo);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }

        }

        private void btnRegistarDevolucao_Click(object sender, EventArgs e)
        {
            Emprestimo emprestimo = new Emprestimo(int.Parse(txtIdEmprestimo.Text),
                                                    int.Parse(txtIdLeitor.Text),
                                                    int.Parse(txtIdLivro.Text),
                                                    dtpDataEmprestimo.Value,
                                                    dtpDataDevPrevista.Value,
                                                    dtpDataDevReal.Value);

            try
            {
                EmprestimoBLL bll = new EmprestimoBLL (banco, usuario, senha);
                bll.AlterarEmprestimo (emprestimo);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Emprestimo emprestimo = new Emprestimo(int.Parse(txtIdEmprestimo.Text), 0, 0,
                                                   new DateTime(), new DateTime(), new DateTime()); // Nossa, boa bia
            try
            {
                EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                bll.ExcluirEmprestimo(emprestimo);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                dgvOperacoes.DataSource = bll.SelecionarListEmprestimos();
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
