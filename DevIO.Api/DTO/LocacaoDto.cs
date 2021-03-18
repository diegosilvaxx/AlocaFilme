using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.DTO
{
    public class LocacaoDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

        [ScaffoldColumn(false)]
        private DateTime _dataLocacao;
        public DateTime DataLocacao
        {
            get => _dataLocacao;
            set => _dataLocacao = DateTime.Now;
        }
        public Guid IdFilme { get; set; }
    }
}
