using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient
{
    public interface IPatientByFilterInDto : IByFilterInDto
    {
        public PatientSortField SortField { get;}
    }
}
