using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;

namespace RegisterToDoctor.WebSell.Validators.PatientValidators
{
    public class PatientByFilterValidator : AbstractValidator<IGetPatientByFilterInDto>
    {
        public PatientByFilterValidator()
        {
            RuleFor(x => x)
                .SetValidator(new ByFilterInDtoValidator());
        }
    }
}