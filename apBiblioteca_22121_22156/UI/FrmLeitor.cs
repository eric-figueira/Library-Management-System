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
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Erro: Dados de leitor inválidos");
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
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Erro: Dados de leitor inválidos");
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
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
                }
            }
            else
                MessageBox.Show("Erro: Dados de leitor inválidos");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                LeitorBLL bll = new LeitorBLL(banco, usuario, senha); // Instanciamos um bll
                dgvLeitor.DataSource = bll.SelecionarListLeitores();  // Pegamos todos os leitores e os adicionamos como fonte de dados para o dgvLeitor
                tcLeitor.SelectTab(tpLista); // Vai para o tapPage que exibe a lista de leitores
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString()); // Caso haja algum erro, mostramos ao usuario
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
                MessageBox.Show("Erro: Dados de leitor inválidos");
        }

        public FrmLeitor()
        {
            InitializeComponent();
        }
    }
}
