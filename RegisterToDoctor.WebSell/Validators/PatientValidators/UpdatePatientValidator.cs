using FluentValidation;
using RegisterToDoctor.WebSell.Models.Patient.Request;

namespace RegisterToDoctor.WebSell.Validators.PatientValidators
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientRequest>
    {
        public UpdatePatientValidator() 
        {
            RuleFor(doctor => doctor.Id)
            .SetValidator(new GuidValidator());

            RuleFor(doctor => doctor)
            .SetValidator(new CreatePatientValidator());
        }
    }
}
