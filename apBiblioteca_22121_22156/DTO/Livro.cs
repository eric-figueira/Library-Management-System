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
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idLivro = value; // armazena o valor passado no atributo de destino
            }
        }
        public string CodigoLivro
        {
            get => codigoLivro;
            set
            {
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
                value = value.Remove(tamanhoTitulo); // remove qualquer caracter além do tamanho máximo do campo
                value = value.PadRight(tamanhoTitulo, ' '); // preenche título com espaços à direita até completar o tamanho mãximo
                tituloLivro = value; // armazena o valor passado no atributo de destino
            }
        }
        public string AutorLivro
        {
            get { return autorLivro; }
            set
            {

                value = value.Remove(tamanhoAutor); // remove qualquer caracter além do tamanho máximo do campo
                value = value.PadRight(tamanhoAutor, ' '); // preenche título com espaços à direita até completar o tamanho mãximo
                autorLivro = value; // armazena o valor passado no atributo de destino
            }
        }

        public Livro(int idLivro, string codLivro, string tituloLivro, string autorLivro)
        {
            IdLivro = idLivro;
            CodigoLivro = codLivro;
            TituloLivro = tituloLivro;
            AutorLivro = autorLivro;
        }
    }
}