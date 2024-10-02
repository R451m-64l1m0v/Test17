using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Сonstants;

namespace RegisterToDoctor.WebSell.Validators
{
    public class ByFilterInDtoValidator : AbstractValidator<IFindByFilterInDto>
    {
        public ByFilterInDtoValidator() 
        {
            RuleFor(doctor => doctor.PageNumber)
                .GreaterThan(ConstansForValidators.NotPositiveNumber)
                .WithMessage($"Ошибка: {nameof(GetDoctorFindByFilterInDto.PageNumber)} должен быть больше нуля.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(ConstansForValidators.NotPositiveNumber)
                .WithMessage($"Ошибка: поле {nameof(GetDoctorFindByFilterInDto.PageSize)} должно быть больше или равно нулю.");

            RuleFor(x => x.PageSize)
                .LessThanOrEqualTo(ConstansForValidators.MaxPageSize)
                .WithMessage($"Ошибка: поле {nameof(GetDoctorFindByFilterInDto.PageSize)} " +
                             $"не может превышать {ConstansForValidators.MaxPageSize} на странице.");
        }
    }
}