using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Models.Doctors
{
    public class CreatorDoctor : ICreateDoctor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public Guid OfficeId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid PlotId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static CreatorDoctor Create(CreateDoctorRequest createDoctor, Guid specializationId, Guid officeId, Guid plotId)
        {
            return new CreatorDoctor
            {
                Id = Guid.NewGuid(),
                FirstName = createDoctor.FirstName,
                LastName = createDoctor.LastName,
                MiddleName = createDoctor.MiddleName,
                OfficeId = officeId,
                SpecializationId = specializationId,
                PlotId = plotId,
                UpdatedAt = null,
            };
        }
    }
}
