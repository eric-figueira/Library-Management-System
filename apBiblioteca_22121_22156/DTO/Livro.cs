using System;


namespace DTO
{
    public class Livro
    {
        int idLivro;
        string codigoLivro,
               tituloLivro,
               autorLivro;


        public const int tamanhoCodigo = 10,
                         tamanhoTitulo = 50,
                         tamanhoAutor = 50;

        public int IdLivro
        {
            get => idLivro;
            set
            {
                if (value < 0) // testa se o id do livro é negativo
                    throw new Exception("Id negativo é inválido!");
                idLivro = value; // armazena o valor passado no atributo de destino
            }
        }
        public string CodigoLivro
        {
            get => codigoLivro;
            set
            {
                if (value.Length != 0)
                    value = value.Remove(tamanhoCodigo); // remove qualquer caracter além do tamanho máximo do campo
               
                value = value.PadLeft(tamanhoCodigo, '0'); // preenche codigo com zeros à esquerda até completar o tamanho mãximo 
                codigoLivro = value; // armazena o valor passado no atributo de destino
            }
        }
        public string TituloLivro
        {
            get => tituloLivro;
            set
            {
                if (value.Length != 0)
                    value = value.Remove(tamanhoTitulo);

                value = value.PadRight(tamanhoTitulo, ' ');
                tituloLivro = value; 
            }
        }
        public string AutorLivro
        {
            get { return autorLivro; }
            set
            {
                if (value.Length != 0)
                    value = value.Remove(tamanhoAutor);

                value = value.PadRight(tamanhoAutor, ' ');
                autorLivro = value;
            }
        }

        public Livro(int idLivro, string codLivro, string tituloLivro, string autorLivro)
        {
            IdLivro     = idLivro;
            CodigoLivro = codLivro;
            TituloLivro = tituloLivro;
            AutorLivro  = autorLivro;
        }
    }
}