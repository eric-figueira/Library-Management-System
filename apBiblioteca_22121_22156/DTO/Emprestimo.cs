﻿using System;


namespace DTO
{
    public class Emprestimo
    {
        int idEmprestimo,
            idLivro,
            idLeitor;

        DateTime dataEmprestimo,
                 dataDevolucaoPrevista,
                 dataDevolucaoEfetiva;

        public int IdEmprestimo
        {
            get => idEmprestimo;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idEmprestimo = value;
            }
        }
        public int IdLivro
        {
            get => idLivro;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idLivro = value;
            }
        }
        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idLeitor = value;
            }
        }
        public DateTime DataDevolucaoEfetiva
        {
            get => dataDevolucaoEfetiva;
            set => dataDevolucaoEfetiva = value;
        }
        public DateTime DataDevolucaoPrevista
        {
            get => dataDevolucaoPrevista;
            set => dataDevolucaoPrevista = value;
        }
        public DateTime DataEmprestimo
        {
            get => dataEmprestimo;
            set => dataEmprestimo = value;
        }

        public Emprestimo(int idLivro, int idLeitor, int idEmprestimo, DateTime dataEmprestimo,
            DateTime dataPrevista, DateTime dataEfetiva)
        {
            IdLivro = idLivro;
            IdLeitor = idLeitor;
            IdEmprestimo = idEmprestimo;
            DataEmprestimo = dataEmprestimo;
            DataDevolucaoEfetiva = dataEfetiva;
            DataDevolucaoPrevista = dataPrevista;

        }
    }
}