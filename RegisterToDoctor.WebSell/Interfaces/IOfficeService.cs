﻿using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.WebSell.Interfaces.Markers;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface IOfficeService
    {        
        Task<Office> CheckOffice(int numberOffice);
    }
}
