using FluentValidation;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient;

namespace RegisterToDoctor.WebSell.Validators.PatientValidators
{
    public class UpdatePatientValidator : AbstractValidator<IUpdatePatientInDto>
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