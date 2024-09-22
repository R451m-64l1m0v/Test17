﻿using FluentValidation;
using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Validators
{
    public class UserEntityValidator : AbstractValidator<Рerson>
    {
        public UserEntityValidator()
        {
            RuleFor(person => person.FirstName)
            .NotEmpty().WithMessage("Необходимо указать Имя.")
            .MaximumLength(50).WithMessage("Имя не может быть больше 50 символов.");

            RuleFor(person => person.LastName)
            .NotEmpty().WithMessage("Необходимо указать Фамилия.")
            .MaximumLength(50).WithMessage("Фамилия не может быть больше 50 символов.");

            RuleFor(person => person.MiddleName)
            .MaximumLength(50).WithMessage("Отчество не может быть больше 50 символов.")
            .When(person => !string.IsNullOrEmpty(person.MiddleName));
        }     
    }
}
