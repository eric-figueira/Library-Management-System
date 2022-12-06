using System;
using System.Collections.Generic;
using System.Data;
using DAL;
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
            DataTable dt = new DataTable();
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                dt = dal.SelectLeitores();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable LeitorOuterJoinEmprestimo()
        {
            DataTable dt = new DataTable();
            try
            {
                dal = new LeitorDAL(banco, usuario, senha);
                dt = dal.LeitorOuterJoinEmprestimo();
            }
            catch (Exception erro)
            {
                throw erro;
            }

            return dt;
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
            try
            {
                EmprestimoDAL aux = new EmprestimoDAL(banco, usuario, senha);
                if (aux.VerificarEmprestimoUsuario(leitor.IdLeitor)) // Regra de negócio
                    // Esse usuario tem emprestimos pendentes, nao podemos exlui-lo ate que ele devolva o(s) livro(s)
                    throw new Exception("Usuário tem empréstimos pendentes. Para excluí-lo é necessário fazer a devolução dos livros emprestados");
                else
                {
                    dal = new DAL.LeitorDAL(banco, usuario, senha);
                    dal.DeleteLeitor(leitor);
                }
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

        public List<Leitor> SelecionarLeitorPorNome(string nome)
        {
            try
            {
                dal = new DAL.LeitorDAL(banco, usuario, senha);
                return dal.SelectLeitorByNome(nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
