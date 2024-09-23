using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Models.Patient.Request
{
    public class PatientByFilterRequest : ByFilterRequest
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>        
        [FromQuery]
        public PatientSortField SortField { get; set; }        
    }
}
