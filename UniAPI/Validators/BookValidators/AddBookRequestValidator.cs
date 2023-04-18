using BookStore.Models.Requests.BookRequests;
using FluentValidation;

namespace UniAPI.Validators;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    public AddBookRequestValidator()
    {
        RuleFor(n => n.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(20);

        RuleFor(r => r.ReleaseDate)
            .NotEmpty()
            .NotNull();
    }
}

