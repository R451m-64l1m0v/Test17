using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface IPlotService
    {        
        Task<Plot> CheckPlot(int numberPlot);
    }
}
