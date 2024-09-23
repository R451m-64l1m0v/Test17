using FluentValidation;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Validators.DoctorValidators;

namespace RegisterToDoctor.Validators.PatientValidators
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
