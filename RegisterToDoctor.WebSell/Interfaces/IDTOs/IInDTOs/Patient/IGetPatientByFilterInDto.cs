using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient
{
    public interface IGetPatientByFilterInDto : IGetByFilterInDto
    {
        public PatientSortField SortField { get;}
    }
}
