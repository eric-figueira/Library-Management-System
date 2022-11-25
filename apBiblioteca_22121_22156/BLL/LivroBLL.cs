using System;
using System.Collections.Generic;
using System.Data;
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
                dal = new DAL.LivroDAL(bd, user, password);
                dal.DeleteLivro(livro);
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
