using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;

namespace RegisterToDoctor.WebSell.Validators.DoctorValidators
{
    public class DoctorByFilterValidator : AbstractValidator<IDoctorByFilterInDto>
    {
        public DoctorByFilterValidator()
        {
            RuleFor(x => x)
                .SetValidator(new ByFilterRequestValidator());
        }
    }
}