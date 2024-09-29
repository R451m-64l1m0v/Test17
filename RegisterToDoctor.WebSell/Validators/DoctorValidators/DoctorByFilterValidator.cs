using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;

namespace RegisterToDoctor.WebSell.Validators.DoctorValidators
{
    public class DoctorByFilterValidator : AbstractValidator<IGetDoctorFindByFilterInDto>
    {
        public DoctorByFilterValidator()
        {
            RuleFor(x => x)
                .SetValidator(new ByFilterInDtoValidator());
        }
    }
}