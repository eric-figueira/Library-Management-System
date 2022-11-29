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
        string banco, usuario, senha;
        

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
                EmprestimoBLL bll = new EmprestimoBLL(banco, usuario, senha); // As regras de negocio sao feitas aqui ou na classe BLL?
                bll.InserirEmprestimo(emprestimo); 
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
    }
}
