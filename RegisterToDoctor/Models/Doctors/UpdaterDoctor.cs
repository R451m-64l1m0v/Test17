using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Models.Doctors
{
    public class UpdaterDoctor : ICreateDoctor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public Guid OfficeId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid PlotId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static UpdaterDoctor Create(UpdateDoctorRequest updateDoctor, Guid specializationId, Guid officeId, Guid plotId)
        {
            return new UpdaterDoctor
            {
                Id = updateDoctor.Id,
                FirstName = updateDoctor.FirstName,
                LastName = updateDoctor.LastName,
                MiddleName = updateDoctor.MiddleName,
                OfficeId = officeId,
                SpecializationId = specializationId,
                PlotId = plotId,
                UpdatedAt = DateTime.UtcNow.Date,
            };
        }
    }
}
