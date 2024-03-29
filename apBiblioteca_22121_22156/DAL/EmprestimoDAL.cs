﻿/*
    PARTICIPANTES:
    1 - Beatriz Juliato Coutinho - RA: 22121
    2 - Éric Carvalho Figueira   - RA: 22156
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;


namespace DAL
{
    public class EmprestimoDAL
    {
        string _conexaoSQLServer = "";
        SqlConnection _conexao = null;

        public EmprestimoDAL(string banco, string usuario, string senha)
        {
            _conexaoSQLServer = $"Data Source=regulus.cotuca.unicamp.br;Initial Catalog={banco}; " +
                $"User id={usuario}; Password={senha}";
        }

        public DataTable SelectEmprestimos()
        {
            try
            {
                String sql = "SELECT idEmprestimo, idLivro, idLeitor, dataEmprestimo, dataDevolucaoPrevista, dataDevolucaoReal FROM bibEmprestimo";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Emprestimo> SelectListEmprestimos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conexaoSQLServer))
                {
                    using (SqlCommand command = new SqlCommand("Select * from bibEmprestimo", conn))
                    {
                        conn.Open();
                        List<Emprestimo> listaEmprestimos = new List<Emprestimo>();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Emprestimo emprestimo = new Emprestimo(
                                (int)dr["idEmprestimo"],
                                (int)dr["idLivro"],
                                (int)dr["idLeitor"],
                                (DateTime)dr["DataEmprestimo"],
                                (DateTime)dr["DataDevolucaoPrevista"],
                                (DateTime)dr["DataDevolucaoReal"]
                                );
                                listaEmprestimos.Add(emprestimo);
                            }
                        }
                        return listaEmprestimos;
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao acessar " + erro.Message);
            }
        }

        public void UpdateEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                String sql = "UPDATE bibEmprestimo " +
                    " SET idLivro = @idLivro, idLeitor = @idLeitor," +
                    " dataEmprestimo = @dataEmprestimo, " +
                    " dataDevolucaoPrevista = @dataDevolucaoPrevista, " +
                    " dataDevolucaoReal  = @dataDevolucaoReal " +
                    " WHERE idEmprestimo = @idEmprestimo";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", emprestimo.IdLivro);
                cmd.Parameters.AddWithValue("@idLeitor", emprestimo.IdLeitor);
                cmd.Parameters.AddWithValue("@dataEmprestimo", emprestimo.DataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucaoPrevista", emprestimo.DataDevolucaoPrevista);
                cmd.Parameters.AddWithValue("@dataDevolucaoReal", emprestimo.DataDevolucaoReal);
                cmd.Parameters.AddWithValue("@idEmprestimo", emprestimo.IdEmprestimo);
                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void DeleteEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                String sql = "DELETE FROM bibEmprestimo WHERE idEmprestimo = @idEmprestimo";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo", emprestimo.IdEmprestimo);
                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void InsertEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                String sql = "INSERT INTO bibEmprestimo (idLivro, idLeitor, dataEmprestimo, dataDevolucaoPrevista, dataDevolucaoReal) " +
                    " VALUES (@idLivro, @idLeitor, @dataEmprestimo, @dataDevolucaoPrevista, @dataDevolucaoReal)";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo", emprestimo.IdEmprestimo);
                cmd.Parameters.AddWithValue("@idLivro", emprestimo.IdLivro);
                cmd.Parameters.AddWithValue("@idLeitor", emprestimo.IdLeitor);
                cmd.Parameters.AddWithValue("@dataEmprestimo", emprestimo.DataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucaoPrevista", emprestimo.DataDevolucaoPrevista);
                cmd.Parameters.AddWithValue("@dataDevolucaoReal", "01/01/9999 08:30:52 AM");
                _conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public Emprestimo SelectEmprestimoByID(int id)
        {
            try
            {
                String sql = "SELECT * FROM bibEmprestimo WHERE idEmprestimo = @idEmprestimo";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo", id);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Emprestimo emprestimo = null;
                if (dr.Read())
                {
                    emprestimo = new Emprestimo(
                    (int)dr["idEmprestimo"],
                    (int)dr["idLivro"],
                    (int)dr["idLeitor"],
                    (DateTime)dr["dataEmprestimo"],
                    (DateTime)dr["dataDevolucaoPrevista"],
                    (DateTime)dr["dataDevolucaoReal"]
                    );
                }
                return emprestimo;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Emprestimo> SelectEmprestimosByIdLeitor(int id)
        {
            try
            {
                String sql = "SELECT * FROM bibEmprestimo WHERE idLeitor = @idLeitor";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", id);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<Emprestimo> aux = new List<Emprestimo>();
                while (dr.Read())
                {
                    Emprestimo emprestimo = new Emprestimo(
                    (int)dr["idEmprestimo"],
                    (int)dr["idLivro"],
                    (int)dr["idLeitor"],
                    (DateTime)dr["dataEmprestimo"],
                    (DateTime)dr["dataDevolucaoPrevista"],
                    (DateTime)dr["dataDevolucaoReal"]
                    );
                    aux.Add(emprestimo);
                }
                return aux;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Emprestimo> SelectEmprestimosByIdLivro(int id)
        {
            try
            {
                String sql = "SELECT * FROM bibEmprestimo WHERE idLivro = @idLivro";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", id);
                _conexao.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<Emprestimo> aux = new List<Emprestimo>();
                while (dr.Read())
                {
                    Emprestimo emprestimo = new Emprestimo(
                    (int)dr["idEmprestimo"],
                    (int)dr["idLivro"],
                    (int)dr["idLeitor"],
                    (DateTime)dr["dataEmprestimo"],
                    (DateTime)dr["dataDevolucaoPrevista"],
                    (DateTime)dr["dataDevolucaoReal"]
                    );
                    aux.Add(emprestimo);
                }
                return aux;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Emprestimo> SelectEmprestimosByIdLeitorIdLivro (int idLivro, int idLeitor)
        {
            try
            {
                String sql = "SELECT * FROM bibEmprestimo WHERE idLivro = @idLivro AND idLeitor = @idLeitor";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", idLivro);
                cmd.Parameters.AddWithValue("@idLeitor", idLeitor);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<Emprestimo> aux = new List<Emprestimo>();
                while (dr.Read())
                {
                    Emprestimo emprestimo = new Emprestimo(
                        (int)dr["idEmprestimo"],
                        (int)dr["idLivro"],
                        (int)dr["idLeitor"],
                        (DateTime)dr["dataEmprestimo"],
                        (DateTime)dr["dataDevolucaoPrevista"],
                        (DateTime)dr["dataDevolucaoReal"]
                        );
                    aux.Add(emprestimo);
                }
                return aux;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public bool VerificarEmprestimoLeitor(int id) // Verifica se o id do leitor passado esta em algum emprestimo
        {
            try
            {
                String sql = "SELECT * FROM bibEmprestimo WHERE idLeitor = @idLeitor";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", id);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read()) // Se conseguimos ler pelo menos 1 registro, significa que o leitor tem pelo menos 1 livro emprestado, nao precisamos criar uma lista para isso
                    return true;

                return false;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public bool VerificarEmprestimoLivro(int id) // Verifica se o id do livro passado esta em algum emprestimo
        {
            try
            {
                String sql = "SELECT * FROM bibEmprestimo WHERE idLivro = @idLivro";
                _conexao = new SqlConnection(_conexaoSQLServer);
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", id);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read()) // Se conseguimos ler pelo menos 1 registro, significa que o livro esta em pelo menos 1 emprestimo, nao precisamos criar uma lista para isso
                    return true;

                return false;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}