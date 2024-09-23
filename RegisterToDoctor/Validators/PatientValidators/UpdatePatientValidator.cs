using FluentValidation;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Validators.DoctorValidators;

namespace RegisterToDoctor.Validators.PatientValidators
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
