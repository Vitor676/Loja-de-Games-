using FluentValidation;
using lojadotorviz.Model;

namespace lojadotorviz.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(t => t.Tipo)
              .NotEmpty()
              .MinimumLength(5)
              .MaximumLength(100);
        }
    }
}
