/*
    PARTICIPANTES:
    1 - Beatriz Juliato Coutinho - RA: 22121
    2 - Éric Carvalho Figueira   - RA: 22156
*/

using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using DTO;


namespace BLL
{
    public class LivroBLL
    {
        DAL.LivroDAL dal = null;
        public string bd, user, password;

        public LivroBLL(string banco, string usuario, string senha)
        {
            this.bd       = banco;
            this.user     = usuario;
            this.password = senha;
        }

        public DataTable SelecionarLivros() 
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LivroDAL(bd,user,password);
                tb = dal.SelectLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }
        public DataTable LivroOuterJoinEmprestimo()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.LivroDAL(bd, user, password);
                tb = dal.LivroOuterJoinEmprestimo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return tb;
        }

        public void IncluirLivro(Livro livro) 
        {
            try
            {
                dal = new DAL.LivroDAL(bd, user, password);
                dal.InsertLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AlterarLivro(Livro livro) 
        {
            try
            {
                dal = new DAL.LivroDAL(bd, user, password);
                dal.UpdateLivro(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ExcluirLivro(Livro livro)
        {
            try
            {
                EmprestimoDAL aux = new EmprestimoDAL(bd, user, password);
                if (aux.VerificarEmprestimoLivro(livro.IdLivro)) // Regra de negócio
                    // Esse livro esta em algum emprestimo, nao podemos exclui-lo ate que esse emprestimo seja devolvido
                    throw new Exception("Livro presente em empréstimo(s). Para excluí-lo é necessário que o empréstimo seja devolvido");
                else
                {
                    dal = new DAL.LivroDAL(bd, user, password);
                    dal.DeleteLivro(livro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Livro> SelecionarListLivros() 
        {
            try
            {
                dal = new DAL.LivroDAL(bd, user, password);
                return dal.SelectListLivros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Livro SelecionarLivroPorId(int id) 
        {
            try
            {
                dal = new DAL.LivroDAL(bd, user, password);
                return dal.SelectLivroByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Livro SelecionarLivroPorCodigo(string codigo)
        {
            try
            {
                dal = new DAL.LivroDAL(bd, user, password);
                return dal.SelectLivroByCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
