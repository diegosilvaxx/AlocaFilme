using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Filme : Entity
    {
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; }

        [JsonIgnore]
        public virtual ICollection<Locacao> Locacao { get; set; }

    }
}