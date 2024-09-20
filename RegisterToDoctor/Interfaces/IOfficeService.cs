using RegisterToDoctor.Domen.Core.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface IOfficeService
    {        
        Task<Office> CheckOffice(int numberOffice);
    }
}
