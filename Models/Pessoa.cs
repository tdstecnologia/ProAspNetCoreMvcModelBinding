﻿using ProAspNetCoreMvcModelBinding.Dominio;
using System;

namespace ProAspNetCoreMvcModelBinding.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco EnderecoCasa { get; set; }
        public bool Aprovado { get; set; }
        public Permissao Permissao { get; set; }
    }
}
