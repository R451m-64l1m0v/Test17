using FluentValidation;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Сonstants;

namespace RegisterToDoctor.Validators.DoctorValidators
{
    public class DoctorByFilterValidator : AbstractValidator<DoctorByFilterRequest>
    {
        public DoctorByFilterValidator()
        {
            RuleFor(x => x)
            .SetValidator(new ByFilterRequestValidator());
        }
    }
}
