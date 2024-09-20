using RegisterToDoctor.Domen.Core.Entities;

namespace RegisterToDoctor.Interfaces
{
    public interface IPlotService
    {        
        Task<Plot> CheckPlot(int numberPlot);
    }
}
