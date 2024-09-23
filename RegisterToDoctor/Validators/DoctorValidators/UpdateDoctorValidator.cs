using FluentValidation;
using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Validators.DoctorValidators
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctorRequest>
    {
        public UpdateDoctorValidator()
        {
            RuleFor(doctor => doctor.Id)
            .SetValidator(new GuidValidator());            

            RuleFor(doctor => doctor)
            .SetValidator(new CreateDoctorValidator());           
        }
    }
}
