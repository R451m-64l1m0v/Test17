using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs;
using RegisterToDoctor.WebSell.Models.Abstractions;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Сonstants;

namespace RegisterToDoctor.WebSell.Validators
{
    public class ByFilterRequestValidator : AbstractValidator<IByFilterInDto>
    {
        public ByFilterRequestValidator() 
        {
            RuleFor(doctor => doctor.PageNumber)
            .GreaterThan(0)
            .WithMessage($"Ошибка: {nameof(DoctorByFilterInDto.PageNumber)} должен быть больше нуля.");

            RuleFor(x => x.PageSizeMin)
            .GreaterThanOrEqualTo(0)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterInDto.PageSizeMin)} должно быть больше или равно нулю.");

            RuleFor(x => x.PageSizeMax)
            .GreaterThan(x => x.PageSizeMin)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterInDto.PageSizeMax)} " +
                         $"должно быть больше {nameof(DoctorByFilterInDto.PageSizeMin)}.")
            .LessThanOrEqualTo(ConstansForValidators.PageSizeLimit)
            .WithMessage($"Ошибка: поле {nameof(DoctorByFilterInDto.PageSizeMax)} " +
                         $"не может превышать {ConstansForValidators.PageSizeLimit} на странице.");
        }
    }
}
