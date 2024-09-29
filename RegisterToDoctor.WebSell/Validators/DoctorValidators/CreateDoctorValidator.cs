using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;
using RegisterToDoctor.WebSell.Сonstants;

namespace RegisterToDoctor.WebSell.Validators.DoctorValidators
{
    public class CreateDoctorValidator : AbstractValidator<ICreateDoctorInDto>
    {
        public CreateDoctorValidator()
        {
            RuleFor(doctor => doctor)
                .SetValidator(new UserEntityValidator());

            RuleFor(doctor => doctor.NumberOffice)
                .GreaterThan(ConstansForValidators.NotPositiveNumber).WithMessage("Ошибка: Номер кабинета должен быть больше нуля.");

            RuleFor(doctor => doctor.Specialization)
                .NotEmpty().WithMessage("Ошибка: Специальность не может быть пустой.")
                .MaximumLength(ConstansForValidators.MaximumSpecializationNameLength).WithMessage("Ошибка: Специальность не должна быть больше 100 символов.");

            RuleFor(doctor => doctor.NumberPlot)
                .GreaterThan(ConstansForValidators.NotPositiveNumber).WithMessage("Ошибка: Номер участка должен быть больше нуля.");
        }
    }
}