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

        public void InserirEmprestimo(Emprestimo emprestimo)
        {
            // As regras de negocio sao feitas aqui ou no evento do botao no formulario?
            // Por que excluir emprestimo existe?
            // Revisar o formulario principal e avaliar se os botoes la em cima vao continuar ou vao sair
            /*
                REGRA DE NEGÓCIO: • Não da pra criar um emprestimo de um livro que ja esta emprestado (1)
                                  • Não da pra criar um emprestimo se o leitor ja tem 5 livros (2)

            */
            /*
                (1) :: 1. Chamar o metodo SelecionarListEmprestimos
                       2. Percorrer a lista retornada
                       3. Se o objeto emprestimo da posicao atual tiver o idLivro como sendo o id do objeto emprestimo passado como parametro,
                            nao criamos o emprestimo e dizemos que o livro ja esta emprestado
            */
            /*
                (2) :: 1. Pegar o id do leitor do emprestimo passado como parametro e iniciar um contrador auxiliar
                       2. Chamar o metodo SelecionarListEmprestimos
                       3. Percorrer essa lista
                       4. Se o objeto emprestimo da posicao atual tiver o mesmo id do leitor pego anteriormente, incrementamos em 1 o contador
                       5. Se ao final do processo contador >= 5, mandamos uma mensagem de erro dizendo que esse usuario nao pode fazer esse emprestimo
            */
            try
            {
                dal = new DAL.EmprestimoDAL(bd, user, password);
                dal.InsertEmprestimo(emprestimo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void ExcluirEmprestimo(Emprestimo emprestimo) // Por que isso existe?
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
