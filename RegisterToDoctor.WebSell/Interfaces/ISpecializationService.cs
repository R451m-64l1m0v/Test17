using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.WebSell.Interfaces.Markers;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface ISpecializationService
    {        
        Task<Specialization> CheckSpecialization(string specialization);
    }
}
