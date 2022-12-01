using System;


namespace DTO
{
    public class Leitor
    {
        const int tamanhoNome = 50,
                    tamanhoTelefone = 20,
                    tamanhoEmail = 50,
                    tamanhoEndereco = 100;

        int idLeitor;
        string nomeLeitor,
               telefoneLeitor,
               emailLeitor,
               enderecoLeitor;

        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0) // testa se o id é negativo
                    throw new Exception("Id negativo é inválido");
                idLeitor = value; // armazena o valor passado no atributo de destino
            }
        }

        public String NomeLeitor
        {
            get => nomeLeitor;
            set
            {
                if (value.Length > tamanhoNome)
                    value = value.Remove(tamanhoNome); // remove qualquer caracter além do tamanho máximo do campo

                value = value.PadLeft(tamanhoNome, ' '); // preenche título com espaços à esquerda até completar o tamanho mãximo
                nomeLeitor = value; 
            }
        }

        public string TelefoneLeitor
        {
            get => telefoneLeitor;
            set
            {
                if (value.Length > tamanhoTelefone)
                    value = value.Remove(tamanhoTelefone); 

                value = value.PadLeft(tamanhoTelefone, ' '); 
                telefoneLeitor = value; 
            }
        }

        public string EmailLeitor
        {
            get => emailLeitor;
            set
            {
                if (value.Length > tamanhoEmail)
                    value = value.Remove(tamanhoEmail); 

                value = value.PadLeft(tamanhoEmail, ' '); 
                emailLeitor = value;
            }
        }

        public string EnderecoLeitor
        {
            get => enderecoLeitor;
            set
            {
                if (value.Length > tamanhoEndereco)
                    value = value.Remove(tamanhoEndereco);

                value = value.PadLeft(tamanhoEndereco, ' ');
                enderecoLeitor = value;
            }
        }

        public Leitor(int id, string nome, string telefone, string email, string endereco)
        {
            idLeitor       = id;
            nomeLeitor     = nome;
            telefoneLeitor = telefone;
            emailLeitor    = email;
            enderecoLeitor = endereco;
        }
    }
}