using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class GeneroValidation : AbstractValidator<Genero>
    {
        public GeneroValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}