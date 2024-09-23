using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface ISpecializationService
    {        
        Task<Specialization> CheckSpecialization(string specialization);
    }
}
