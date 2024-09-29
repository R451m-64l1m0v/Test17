using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces;
using RegisterToDoctor.WebSell.Сonstants;

namespace RegisterToDoctor.WebSell.Validators
{
    public class UserEntityValidator : AbstractValidator<IPerson>
    {
        public UserEntityValidator()
        {
            RuleFor(person => person.FirstName)
                .NotEmpty()
                .WithMessage("Необходимо указать Имя.")
                .MinimumLength(ConstansForValidators.MinimumFIOLength)
                .WithMessage("Имя не может быть меньше 2 символов.")
                .MaximumLength(ConstansForValidators.MaximumFIOLength)
                .WithMessage("Имя не может быть больше 50 символов.");

            RuleFor(person => person.LastName)
                .NotEmpty()
                .WithMessage("Необходимо указать Фамилия.")
                .MinimumLength(ConstansForValidators.MinimumFIOLength)
                .WithMessage("Имя не может быть меньше 2 символов.")
                .MaximumLength(ConstansForValidators.MaximumFIOLength)
                .WithMessage("Фамилия не может быть больше 50 символов.");

            RuleFor(person => person.MiddleName)
                .MinimumLength(ConstansForValidators.MinimumFIOLength)
                .WithMessage("Имя не может быть меньше 2 символов.")
                .MaximumLength(ConstansForValidators.MaximumFIOLength)
                .WithMessage("Отчество не может быть больше 50 символов.")
                .When(person => !string.IsNullOrEmpty(person.MiddleName));
        }     
    }
}