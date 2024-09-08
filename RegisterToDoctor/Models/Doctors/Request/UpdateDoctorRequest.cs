using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class UpdateDoctorRequest : РersonBase
    {
        public int NumberOffice { get; set; }

        public string Specialization { get; set; }

        public int NumberPlot { get; set; }
    }
}
