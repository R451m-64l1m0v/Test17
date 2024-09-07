using RegisterToDoctor.Models.Doctors.Base;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorResponse : РersonBase
    {
        public int NumberOffice { get; set; }

        public string Specialization { get; set; }

        public int NumberPlot { get; set; }
    }
}
