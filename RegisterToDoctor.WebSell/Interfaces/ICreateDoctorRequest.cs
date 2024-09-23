using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface ICreateDoctorRequest : IPerson 
    {
        int NumberOffice { get; }
        string Specialization { get; }
        int NumberPlot { get; }
    }
}
