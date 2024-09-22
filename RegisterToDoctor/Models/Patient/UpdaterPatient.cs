using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;
using RegisterToDoctor.Models.Patient.Request;

namespace RegisterToDoctor.Models.Patient
{
    public class UpdaterPatient : ICreatePatient
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

        public static UpdaterPatient Create(UpdatePatientRequest updatePatient, Guid plotId)
        {
            return new UpdaterPatient
            {
                Id = updatePatient.Id,
                FirstName = updatePatient.FirstName,
                LastName = updatePatient.LastName,
                MiddleName = updatePatient.MiddleName,
                DateOfBirth = updatePatient.DateOfBirth,
                Address = updatePatient.Address,
                Gender = updatePatient.Gender,
                OmsNumber = updatePatient.OmsNumber,
                DmsNumber = updatePatient.DmsNumber,
                PlotId = plotId,
                UpdatedAt = DateTime.UtcNow.Date,
            };
        }
    }
}
