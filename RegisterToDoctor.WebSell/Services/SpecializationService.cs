using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.WebSell.Attributes;
using RegisterToDoctor.WebSell.Interfaces.IServices;
using RegisterToDoctor.WebSell.Interfaces.Markers;

namespace RegisterToDoctor.WebSell.Services
{
    public class SpecializationService : ISpecializationService, IScopedServiceMarker
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
                    throw new ArgumentException($"Ошибка поле спечиальность не заполнено.");

                var existsSpecialization = await GetSpecialization(specializationName);                    

                if (existsSpecialization != null)
                {
                    return existsSpecialization;
                }

                var specialization = await CreateSpecialization(specializationName);

                return specialization;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<Specialization> CreateSpecialization(string specializationName)
        {
            try
            {               
                var specialization = new Specialization
                {
                    Id = Guid.NewGuid(),
                    Name = specializationName.ToLower(),
                };

                await _specializationRepository.CreateAsync(specialization);

                return specialization;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<Specialization> GetSpecialization(string specializationName) 
        {
            var specialization = await _specializationRepository.Entity
                .FirstOrDefaultAsync(x => x.Name == specializationName.ToLower());                                                 

            return specialization;
        }
    }
}
