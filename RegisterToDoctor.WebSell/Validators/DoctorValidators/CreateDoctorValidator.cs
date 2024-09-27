using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;

namespace RegisterToDoctor.WebSell.Validators.DoctorValidators
{
    public class CreateDoctorValidator : AbstractValidator<ICreateDoctorInDto>
    {
        public CreateDoctorValidator()
        {
            RuleFor(doctor => doctor)
            .SetValidator(new UserEntityValidator());

            RuleFor(doctor => doctor.NumberOffice)
            .GreaterThan(0).WithMessage("Ошибка: Номер каминета должен быть больше нуля.");

            RuleFor(doctor => doctor.Specialization)
            .NotEmpty().WithMessage("Ошибка: Специальность не может быть пустой.")
            .MaximumLength(100).WithMessage("Ошибка: Специальность не должна быть больше 100 символов.");

            RuleFor(doctor => doctor.NumberPlot)
            .GreaterThan(0).WithMessage("Ошибка: Номер участка должен быть больше нуля.");
        }
    }
}
