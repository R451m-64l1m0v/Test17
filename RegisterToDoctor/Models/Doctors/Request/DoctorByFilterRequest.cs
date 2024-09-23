using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class DoctorByFilterRequest : ByFilterRequest
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>        
        [FromQuery]
        public DoctorSortField SortField { get; set; }        
    }
}
