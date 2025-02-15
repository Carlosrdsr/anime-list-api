using FluentValidation;

namespace AnimeList.Application.Features.AnimesList.CreateList;

public class CreateListCommandValidator : AbstractValidator<CreateListCommand>
{
    public CreateListCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(100);

        RuleFor(x => x.Diretor)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(50);

        RuleFor(x => x.Resumo)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(500);
    }
}
