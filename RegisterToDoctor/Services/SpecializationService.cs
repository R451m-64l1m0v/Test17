using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class SpecializationService : ISpecializationService
    {
        private readonly IDbRepository<Specialization> _specializationRepository;

        public SpecializationService(IUnitOfWork uow)
        {
            _specializationRepository = uow.DbRepository<Specialization>();
        }
        
        public async Task<Specialization> CheckSpecialization(string specializationName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(specializationName))                
                    throw new ArgumentException($"Ошибка поле спечиальность не заполнено");

                var existsSpecialization = await GetSpecialization(specializationName);                    

                if (existsSpecialization != null)
                {
                    return existsSpecialization;
                }

                var specialization = CreateSpecialization(specializationName);

                return specialization;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private Specialization CreateSpecialization(string specializationName)
        {
            try
            {               
                var specialization = new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = specializationName.ToLower(),
                };

                _specializationRepository.Create(specialization);

                return specialization;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task<Specialization> GetSpecialization(string specializationName) 
        {
            var specialization = _specializationRepository
                .GetAll()
                .FirstOrDefault(x => x.Name == specializationName.ToLower());                                 

            return specialization;
        }
    }
}
