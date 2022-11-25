﻿using System;


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
                if (value < 0)
                    throw new Exception("Id negativo é inválido");
                idLeitor = value;
            }
        }

        public String NomeLeitor
        {
            get => nomeLeitor;
            set
            {
                value = value.Remove(tamanhoNome);
                value = value.PadLeft(tamanhoNome, ' ');
                nomeLeitor = value;
            }
        }

        public string TelefoneLeitor
        {
            get => telefoneLeitor;
            set
            {
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
                value = value.Remove(tamanhoEndereco);
                value = value.PadLeft(tamanhoEndereco, ' ');
                enderecoLeitor = value;
            }
        }

        public Leitor(int id, string nome, string telefone, string email, string endereco)
        {
            idLeitor = id;
            nomeLeitor = nome;
            telefoneLeitor = telefone;
            emailLeitor = email;
            enderecoLeitor = endereco;
        }
    }
}