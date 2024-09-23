using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domain.Core.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class OfficeService : IOfficeService
    {
        private readonly IDbRepository<Office> _officeRepository;

        public OfficeService(IUnitOfWork uow) 
        {
            _officeRepository = uow.DbRepository<Office>();
        }

        public async Task<Office> CheckOffice(int numberOffice)
        {
            try
            {
                if (numberOffice == 0)                
                    throw new ArgumentException($"Ошибка номер кабинета не может быть 0.");
                
                var existsOffice = await GetOffice(numberOffice);

                if (existsOffice != null)
                {
                    return existsOffice;
                }

                var office = await CreateOffice(numberOffice);

                return office;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<Office> CreateOffice(int numberOffice)
        {
            try
            {
                var office = new Office
                {
                    Id = Guid.NewGuid(),
                    Number = numberOffice,
                };

                await _officeRepository.CreateAsync(office);

                return office;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<Office> GetOffice(int numberOffice)
        {
            var offices = await _officeRepository.Entity
                .FirstOrDefaultAsync(x => x.Number == numberOffice);                    

            return offices;
        }
    }
}
