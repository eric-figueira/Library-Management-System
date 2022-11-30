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
                    Leitor aux = bll.SelecionarLeitorPorNome(leitor.NomeLeitor);
                    txtIdLeitor.Text = aux.IdLeitor.ToString();
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

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                
                DataTable teste = bll.SelecionarLeitores();

                //dgvLivro.DataSource = teste;
                for (int i = 0; i < teste.Rows.Count; i++)
                {
                    if (i != teste.Rows.Count - 1)
                        dgvLeitor.Rows.Add();

                    dgvLeitor[0, i].Value = teste.Rows[i][0]; // Id
                    dgvLeitor[1, i].Value = teste.Rows[i][1]; // Cod
                    dgvLeitor[2, i].Value = teste.Rows[i][2]; // Titulo
                    dgvLeitor[3, i].Value = teste.Rows[i][3]; // Autor   
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
