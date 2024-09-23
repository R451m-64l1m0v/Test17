using RegisterToDoctor.Domain.Core.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface IOfficeService
    {        
        Task<Office> CheckOffice(int numberOffice);
    }
}
