using FluentValidation;

namespace RegisterToDoctor.WebSell.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator() 
        {
            RuleFor(x => x)
            .NotNull()
            .NotEmpty()
            .WithMessage("Ошибка: Некорректно заполнено id необходимо передать идентификатор.");            
        }
    }
}
