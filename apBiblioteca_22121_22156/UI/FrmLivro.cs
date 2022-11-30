﻿using System;
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
    public partial class FrmLivro : Form
    {
        public string banco, usuario, senha;

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtCodLivro.Text != "" || txtTituloLivro.Text != "" || txtAutorLivro.Text != "")
            {
                Livro livro = new Livro(0, "", "", "");
                livro.CodigoLivro = txtCodLivro.Text;
                livro.TituloLivro = txtTituloLivro.Text;
                livro.AutorLivro = txtAutorLivro.Text;
                try
                {

                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    bll.IncluirLivro(livro);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Preencha todos os dados corretamente!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodLivro.Text != "" || txtTituloLivro.Text != "" || txtAutorLivro.Text != "")
            {
                Livro livro = new Livro(int.Parse(txtIdLivro.Text),
                                        txtCodLivro.Text,
                                        txtTituloLivro.Text,
                                        txtAutorLivro.Text);
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    bll.AlterarLivro(livro);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Preencha os campos corretamente para realizar as alterações");                  
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro(Convert.ToInt32(txtIdLivro.Text), "", "", "");
            try
            {
                LivroBLL bll = new LivroBLL(banco, usuario, senha);
                bll.ExcluirLivro(livro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtCodLivro.Text != "")
            {
                string codigo = txtCodLivro.Text;
                Livro livro = null;
                try
                {
                    LivroBLL bll = new LivroBLL(banco, usuario, senha);
                    livro = bll.SelecionarLivroPorCodigo(codigo);
                    txtCodLivro.Text = livro.CodigoLivro;
                    txtTituloLivro.Text = livro.TituloLivro;
                    txtAutorLivro.Text = livro.AutorLivro;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message.ToString());
                }
                txtIdLivro.ReadOnly = true;
            }
            else
                MessageBox.Show("Digite o código do livro que deseja procurar!");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                LivroBLL bll        = new LivroBLL(banco, usuario, senha);
                dgvLivro.DataSource = bll.SelecionarLivros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        public FrmLivro()
        {
            InitializeComponent();
        }
    }
}
