using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorResponse : РersonBase
    {
        public Guid Id { get; set; }
        public Guid OfficeId { get; set; }

        public Guid SpecializationId { get; set; }

        public Guid PlotId { get; set; }
    }
}
