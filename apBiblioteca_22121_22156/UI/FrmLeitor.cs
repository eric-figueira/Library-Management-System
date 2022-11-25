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
            Leitor leitor = new Leitor(0,"","","","");
            leitor.NomeLeitor = txtNomeLeitor.Text;
            leitor.TelefoneLeitor = txtTelefoneLeitor.Text;
            leitor.EmailLeitor = txtEmailLeitor.Text;
            leitor.EnderecoLeitor = txtEnderecoLeitor.Text;
            try
            {
                LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                bll.IncluirLeitor(leitor);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Leitor leitor = new Leitor(int.Parse(txtIdLeitor.Text), txtNomeLeitor.Text, txtTelefoneLeitor.Text, txtEmailLeitor.Text, txtEnderecoLeitor.Text);
            try
            {
                LeitorBLL bll = new LeitorBLL(banco, usuario, senha);
                bll.AlterarLeitor(leitor);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnExibir_Click(object sender, EventArgs e)
        {

        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {

        }

        public FrmLeitor()
        {
            InitializeComponent();
        }
    }
}
