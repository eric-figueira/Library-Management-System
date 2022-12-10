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
    public partial class FrmRelatorio : Form
    {
        public string banco, usuario, senha;

        private const int PENALIDADE_POR_DIA_ATRASADO = 2;

        private void cbRelatorio_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvRelatorio.Rows.Clear();
            
            if (cbRelatorio.SelectedItem == "Livro")
            {

                /*
                   Ao selecionar livro:
                   Vamos, em um datagridview, mostrar as seguintes informacoes:
                       | IdLivro | CodLivro | IdEmprestimo (--) | Situacao (Emprestado ou Disponivel) | 
                   Por ser um relatorio, vamos mostrar todos os livros, independentemente de estarem ou nao em algum empresitmo
                */

                // Adicionando as colunas:
                dgvRelatorio.ColumnCount = 4;
                for (int i = 0; i < 4; i++) { dgvRelatorio.Columns[i].Width = 150; } // Setando o tamanho das colunas
                dgvRelatorio.Columns[0].HeaderCell.Value = "IdLivro";
                dgvRelatorio.Columns[1].HeaderCell.Value = "codigoLivro";
                dgvRelatorio.Columns[2].HeaderCell.Value = "IdEmprestimo";
                dgvRelatorio.Columns[3].HeaderCell.Value = "Situacao";

                try
                {
                    // Vamos chamar um FULL OUTER JOIN para facilitar o trabalho
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);

                    DataTable aux = bll.LivroOuterJoinEmprestimo();

                    // Percorreremos as linhas desse DataTable auxiliar e incluiremos no dgvRelatorio as informacoes de interesse
                    for (int i = 0; i < aux.Rows.Count; i++)
                    {
                        if (i != aux.Rows.Count - 1)
                            dgvRelatorio.Rows.Add();


                        dgvRelatorio[0, i].Value = aux.Rows[i][0]; // IdLivro
                        dgvRelatorio[1, i].Value = aux.Rows[i][1]; // codigoLivro

                        if (aux.Rows[i][4] is System.DBNull) // Nao existe emprestimo com aquele livro
                        {
                            dgvRelatorio[2, i].Value = "---"; // Nao ha id de emprestimo com aquele livro
                            dgvRelatorio[3, i].Value = "Disponível";
                        }
                        else 
                        {
                            dgvRelatorio[2, i].Value = aux.Rows[i][4]; // Colocamos o Id do emprestimo com aquele livro
                            dgvRelatorio[3, i].Value = "Emprestado"; 
                        }
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            } 
            else if (cbRelatorio.SelectedItem == "Leitor")
            {
                /*
                    Ao selecionar leitor:
                    Vamos ,no mesmo datagridview, mostrar as seguintes informacoes:
                        | IdLeitor | IdEmprestimo (--) | Situacao do Emprestimo (Pendente / Ativo / Entregue) | Dias atrasados (se houverem) | Penalidades
                    Por ser um relatorio, vamos mostrar todos os leitores, independentemente de estarem ou nao com algum emprestimo
                */

                // Adicionamos as colunas:
                dgvRelatorio.ColumnCount = 6;
                for (int i = 0; i < 6; i++) { dgvRelatorio.Columns[i].Width = 100; } // Setando o tamanho das colunas
                dgvRelatorio.Columns[0].HeaderCell.Value = "IdLeitor";
                dgvRelatorio.Columns[1].HeaderCell.Value = "IdEmprestimo";
                dgvRelatorio.Columns[2].HeaderCell.Value = "Situacao";
                dgvRelatorio.Columns[3].HeaderCell.Value = "Dias Atrasados";
                dgvRelatorio.Columns[4].HeaderCell.Value = "Penalidades";
                dgvRelatorio.Columns[5].HeaderCell.Value = "Data de Entrega";

                try
                {
                    // Vamos chamar um FULL OUTER JOIN para facilitar as coisas
                    LeitorBLL bll = new LeitorBLL(banco, usuario, senha);

                    DataTable aux = bll.LeitorOuterJoinEmprestimo();

                    // Percorreremos as linhas desse DataTable auxiliar e incluiremos no dgvRelatorio as informacoes de interesse
                    for (int i = 0; i < aux.Rows.Count; i++)
                    {
                        if (i != aux.Rows.Count - 1)
                            dgvRelatorio.Rows.Add();

                        dgvRelatorio[0, i].Value = aux.Rows[i][0];

                        if (aux.Rows[i][5] is System.DBNull) // Nao ha emprestimos para esse leitor pois Id Emprestimo eh nulo
                        {
                            // Obs: Esses indexes sao em relacao a tabela retornada pelo FULL OUTER JOIN
                            dgvRelatorio[1, i].Value = "---";
                            dgvRelatorio[2, i].Value = "---";
                            dgvRelatorio[3, i].Value = "---";
                            dgvRelatorio[4, i].Value = "---";
                            dgvRelatorio[5, i].Value = "---";
                        }
                        else
                        {
                            dgvRelatorio[1, i].Value = aux.Rows[i][5]; // Colocamos o Id do emprestimo daquele leitor

                            /*
                                Vamos testar o seguinte:
                                1 - Se o ano da data de entrega for igual a 9999, significa que esta é 'nula', ou seja, o emprestimo ainda nao
                                    foi devolvido e esta pendente ou ativo
                                        1.1 - Se a data atual (hoje) for menor ou igual que a data prevista da entrega, a situacao esta ativa, e nao ha
                                              dias atrasados ou penalidades
                                        1.2 - Se a data atual (hoje) for maior que a data prevista da entrega, a situacao esta pendente, e os dias atrasados
                                              sao dados pela diferenca da data atual com a data prevista da entrega
                                2 - Se o ano da data de entrega for menor que 9999, significa que o emprestimo ja foi devolvido, precisamos entao,
                                    definir a situacao como Entregue, e calcular se houve dias de atraso e caso haja, calcular a penalidade
                            */

                            if (((DateTime)aux.Rows[i][10]).Year == 9999) // 1
                            {              
                                if (DateTime.Today.CompareTo((DateTime) aux.Rows[i][9]) <= 0) // 1.1
                                {
                                    // Obs: Esses indexes sao em relacao a tabela retornada pelo FULL OUTER JOIN
                                    dgvRelatorio[2, i].Value = "Ativo";
                                    dgvRelatorio[3, i].Value = "---";
                                    dgvRelatorio[4, i].Value = "---";
                                    dgvRelatorio[5, i].Value = "---"; // Por enquanto nao ha data de entrega
                                }
                                else // 1.2
                                {
                                    dgvRelatorio[2, i].Value = "Pendente";

                                    int dias_atraso = DateTime.Today.Subtract((DateTime)aux.Rows[i][9]).Days;
                                    dgvRelatorio[3, i].Value = dias_atraso;
                                    dgvRelatorio[4, i].Value = dias_atraso * PENALIDADE_POR_DIA_ATRASADO;

                                    dgvRelatorio[5, i].Value = "---"; // Por enquanto nao ha data de entrega
                                }
                            }
                            else if (((DateTime)aux.Rows[i][10]).Year < 9999) // 2 
                            {
                                dgvRelatorio[2, i].Value = "Entregue";

                                // Calculando os dias de atraso entre a data de entrega (coluna de index 10) e a data prevista (coluna de index 9)
                                // Obs: Esses indexes sao em relacao a tabela retornada pelo FULL OUTER JOIN
                                int dias_atraso = ((DateTime)aux.Rows[i][10]).Subtract((DateTime)aux.Rows[i][9]).Days;
                                dgvRelatorio[3, i].Value = dias_atraso;
                                // Calculando a penalidade
                                dgvRelatorio[4, i].Value = dias_atraso * PENALIDADE_POR_DIA_ATRASADO;

                                dgvRelatorio[5, i].Value = aux.Rows[i][10]; // Colocando a data de entrega
                            }
                        }
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        public FrmRelatorio()
        {
            InitializeComponent();
        }
    }
}
