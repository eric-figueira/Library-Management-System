using System;
using System.Collections.Generic;
using System.Data;
using DTO;

namespace BLL
{
    class LeitorBLL
    {
        public string banco, usuario, senha;

        DAL.LeitorDAL dal = null;
        public LeitorBLL(string banco, string usuario, string senha)
        {
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public DataTable SelecionarLeitores() 
        { 
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                tb = dal.SelectLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tb;
        }

        public void IncluirLeitor(Leitor leitor) 
        { 
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                dal.InsertLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarLeitor(Leitor leitor) 
        { 
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                dal.UpdateLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLeitor(Leitor leitor)
        {
            /*
                REGRA DE NEGÓCIO: Não da pra excluir um leitor se esta com livro emprestado

                Nao sei se da certo :: 1. Criar um metodo em EmprestimoDAL chamado VerificarEmprestimoUsuario (int idUsuario), que seleciona
                                            emprestimos com o id passado
                                       2. Se retornar True, significa que ha um leitor com emprestimo pendente, logo nao podemos exclui-lo
            */
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                dal.DeleteLeitor(leitor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Leitor> SelecionarListLeitores() 
        {
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                return dal.SelectListLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor SelecionarLeitorPorId(int id) 
        {
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                return dal.SelectLeitorByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
