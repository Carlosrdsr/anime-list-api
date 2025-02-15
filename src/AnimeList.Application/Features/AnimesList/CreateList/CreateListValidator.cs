using FluentValidation;

namespace AnimeList.Application.Features.AnimesList.CreateList;

public class CreateListValidator : AbstractValidator<CreateListCommand>
{
    public CreateListValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Diretor)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Resumo)
            .NotEmpty()
            .MaximumLength(500);
    }
}
