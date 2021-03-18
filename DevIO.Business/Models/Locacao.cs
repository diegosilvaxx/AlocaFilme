using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Locacao : Entity
    {
        public string CPF { get; set; }
        public DateTime DataLocacao { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Guid? IdFilme { get; set; }

        [JsonIgnore]
        public virtual Filme Filme { get; set; }
    }
}