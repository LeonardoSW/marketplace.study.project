using FluentValidation;
using Marketplace.Domain.Models.Input;

namespace Marketplace.Api.FluentValidation
{
    public class NewUserInputValidator : AbstractValidator<NewUserInputModel>
    {
        public NewUserInputValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty();
        }
    }
}
