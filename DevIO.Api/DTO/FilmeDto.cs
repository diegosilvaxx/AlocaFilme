using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class FilmeDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid GeneroId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        private DateTime _dataCadastro;
        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => _dataCadastro = DateTime.Now;
        }

        public bool Ativo { get; set; }

    }
}
