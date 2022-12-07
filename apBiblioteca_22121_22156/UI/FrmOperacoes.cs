﻿using BLL;
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
            // verificar se o idLivro ou idLeitor pelo qual vai procurar existe
            if (txtIdLeitor.Text != "")
            {
                int idLeitor = int.Parse(txtIdLeitor.Text);
                Emprestimo emprestimo = null;
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    emprestimo = bll.SelecionarEmprestimoPorIdLeitor(idLeitor);
                    txtIdEmprestimo.Text = emprestimo.IdEmprestimo + "";
                    txtIdLivro.Text = emprestimo.IdLivro + "";
                    dtpDataEmprestimo.Value = emprestimo.DataEmprestimo;
                    dtpDataDevPrevista.Value = emprestimo.DataDevolucaoPrevista;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else if (txtIdLeitor.Text == "" && txtIdLivro.Text != "")
            {
                int idLivro = int.Parse(txtIdLivro.Text);
                Emprestimo emprestimo = null;
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    emprestimo = bll.SelecionarEmprestimoPorIdLivro(idLivro);
                    txtIdEmprestimo.Text = emprestimo.IdEmprestimo + "";
                    txtIdLeitor.Text = emprestimo.IdLeitor + "";
                    dtpDataEmprestimo.Value = emprestimo.DataEmprestimo;
                    dtpDataDevPrevista.Value = emprestimo.DataDevolucaoPrevista;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
                MessageBox.Show("Erro: Dados de emprestimo inválidos!");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // Testamos se os valores nao sao vazios
            if (txtIdLeitor.Text != "" || txtIdLivro.Text != "" || dtpDataDevPrevista.Value != null || dtpDataEmprestimo.Value != null)
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
                            Emprestimo auxiliar = bll.SelecionarEmprestimoPorIdLivro(emprestimo.IdLivro);
                            txtIdEmprestimo.Text = auxiliar.IdEmprestimo.ToString();
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
                    for (int i = 0; i < aux.Count; i++)
                    {
                        if (aux[i].IdEmprestimo == int.Parse(txtIdDevolucao.Text))
                        { 
                             Emprestimo emprestimo = new Emprestimo(aux[i].IdEmprestimo,
                                                   aux[i].IdLivro,
                                                   aux[i].IdLeitor,
                                                   aux[i].DataEmprestimo,
                                                   aux[i].DataDevolucaoPrevista, 
                                                   dtpDataDevReal.Value);

                            bll.AlterarEmprestimo(emprestimo);
                        }
                    }
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
                fill_dgvEmprestimo_with_full_data(true, null);
                tcOperacoes.SelectTab(tpLista);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        private void tcOperacoes_Enter(object sender, EventArgs e)
        {
            fill_dgvEmprestimo_with_full_data(true, null);
        }

        private void fill_dgvEmprestimo_with_full_data(bool complete_with_full_data, List<Emprestimo> emprestimos)
        {
            /*
                Esse método é chamado nas seguintes situações:
                1. Quando entramos na tpLista, chamamos esse método para que ele complete o dgvEmprestimo com todos os dados do banco de dados
                   (complete_with_full_data = true)
                2. Quando clicamos no botão Exibir, chamamos esse método pelo mesmo motivo anterior, com a diferença que no evento click 
                   desse botão, redirecionamos o usuário para a tpLista (complete_with_full_data = true)
                3. Quando, ao procurar por idLivro ou idLeitor, tem-se mais de 1 registro, preenchemos o dgvOperacoes apenas com os dados do emprestimo
                   com aquele leitor ou com aquele livro (complete_with_full_data = false). Esses registros estão na lista passada 
                   por parâmetro e obtida no próprio evento do botão Procurar
            */
            if (complete_with_full_data)
            {
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);

                    DataTable aux = bll.SelecionarEmprestimos();

                    dgvOperacoes.Rows.Clear(); // Limpamos as linhas do dgvLeitor para nao ficarem acumulando
                    for (int i = 0; i < aux.Rows.Count; i++) // Percorremos as linha de aux
                    {
                        if (i != aux.Rows.Count - 1) // Adicionamos uma linha ao final caso nao seja o ultimo registro
                            dgvOperacoes.Rows.Add();

                        dgvOperacoes[0, i].Value = aux.Rows[i][0]; // Id Emprestimo
                        dgvOperacoes[1, i].Value = aux.Rows[i][1]; // Id Livro
                        dgvOperacoes[2, i].Value = aux.Rows[i][2]; // Id Leitor
                        dgvOperacoes[3, i].Value = aux.Rows[i][3]; // Data do emprestimo
                        dgvOperacoes[4, i].Value = aux.Rows[i][4]; // Data devolucao prevista
                        if (((DateTime)aux.Rows[i][5]).Year == 9999) // Para devolucao real, verificamos se o ano é 9999 (data 'nula'), se for, colocamos riscos ao inves de uma data nao existente
                            dgvOperacoes[5, i].Value = "---";
                        else
                            dgvOperacoes[5, i].Value = aux.Rows[i][5];
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
            }
            else
            {
                dgvOperacoes.Rows.Clear(); // Limpamos as linhas do dgvLeitor para nao ficarem acumulando
                for (int i = 0; i < emprestimos.Count; i++) // Percorremos as linha de aux
                {
                    if (i != emprestimos.Count - 1) // Adicionamos uma linha ao final caso nao seja o ultimo registro
                        dgvOperacoes.Rows.Add();

                    dgvOperacoes[0, i].Value = emprestimos[i]; // Id Emprestimo
                    dgvOperacoes[1, i].Value = emprestimos[i]; // Id Livro
                    dgvOperacoes[2, i].Value = emprestimos[i]; // Id Leitor
                    dgvOperacoes[3, i].Value = emprestimos[i]; // Data do emprestimo
                    dgvOperacoes[4, i].Value = emprestimos[i]; // Data devolucao prevista
                    dgvOperacoes[5, i].Value = emprestimos[i]; // Data devolucao real
                }
            }
        }

        public void abrirPaginaEmprestimos() { tcOperacoes.SelectTab(tpEmprestimo); } // Abre a aba de emprestimos
        public void abrirPaginaDevolucoes() { tcOperacoes.SelectTab(tpDevolucao); } // Abre a aba de devolucoes

    }
}
