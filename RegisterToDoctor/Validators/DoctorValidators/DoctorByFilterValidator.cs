using FluentValidation;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Сonstants;

namespace RegisterToDoctor.Validators.DoctorValidators
{
    public class DoctorByFilterValidator : AbstractValidator<DoctorByFilterRequest>
    {
        public DoctorByFilterValidator()
        {
            RuleFor(doctor => doctor.PageNumber)
            .GreaterThan(0)
            .WithMessage($"Ошибка: {nameof(DoctorByFilterRequest.PageNumber)} должен быть больше нуля.");

            RuleFor(x => x.PageSizeMin)
            .GreaterThanOrEqualTo(0)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterRequest.PageSizeMin)} должно быть больше или равно нулю.");

            RuleFor(x => x.PageSizeMax)
            .GreaterThan(x => x.PageSizeMin)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterRequest.PageSizeMax)} " +
                         $"должно быть больше {nameof(DoctorByFilterRequest.PageSizeMin)}.");

            RuleFor(x => x.PageSizeMax)
            .GreaterThan(x => x.PageSizeMin)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterRequest.PageSizeMax)} " +
                         $"должно быть больше {nameof(DoctorByFilterRequest.PageSizeMin)}.")
            .LessThanOrEqualTo(ConstansForValidators.PageSizeLimit)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterRequest.PageSizeMax)} " +
                         $"не может превышать {ConstansForValidators.PageSizeLimit} на странице.");
        }
    }
}
