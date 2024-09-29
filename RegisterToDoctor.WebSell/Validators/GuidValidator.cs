using FluentValidation;

namespace RegisterToDoctor.WebSell.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator() 
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Ошибка: id не может быть null.")
                .NotEmpty()
                .WithMessage("Ошибка: Некорректно заполнено id необходимо передать идентификатор.");
        }
    }
}