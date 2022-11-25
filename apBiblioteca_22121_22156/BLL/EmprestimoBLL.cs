using System;
using System.Collections.Generic;
using System.Data;
using DTO;

namespace BLL
{
    public class EmprestimoBLL
    {
        DAL.EmprestimoDAL dal = null;
        public string bd, user, password;

        public EmprestimoBLL(string banco, string usuario, string senha)
        {
            this.bd       = banco;
            this.user     = usuario;
            this.password = senha;
        }

        public DataTable SelecionarEmprestimos()
        {
            DataTable tb = new DataTable();
            try
            {
                dal = new DAL.EmprestimoDAL(bd, user, password);
                tb = dal.SelectEmprestimos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tb;
        }

        public void AlterarEmprestimo(Emprestimo emprestimo)
        { 
            try
            {
                dal = new DAL.EmprestimoDAL(bd, user, password);
                dal.UpdateEmprestimo(emprestimo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                dal = new DAL.EmprestimoDAL(bd, user, password);
                dal.DeleteEmprestimo(emprestimo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> SelecionarListEmprestimos()
        {
            try
            {
                dal = new DAL.EmprestimoDAL(bd, user, password);
                return dal.SelectListEmprestimos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            try
            {
                dal = new DAL.EmprestimoDAL(bd, user, password);
                return dal.SelectEmprestimoByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
