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
    public partial class FrmLeitor : Form
    {
        public string banco, usuario, senha;

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtNomeLeitor.Text != "" || txtTelefoneLeitor.Text != "" || txtEmailLeitor.Text != "" || txtEnderecoLeitor.Text != "")
            {
                Leitor leitor = new Leitor(0, "", "", "", ""); // Insntaciamos um leitor "vazio"
                                                               // Pegamos os dados dos textboxes referentes ao leitor e nele inserimos esses dados
                leitor.NomeLeitor = txtNomeLeitor.Text;
                leitor.TelefoneLeitor = txtTelefoneLeitor.Text;
                leitor.EmailLeitor = txtEmailLeitor.Text;
                leitor.EnderecoLeitor = txtEnderecoLeitor.Text;
                try
                {
                    LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                    bll.IncluirLeitor(leitor); // E incluimos um novo leitor
                    MessageBox.Show("Inclusão feita com sucesso!");
                    Leitor aux = bll.SelecionarLeitorPorNome(leitor.NomeLeitor); // Instanciamos um leitor auxiliar e procuramos por nome
                    txtIdLeitor.Text = aux.IdLeitor.ToString(); // para conseguir colocar seu Id no textbox
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Preencha todos os campos corretamente!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNomeLeitor.Text != "" || txtTelefoneLeitor.Text != "" || txtEmailLeitor.Text != "" || txtEnderecoLeitor.Text != "")
            {
                // Instanciamos um novo leitor pegando os dados referentes a ele dos textboxes, esses valores serao utilizados para atualizar a versao ja existente
                Leitor leitor = new Leitor(int.Parse(txtIdLeitor.Text), txtNomeLeitor.Text, txtTelefoneLeitor.Text, txtEmailLeitor.Text, txtEnderecoLeitor.Text);
                try
                {
                    LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                    bll.AlterarLeitor(leitor); // Alteramos os dados de leitor
                    MessageBox.Show("Alteração feita com sucesso!");
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Preencha todos os campos corretamente para realizar as alterações!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdLeitor.Text != "")
            {
                Leitor leitor = new Leitor(Convert.ToInt32(txtIdLeitor.Text), "", "", "", ""); // Instanciamos um novo leitor "zerado", apenas com o Id, que sera usado na operacao de exclusao
                try
                {
                    LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                    bll.ExcluirLeitor(leitor); // Exlucimos o leitor. O id passado na instancia que sera usado, nao sendo necessario, portanto, passar todos os dados de leitor
                    MessageBox.Show("Exclusão feita com sucesso!");
                    LimparTela();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Digite o código do livro que deseja excluir!");
        }

        private void btnExibir_Click(object sender, EventArgs e) // Mesmo evento para o Enter do tpLista
        {
            try
            {
                LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                
                DataTable aux = bll.SelecionarLeitores();

                dgvLeitor.Rows.Clear(); // Limpamos as linhas do dgvLeitor para nao ficarem acumulando
                for (int i = 0; i < aux.Rows.Count; i++) // Percorremos as linha de aux
                {
                    if (i != aux.Rows.Count - 1) // Adicionamos uma linha ao final caso nao seja o ultimo registro
                        dgvLeitor.Rows.Add();

                    dgvLeitor[0, i].Value = aux.Rows[i][0]; // Na coluna 0 da linha i do dgvLeitor adicionamos o valor que esta em aux na linha i coluna 0 (Id Leitor)
                    dgvLeitor[1, i].Value = aux.Rows[i][1]; // Nome Leitor
                    dgvLeitor[2, i].Value = aux.Rows[i][2]; // Email Leitor
                    dgvLeitor[3, i].Value = aux.Rows[i][3]; // Telefone  Leitor
                    dgvLeitor[4, i].Value = aux.Rows[i][4]; // Endeco Leitor
                }
                tcLeitor.SelectTab(tpLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtIdLeitor.Text != "")
            {
                int id = Convert.ToInt32(txtIdLeitor.Text); // Pegamos o id para procurar o leitor
                Leitor leitor = null;
                try
                {
                    LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                    leitor = bll.SelecionarLeitorPorId(id); // Selecionamos o leitor a partir do id passado
                                                            // E adicionamos aos textboxes os dados correspondentes ao leitor
                    txtNomeLeitor.Text = leitor.NomeLeitor;
                    txtEmailLeitor.Text = leitor.EmailLeitor;
                    txtTelefoneLeitor.Text = leitor.TelefoneLeitor;
                    txtEnderecoLeitor.Text = leitor.EnderecoLeitor;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Digite o código do livro que deseja procurar!");
        }

        private void dgvLeitor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vamos pegar os dados das celulas da linha na qual o usuario clicou, redirecionar este para a aba de cadastro, e colocar
            // os dados referentes ao leitor nos textboxes
            txtIdLeitor.Text       = dgvLeitor.CurrentRow.Cells[0].Value.ToString(); // 0 -> IdLeitor
            txtNomeLeitor.Text     = dgvLeitor.CurrentRow.Cells[1].Value.ToString(); // 1 -> Nome Leitor
            txtEmailLeitor.Text    = dgvLeitor.CurrentRow.Cells[2].Value.ToString(); // 2 -> Email Leitor
            txtTelefoneLeitor.Text = dgvLeitor.CurrentRow.Cells[3].Value.ToString(); // 3 -> Telefone Leitor
            txtEnderecoLeitor.Text = dgvLeitor.CurrentRow.Cells[4].Value.ToString(); // 4 -> Endereco Leitor

            tcLeitor.SelectTab(tpCadastro);
        }

        public void LimparTela()
        {
            txtIdLeitor.Text       = "";
            txtNomeLeitor.Text     = "";
            txtTelefoneLeitor.Text = "";
            txtEmailLeitor.Text    = "";
            txtEnderecoLeitor.Text = "";
        }

        public FrmLeitor()
        {
            InitializeComponent();
        }
    }
}
