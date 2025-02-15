using FluentValidation;

namespace AnimeList.Application.Features.AnimesList.UpdateList;

class UpdateListCommandValidator : AbstractValidator<UpdateListCommand>
{
    public UpdateListCommandValidator()
    {
        RuleFor(x => x.Id)
                .NotEmpty();

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
