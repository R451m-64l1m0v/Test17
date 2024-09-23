using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface ISpecializationService
    {        
        Task<Specialization> CheckSpecialization(string specialization);
    }
}
