using System;
using System.Collections.Generic;
using System.Text;
using TesteWGlobal.Domain.Enums;

namespace TesteWGlobal.Domain.Models
{
    public class Cliente : Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public Status Ativo { get; set; }
    }
}
