using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Сonstants;

namespace RegisterToDoctor.WebSell.Validators.PatientValidators
{
    public class CreatePatientValidator : AbstractValidator<ICreatePatientInDto>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x)
                .SetValidator(new UserEntityValidator());

            RuleFor(x => x.DateOfBirth)
                .Must(IsValidMaxAge)
                .WithMessage(x => $"Ошибка: дата рождения {x.DateOfBirth.ToString("dd/MM/yyyy")} некорректна. Возраст не может превышать 135 лет")
                .Must(IsValidMinAge)
                .WithMessage(x => $"Ошибка: дата рождения {x.DateOfBirth.ToString("dd/MM/yyyy")} некорректна. Возраст не может превышать сегодняшний день");

            RuleFor(x => x.OmsNumber)
                .Length(ConstansForValidators.OmsLength)
                .WithMessage($"Ошибка: в OmsNumber должно быть {ConstansForValidators.OmsLength} чисел.")
                .Must(omsNumber => omsNumber.All(char.IsDigit))
                .WithMessage("Ошибка: в OmsNumber должно содержать только цифры.");

            RuleFor(x => x.DmsNumber)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Ошибка: в DmsNumber не должен содержать тольно пробелы.");

            RuleFor(doctor => doctor.Address)
                .NotEmpty()
                .WithMessage("Ошибка: Специальность не может быть пустой.")
                .MaximumLength(ConstansForValidators.MaximumAddressLength)
                .WithMessage("Ошибка: Специальность не должна быть больше 150 символов.");

            RuleFor(doctor => doctor.NumberPlot)
                .GreaterThan(ConstansForValidators.NotPositiveNumber).WithMessage("Ошибка: Номер участка должен быть больше нуля.");
        }

        private bool IsValidMaxAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            return age <= ConstansForValidators.maxAge;
        }

        private bool IsValidMinAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            return age >= ConstansForValidators.minAge;
        }
    }
}