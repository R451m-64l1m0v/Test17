using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.Infrastructure.DataAccessLayer.Interfaces;
using RegisterToDoctor.WebSell.Attributes;
using RegisterToDoctor.WebSell.Interfaces.IServices;
using RegisterToDoctor.WebSell.Interfaces.Markers;

namespace RegisterToDoctor.WebSell.Services
{
    public class PlotService : IPlotService, IScopedServiceMarker
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
                    throw new ArgumentException($"Ошибка номер участка не может быть 0.");

                var existsPlot = await GetPlot(numberPlot);

                if (existsPlot != null)
                {
                    return existsPlot;
                }

                var plot = await CreatePlot(numberPlot);

                return plot;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private async Task<Plot> CreatePlot(int numberPlot)
        {
            try
            {
                var plot = new Plot
                {
                    Id = Guid.NewGuid(),
                    Number = numberPlot,
                };

                await _plotRepository.CreateAsync(plot);

                return plot;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private async Task<Plot> GetPlot(int numberPlot)
        {
            var specialization = await _plotRepository.Entity
                .FirstOrDefaultAsync(x => x.Number == numberPlot);                   

            return specialization;
        }
    }
}