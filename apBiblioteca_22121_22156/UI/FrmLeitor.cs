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
                    List<Leitor> aux = bll.SelecionarLeitorPorNome(leitor.NomeLeitor); // Instanciamos um leitor auxiliar e procuramos por nome

                    /*
                        Como SelecionarLeitorPorNome retorna uma lista de leitores com aquele nome, precisamos verificar algumas coisas:
                        1. Se temos apenas 1 leitor com o nome inserido, colocamos seu Id no textbox (caso em que há apenas aquela pessoa com aquele nome)
                        
                        2. Se por outro lado, aux tiver mais de 1 registro, significa que o nome é comum (João Silva, Maria Silva, por exemplo), com isso,
                            pelo fato de o banco de dados registrar em ordem de insercao, sem fazer ordenacao, o ultimo registro é o que acabamos de inserir,
                            isto é, o ultimo da lista, e pegamos, portanto, seu Id e o mostramos no textbox
                    */
                    if (aux.Count == 1)
                        txtIdLeitor.Text = aux[0].IdLeitor.ToString();
                    else
                        txtIdLeitor.Text = aux[aux.Count - 1].IdLeitor.ToString();

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
                    // Limpamos a tela
                    txtIdLeitor.Text = "";
                    txtNomeLeitor.Text = "";
                    txtTelefoneLeitor.Text = "";
                    txtEmailLeitor.Text = "";
                    txtEnderecoLeitor.Text = "";
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Digite o código do livro que deseja excluir!");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            fill_dgvLeitor_with_data(true, null); // Não precisamos passar a lista aqui, pois isso se dará no próprio método
            tcLeitor.SelectTab(tpLista);
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtNomeLeitor.Text != "")
            {
                string nome = txtNomeLeitor.Text; // Pegamos o nome para procurar o leitor
                List<Leitor> leitores = null;
                try
                {
                    LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                    leitores = bll.SelecionarLeitorPorNome(nome); // Selecionamos o(s) leitor(es) a partir do nome passado

                    if (leitores.Count == 0)
                        MessageBox.Show("Erro: Nenhum leitor com esse nome foi achado no banco de dados");
                    else if (leitores.Count == 1) // Se acharmos apenas um leitor com esse nome, inserimos seus dados nos textboxes 
                    {
                        txtIdLeitor.Text       = leitores[0].IdLeitor.ToString();
                        txtNomeLeitor.Text     = leitores[0].NomeLeitor;
                        txtEmailLeitor.Text    = leitores[0].EmailLeitor;
                        txtTelefoneLeitor.Text = leitores[0].TelefoneLeitor;
                        txtEnderecoLeitor.Text = leitores[0].EnderecoLeitor;
                    }
                    else // Vamos adicionar os dados dos leitores no dgvLeitor
                    {
                        // Precisamos redirecionar primeiro para depois preencher o dgvLeitor, caso contrario, os dados do evento Enter da tpLista vao sobrescrever os leitores adicionados com o nome procurado
                        tcLeitor.SelectTab(tpLista); // Redirecionamos o usuario para a tpLista
                        fill_dgvLeitor_with_data(false, leitores); //Precisamos passar a lista aqui
                    }  
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Digite nome do leitor que deseja procurar!");
        }

        private void dgvLeitor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vamos pegar os dados das celulas da linha na qual o usuario clicou, redirecionar este para a aba de cadastro, e colocar
            // os dados referentes ao leitor nos textboxes
            txtIdLeitor.Text       = dgvLeitor.CurrentRow.Cells[0].Value.ToString(); // 0 -> Id Leitor
            txtNomeLeitor.Text     = dgvLeitor.CurrentRow.Cells[1].Value.ToString(); // 1 -> Nome Leitor
            txtEmailLeitor.Text    = dgvLeitor.CurrentRow.Cells[2].Value.ToString(); // 2 -> Email Leitor
            txtTelefoneLeitor.Text = dgvLeitor.CurrentRow.Cells[3].Value.ToString(); // 3 -> Telefone Leitor
            txtEnderecoLeitor.Text = dgvLeitor.CurrentRow.Cells[4].Value.ToString(); // 4 -> Endereco Leitor

            tcLeitor.SelectTab(tpCadastro);
        }

        private void tpLista_Enter(object sender, EventArgs e)
        {
            fill_dgvLeitor_with_data(true, null); // Não precisamos passar a lista aqui, pois isso se dará no próprio método
        }

        private void fill_dgvLeitor_with_data (bool complete_with_full_data, List<Leitor> leitores)
        {
            /*
                Esse método é chamado nas seguintes situações:
                1. Quando entramos na tpLista, chamamos esse método para que ele complete o dgvLeitor com todos os dados do banco de dados
                   (complete_with_full_data = true)
                2. Quando clicamos no botão Exibir, chamamos esse método pelo mesmo motivo anterior, com a diferença que no evento click 
                   desse botão, redirecionamos o usuário para a tpLista (complete_with_full_data = true)
                3. Quando, ao procurar por nome, tem-se mais de 1 leitor, preenchemos o dgvLeitor apenas com os dados dos leitores com 
                   a cadeia de caracteres desejada em seus nomes (complete_with_full_data = false). Esses leitores estão na lista passada 
                   por parâmetro e obtida no próprio evento do botão Procurar
            */
            if (complete_with_full_data)
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
                        dgvLeitor[2, i].Value = aux.Rows[i][2]; // Telefone Leitor
                        dgvLeitor[3, i].Value = aux.Rows[i][3]; // Email  Leitor
                        dgvLeitor[4, i].Value = aux.Rows[i][4]; // Endereco Leitor
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
            {
                dgvLeitor.Rows.Clear(); // Limpamos as linhas do dgvLeitor para nao ficarem acumulando
                for (int i = 0; i < leitores.Count; i++) // Percorremos a lista de leitores que tem esse nome
                {
                    if (i != leitores.Count - 1) // Adicionamos uma linha ao final caso nao seja o ultimo registro
                        dgvLeitor.Rows.Add();

                    dgvLeitor[0, i].Value = leitores[i].IdLeitor; // Na coluna 0 da linha i do dgvLeitor adicionamos o valor que esta em aux na linha i coluna 0 (Id Leitor)
                    dgvLeitor[1, i].Value = leitores[i].NomeLeitor; // Nome Leitor
                    dgvLeitor[2, i].Value = leitores[i].TelefoneLeitor; // Telefone Leitor
                    dgvLeitor[3, i].Value = leitores[i].EmailLeitor; // Email Leitor
                    dgvLeitor[4, i].Value = leitores[i].EnderecoLeitor; // Endereco Leitor
                }
            }
        }

        public FrmLeitor()
        {
            InitializeComponent();
        }
    }
}
