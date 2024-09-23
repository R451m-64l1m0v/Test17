using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface IPlotService
    {        
        Task<Plot> CheckPlot(int numberPlot);
    }
}
