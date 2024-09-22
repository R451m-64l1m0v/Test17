using FluentValidation;
using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Validators.DoctorValidators
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctorRequest>
    {
        public UpdateDoctorValidator()
        {
            RuleFor(doctor => doctor.Id)
            .SetValidator(new GuidValidator());

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
