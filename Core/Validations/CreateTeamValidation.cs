using Core.Dtos;
using FluentValidation;

namespace Core.Validations;

public class CreateTeamValidation : AbstractValidator<CreateTeamModel> 
{
    public CreateTeamValidation()
    {
        RuleFor(x => x.Logo)
            .NotEmpty()
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute));

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.Country)
            .NotEmpty()
            .Must(x => char.IsUpper(x[0])).WithMessage("The country must be uppercase letter");
    }
}