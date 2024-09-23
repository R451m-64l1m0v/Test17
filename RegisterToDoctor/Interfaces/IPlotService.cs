using RegisterToDoctor.Domain.Core.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface IPlotService
    {        
        Task<Plot> CheckPlot(int numberPlot);
    }
}
