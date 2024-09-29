using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Сonstants;

namespace RegisterToDoctor.WebSell.Validators
{
    public class ByFilterInDtoValidator : AbstractValidator<IGetByFilterInDto>
    {
        public ByFilterInDtoValidator() 
        {
            RuleFor(doctor => doctor.PageNumber)
                .GreaterThan(0)
                .WithMessage($"Ошибка: {nameof(GetDoctorByFilterInDto.PageNumber)} должен быть больше нуля.");

            RuleFor(x => x.PageSizeMin)
                .GreaterThanOrEqualTo(0)
                .WithMessage($"Ошибка: поле {nameof(GetDoctorByFilterInDto.PageSizeMin)} должно быть больше или равно нулю.");

            RuleFor(x => x.PageSizeMax)
                .GreaterThan(x => x.PageSizeMin)
                .WithMessage($"Ошибка: поле {nameof(GetDoctorByFilterInDto.PageSizeMax)} " +
                             $"должно быть больше {nameof(GetDoctorByFilterInDto.PageSizeMin)}.")
                .LessThanOrEqualTo(ConstansForValidators.PageSizeLimit)
                .WithMessage($"Ошибка: поле {nameof(GetDoctorByFilterInDto.PageSizeMax)} " +
                             $"не может превышать {ConstansForValidators.PageSizeLimit} на странице.");
        }
    }
}