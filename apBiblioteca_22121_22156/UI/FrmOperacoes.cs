using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            /*
                Podemos dividir a procura em 3 casos:
                1 - Quer procurar por IdLivro
                2 - Quer procurar por IdLeitor
                3 - Quer procurar por IdLeitor e por IdLivro
            */
            if (txtIdLivro.Text != "" && txtIdLeitor.Text == "") // 1
            {
                int idLivro = int.Parse(txtIdLivro.Text);
                List<Emprestimo> emprestimos = null;
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    emprestimos = bll.SelecionarEmprestimosPorIdLivro(idLivro);
                    if (emprestimos.Count == 0) // Não foi encontrado nenhum emprestimo com esse IdLivro
                        MessageBox.Show("Erro: Nenhum empréstimo com o IdLivro informado foi encontrado no banco de dados");
                    else // Estamos colocando os dados encontrados no dgvOperacoes independentemente se foram encontrados 1 ou 40 registros
                    {
                        tcOperacoes.SelectTab(tpLista);
                        fill_dgvEmprestimo_with_full_data(false, emprestimos); // Encontramos 1 ou mais emprestimos com o Idlivro passado
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
            else if (txtIdLivro.Text == "" && txtIdLeitor.Text != "") // 2
            {
                int idLeitor = int.Parse(txtIdLeitor.Text);
                List<Emprestimo> emprestimos = null;
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    emprestimos = bll.SelecionarEmprestimosPorIdLeitor(idLeitor);
                    if (emprestimos.Count == 0) // Não foi encontrado nenhum emprestimo com esse IdLeitor
                        MessageBox.Show("Erro: Nenhum empréstimo com o IdLeitor informado foi encontrado no banco de dados");
                    else
                    {
                        tcOperacoes.SelectTab(tpLista);
                        fill_dgvEmprestimo_with_full_data(false, emprestimos);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
            else // 3
            {
                int idLivro = int.Parse(txtIdLivro.Text);
                int idLeitor = int.Parse(txtIdLeitor.Text);
                List<Emprestimo> emprestimos = null;
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    emprestimos = bll.SelecionarEmprestimosPorIdLivroIdLeitor(idLivro, idLeitor);
                    if (emprestimos.Count == 0) // Não foi encontrado nenhum emprestimo com esse IdLeitor
                        MessageBox.Show("Erro: Nenhum empréstimo com o IdLivro e IdLeitor informados foi encontrado no banco de dados");
                    else
                    {
                        tcOperacoes.SelectTab(tpLista);
                        fill_dgvEmprestimo_with_full_data(false, emprestimos);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
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
                    emprestimo.DataDevolucaoReal = new DateTime();

                    try
                    {
                        EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                        List<Emprestimo> aux = bll.SelecionarListEmprestimos();

                        int contLivrosLeitor = 0;
                        for (int i = 0; i < aux.Count; i++)
                        {
                            if (emprestimo.IdLeitor == aux[i].IdLeitor && aux[i].DataDevolucaoReal != null) // Se o leitor que esta querendo o emprestimo for achado em outro emprestimo e se a data de devolucao desse emprestimo é null (a pessoa ainda esta com o livro)
                                contLivrosLeitor++; // Incrementamos a quantidade de emprestimos que essa pessoa tem
                        }

                        if (emprestimo.DataDevolucaoPrevista.CompareTo(emprestimo.DataEmprestimo) < 0) // Se a data de devolucao prevista for menor que a data de emprestimo
                            MessageBox.Show("Erro: Data de devolução prevista inválida!"); // Nao se pode fazer o emprestimo, pois a data é inválida
                        else if (contLivrosLeitor >= 5) // Se o leitor ja tem 5 ou mais emprestimos nao se pode fazer o emprestimo
                            MessageBox.Show("Erro: Este leitor já tem 5 livros emprestados, não pode mais fazer empréstimos!");
                        else
                        {
                            emprestimo.DataDevolucaoReal = DateTime.MaxValue;
                            bll.InserirEmprestimo(emprestimo);
                            MessageBox.Show("Empréstimo criado com sucesso!");
                            /*
                                Como diferentes emprestimos podem ter o mesmo livro emprestado, precisamos de uma lista que tem
                                esses emprestimos com esse livro, e como no sql, ao inserir um novo registro em uma tabela, este vai
                                para o final da mesma, selecionamos o ultimo registro da lista (aux.Count - 1) 
                            */
                            List<Emprestimo> auxiliar = bll.SelecionarEmprestimosPorIdLivro(emprestimo.IdLivro);
                            txtIdEmprestimo.Text = auxiliar[auxiliar.Count - 1].IdEmprestimo.ToString();
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
                                                    int.Parse(txtIdLivro.Text),
                                                    int.Parse(txtIdLeitor.Text),
                                                    dtpDataEmprestimo.Value,
                                                    dtpDataDevPrevista.Value,
                                                    DateTime.MaxValue);
                try
                {
                    EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha);
                    bll.AlterarEmprestimo(emprestimo);
                    MessageBox.Show("Alteração feita com sucesso!");
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
            Boolean emprestimoExistente = false;

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

                            MessageBox.Show("Devolução feita com sucesso!");
                            emprestimoExistente = true;
                        }
                    }
                    if (emprestimoExistente == false)  // se o emprestimo que o usuário deseja registrar a devolução não existir, uma mensagem será exibida
                        MessageBox.Show("Empréstimo inexistente");
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
                    // Limpando a tela
                    txtIdDevolucao.Text  = "";
                    txtIdEmprestimo.Text = "";
                    txtIdLeitor.Text     = "";
                    txtIdLivro.Text      = "";
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

        private void tpLista_Enter(object sender, EventArgs e)
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

                    dgvOperacoes[0, i].Value = emprestimos[i].IdEmprestimo; // Id Emprestimo
                    dgvOperacoes[1, i].Value = emprestimos[i].IdLivro; // Id Livro
                    dgvOperacoes[2, i].Value = emprestimos[i].IdLeitor; // Id Leitor
                    dgvOperacoes[3, i].Value = emprestimos[i].DataEmprestimo; // Data do emprestimo
                    dgvOperacoes[4, i].Value = emprestimos[i].DataDevolucaoPrevista; // Data devolucao prevista
                    dgvOperacoes[5, i].Value = emprestimos[i].DataDevolucaoReal; // Data devolucao real
                }
            }
        }

        private void dgvOperacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vamos pegar os dados das celulas da linha na qual o usuario clicou, redirecionar este para a aba de emprestimos, e colocar
            // os dados referentes ao emprestimo nos textboxes (e tambem na aba de devolucao)
            txtIdEmprestimo.Text = dgvOperacoes.CurrentRow.Cells[0].Value.ToString();
            txtIdDevolucao.Text  = dgvOperacoes.CurrentRow.Cells[0].Value.ToString();
            txtIdLivro.Text      = dgvOperacoes.CurrentRow.Cells[1].Value.ToString();
            txtIdLeitor.Text     = dgvOperacoes.CurrentRow.Cells[2].Value.ToString();
            dtpDataEmprestimo.Value  = (DateTime) dgvOperacoes.CurrentRow.Cells[3].Value;
            dtpDataDevPrevista.Value = (DateTime) dgvOperacoes.CurrentRow.Cells[4].Value;

            
            if (dgvOperacoes.CurrentRow.Cells[5].Value == "---" || ((DateTime)dgvOperacoes.CurrentRow.Cells[5].Value).Year == 9999)
            {
                dtpDataDevReal.Value = DateTime.Today;
                lbDevolucaoObs.Visible = true;
            }
            else {
                dtpDataDevReal.Value = (DateTime) dgvOperacoes.CurrentRow.Cells[5].Value;
                lbDevolucaoObs.Visible = false;
            }

            tcOperacoes.SelectTab(tpEmprestimo);
        }

        public void abrirPaginaEmprestimos() { tcOperacoes.SelectTab(tpEmprestimo); } // Abre a aba de emprestimos
        public void abrirPaginaDevolucoes() { tcOperacoes.SelectTab(tpDevolucao); } // Abre a aba de devolucoes

    }
}
