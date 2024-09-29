using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient;

namespace RegisterToDoctor.WebSell.Validators.PatientValidators
{
    public class PatientByFilterValidator : AbstractValidator<IPatientByFilterInDto>
    {
        public PatientByFilterValidator()
        {
            RuleFor(x => x)
                .SetValidator(new ByFilterInDtoValidator());
        }
    }
}