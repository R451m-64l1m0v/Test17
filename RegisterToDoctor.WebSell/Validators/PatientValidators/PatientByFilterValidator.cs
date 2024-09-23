using FluentValidation;
using RegisterToDoctor.WebSell.Models.Patient.Request;

namespace RegisterToDoctor.WebSell.Validators.PatientValidators
{
    public class PatientByFilterValidator : AbstractValidator<PatientByFilterRequest>
    {
        public PatientByFilterValidator()
        {
            RuleFor(x => x)
            .SetValidator(new ByFilterRequestValidator());
        }
    }
}
