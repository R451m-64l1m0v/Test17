using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    throw new ArgumentException($"Ошибка номер кабинета не может быть 0");
                
                var existsOffice = await GetOffice(numberOffice);

                if (existsOffice != null)
                {
                    return existsOffice;
                }

                var office = CreateOffice(numberOffice);

                return office;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private Office CreateOffice(int numberOffice)
        {
            try
            {
                var office = new Office
                {
                    Id = Guid.NewGuid(),
                    Number = numberOffice,
                };

                _officeRepository.Create(office);

                return office;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task<Office> GetOffice(int numberOffice)
        {
            var offices = _officeRepository
                .GetAll()
                .FirstOrDefault(x => x.Number == numberOffice);                    

            return offices;
        }
    }
}
