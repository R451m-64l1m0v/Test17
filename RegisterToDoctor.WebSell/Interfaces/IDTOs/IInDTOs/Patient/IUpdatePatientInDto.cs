namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient
{
    public interface IUpdatePatientInDto : ICreatePatientInDto
    {
        public Guid Id { get; }
    }
}
