using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Patient.Request;

namespace RegisterToDoctor.Models.Patient
{
    public class CreatorPatient : ICreatePatient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public Guid PlotId { get; set; }
        public string OmsNumber { get; set; }
        public string? DmsNumber { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static CreatorPatient Create(CreatePatientRequest createPatient, Guid plotId)
        {
            return new CreatorPatient
            {
                Id = Guid.NewGuid(),
                FirstName = createPatient.FirstName,
                LastName = createPatient.LastName,
                MiddleName = createPatient.MiddleName,
                DateOfBirth = createPatient.DateOfBirth,
                Address = createPatient.Address,
                Gender = createPatient.Gender,
                OmsNumber = createPatient.OmsNumber,
                DmsNumber = createPatient.DmsNumber,
                PlotId = plotId,
                UpdatedAt = null,
            };
        }
    }    
}
