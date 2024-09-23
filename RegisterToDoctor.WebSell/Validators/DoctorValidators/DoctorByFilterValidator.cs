using FluentValidation;
using RegisterToDoctor.WebSell.Models.Doctors.Request;

namespace RegisterToDoctor.WebSell.Validators.DoctorValidators
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
