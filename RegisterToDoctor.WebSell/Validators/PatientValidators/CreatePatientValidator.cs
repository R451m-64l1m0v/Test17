﻿using FluentValidation;
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
                .Must(IsValidAge)
                .WithMessage(x => $"Ошибка: дата рождения {x.DateOfBirth.ToString("dd/MM/yyyy")} некорректна.");

            RuleFor(x => x.OmsNumber)
                .Length(ConstansForValidators.OmsLength)
                .WithMessage($"Ошибка: в OmsNumber должно быть {ConstansForValidators.OmsLength} чисел.")
                .Must(omsNumber => omsNumber.All(char.IsDigit))
                .WithMessage("Ошибка: в OmsNumber должно содержать только цифры.");

            //RuleFor(x => x.DmsNumber)
            //.Must(dmsNumber => dmsNumber.Trim().Length > 0)
            //.WithMessage("Ошибка: в DmsNumber не должен содержать тольно пробелы.");

            RuleFor(doctor => doctor.Address)
                .NotEmpty()
                .WithMessage("Ошибка: Специальность не может быть пустой.")
                .MaximumLength(100)
                .WithMessage("Ошибка: Специальность не должна быть больше 100 символов.");           

            RuleFor(doctor => doctor.NumberPlot)
                .GreaterThan(0).WithMessage("Ошибка: Номер участка должен быть больше нуля.");
        }

        private bool IsValidAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            return age <= ConstansForValidators.maxAge && age >= ConstansForValidators.minAge;
        }
    }
}