namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor
{
    public interface ICreateDoctorInDto : IPerson
    {
        int NumberOffice { get; }
        string Specialization { get; }
        int NumberPlot { get; }
    }
}
