using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces;
using RegisterToDoctor.WebSell.Models.Abstractions;

namespace RegisterToDoctor.WebSell.Models.Doctors.Request
{
    public class CreateDoctorRequest : Рerson, ICreateDoctorRequest
    {
        
        public int NumberOffice { get; set; }

        
        public string Specialization { get; set; }

        
        public int  NumberPlot { get; set; }
    }
}
