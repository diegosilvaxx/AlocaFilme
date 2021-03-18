using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class FilmeValidation : AbstractValidator<Filme>
    {
        public FilmeValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}