using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class LocacaoValidation : AbstractValidator<Locacao>
    {
        public LocacaoValidation()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11).WithMessage("O campo {PropertyName} precisa ter {Length} caracteres");
        }
    }
}