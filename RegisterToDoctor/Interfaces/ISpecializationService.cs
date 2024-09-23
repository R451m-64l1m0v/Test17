using RegisterToDoctor.Domain.Core.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface ISpecializationService
    {        
        Task<Specialization> CheckSpecialization(string specialization);
    }
}
