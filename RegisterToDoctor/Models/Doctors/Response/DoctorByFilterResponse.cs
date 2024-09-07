using Microsoft.AspNetCore.Mvc;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByFilterResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
        
        public int NumberOffice { get; set; }

        public string Specialization { get; set; }

        public int NumberPlot { get; set; }
    }
}
