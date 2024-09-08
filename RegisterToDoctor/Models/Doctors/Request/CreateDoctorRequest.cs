using Microsoft.AspNetCore.Identity;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class CreateDoctorRequest : РersonBase
    {
        public int NumberOffice { get; set; }

        public string Specialization { get; set; }

        public int  NumberPlot { get; set; }
    }
}
