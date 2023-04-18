using BookStore.Models.Requests;
using FluentValidation;

namespace UniAPI.Validators;

public class AddAuthorRequestValidator : AbstractValidator<AddAuthorRequest>
{
    public AddAuthorRequestValidator()
    {
        RuleFor(n => n.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Bio)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Bio.Length)
            .GreaterThan(5).WithMessage("dai po dulgo pedal")
            .LessThan(15);
    }
}

