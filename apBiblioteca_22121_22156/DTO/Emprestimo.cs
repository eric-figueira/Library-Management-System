using System;


namespace DTO
{
    public class Emprestimo
    {
        int idEmprestimo,
            idLivro,
            idLeitor;

        DateTime dataEmprestimo,
                 dataDevolucaoPrevista,
                 dataDevolucaoReal;

        public int IdEmprestimo
        {
            get => idEmprestimo;
            set
            {
                if (value < 0) // testa se o id do emprestimo é negativo
                    throw new Exception("Id negativo é inválido!");
                idEmprestimo = value; // armazena o valor passado no atributo de destino
            }
        }
        public int IdLivro
        {
            get => idLivro;
            set
            {
                if (value < 0) // testa se o id do livro é negativo
                    throw new Exception("Id negativo é inválido!");
                idLivro = value; 
            }
        }
        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0) // testa se o id do leitor é negativo
                    throw new Exception("Id negativo é inválido!");
                idLeitor = value; 
            }
        }
        public DateTime DataDevolucaoReal
        {
            get => dataDevolucaoReal;
            set => dataDevolucaoReal = value;
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

        public Emprestimo(int idEmprestimo, int idLivro, int idLeitor, DateTime dataEmprestimo,
            DateTime dataPrevista, DateTime dataDevReal)
        {
            IdLivro               = idLivro;
            IdLeitor              = idLeitor;
            IdEmprestimo          = idEmprestimo;
            DataEmprestimo        = dataEmprestimo;
            DataDevolucaoReal     = dataDevReal;
            DataDevolucaoPrevista = dataPrevista;

        }
    }
}