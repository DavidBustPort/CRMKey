using FluentValidation;

namespace Application.Features.Auth.Token
{
    public class TokenValidator : AbstractValidator<TokenCommand>
    {
        public TokenValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("UserId debe ser un número positivo");
        }
    }
}
