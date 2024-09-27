namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor
{
    public interface IUpdateDoctorInDto : ICreateDoctorInDto
    {
        public Guid Id { get; }
    }
}
