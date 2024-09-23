using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface IOfficeService
    {        
        Task<Office> CheckOffice(int numberOffice);
    }
}
