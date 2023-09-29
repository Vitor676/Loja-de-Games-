using FluentValidation;
using lojadotorviz.Model;

namespace lojadotorviz.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(n => n.Nome)
              .NotEmpty()
              .MinimumLength(5)
              .MaximumLength(80);

            RuleFor(d => d.Descricao)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1000);

            RuleFor(c => c.Console)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);

            RuleFor(dl => dl.DataLancamento)
                .NotEmpty();


        }
    }
}
