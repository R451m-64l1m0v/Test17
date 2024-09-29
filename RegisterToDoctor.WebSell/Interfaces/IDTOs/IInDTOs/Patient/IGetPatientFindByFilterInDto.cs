using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient
{
    public interface IGetPatientFindByFilterInDto : IFindByFilterInDto
    {
        public PatientSortField SortField { get;}
    }
}
