using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class PlotService : IPlotService
    {
        private readonly IDbRepository<Plot> _plotRepository;

        public PlotService(IUnitOfWork uow) 
        {
            _plotRepository = uow.DbRepository<Plot>();
        }

        public async Task<Plot> CheckPlot(int numberPlot)
        {
            try
            {
                if (numberPlot == 0)
                    throw new ArgumentException($"Ошибка номер участка не может быть 0");

                var existsPlot = await GetPlot(numberPlot);

                if (existsPlot != null)
                {
                    return existsPlot;
                }

                var plot = CreatePlot(numberPlot);

                return plot;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private Plot CreatePlot(int numberPlot)
        {
            try
            {
                var plot = new Plot
                {
                    Id = Guid.NewGuid(),
                    Number = numberPlot,
                };

                _plotRepository.Create(plot);

                return plot;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private async Task<Plot> GetPlot(int numberPlot)
        {
            var specialization = _plotRepository
                .GetAll()
                .FirstOrDefault(x => x.Number == numberPlot);                   

            return specialization;
        }
    }
}
