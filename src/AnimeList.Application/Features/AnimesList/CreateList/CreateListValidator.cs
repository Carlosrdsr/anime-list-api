using FluentValidation;

namespace AnimeList.Application.Features.AnimesList.CreateList;

public class CreateListValidator : AbstractValidator<CreateListCommand>
{
    public CreateListValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MinimumLength(100);

        RuleFor(x => x.Diretor)
            .NotEmpty()
            .MinimumLength(50);

        RuleFor(x => x.Resumo)
            .NotEmpty()
            .MinimumLength(500);
    }
}
