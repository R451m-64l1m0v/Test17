using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.WebSell.Interfaces.Markers;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface IPlotService 
    {        
        Task<Plot> CheckPlot(int numberPlot);
    }
}
