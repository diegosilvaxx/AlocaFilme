using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Genero : Entity
    {
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}