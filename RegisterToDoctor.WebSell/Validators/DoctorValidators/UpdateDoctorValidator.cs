using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;

namespace RegisterToDoctor.WebSell.Validators.DoctorValidators
{
    public class UpdateDoctorValidator : AbstractValidator<IUpdateDoctorInDto>
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
