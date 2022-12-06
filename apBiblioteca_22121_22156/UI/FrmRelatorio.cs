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
            MessageBox.Show("YEAY, YOU SELECTED " + cbRelatorio.SelectedItem);

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

                        if (aux.Rows[i][4] == null) // Nao existe emprestimo com aquele livro
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
            else if (cbRelatorio.SelectedValue == "Leitor")
            {
                /*
                    Ao selecionar leitor:
                    Vamos ,no mesmo datagridview, mostrar as seguintes informacoes:
                        | IdLeitor | IdEmprestimo (--) | Situacao do Emprestimo (Pendente / Inexistente) | Dias atrasados (se houverem) | Penalidades
                    Por ser um relatorio, vamos mostrar todos os leitores, independentemente de estarem ou nao com algum emprestimo
                */

                // Adicionamos as colunas:
                dgvRelatorio.ColumnCount = 4;
                dgvRelatorio.Columns[0].HeaderCell.Value = "IdLeitor";
                dgvRelatorio.Columns[1].HeaderCell.Value = "IdEmprestimo";
                dgvRelatorio.Columns[2].HeaderCell.Value = "Situacao";
                dgvRelatorio.Columns[3].HeaderCell.Value = "Dias Atrasados";
                dgvRelatorio.Columns[4].HeaderCell.Value = "Penalidades";

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

                        if (aux.Rows[i][5] == null) // Nao ha emprestimos para esse leitor
                        {
                            dgvRelatorio[1, i].Value = "---";
                            dgvRelatorio[2, i].Value = "---";
                            dgvRelatorio[3, i].Value = "---";
                        }
                        else
                        {
                            dgvRelatorio[1, i].Value = aux.Rows[i][5]; // Colocamos o Id do emprestimo daquele leitor

                            // Testar se a data efetiva é nula, para que a situacao seja ativa

                            // Dias atrasados
                            DateTime hoje = new DateTime();
                            int dias_atraso = hoje.Subtract((DateTime) aux.Rows[i][9]).Days;
                            dgvRelatorio[3, i].Value = dias_atraso;

                            // Penalidades
                            dgvRelatorio[4, i].Value = dias_atraso * PENALIDADE_POR_DIA_ATRASADO;
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
