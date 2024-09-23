using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Enum;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class DoctorByFilterRequest : ByFilterRequest
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>
        [JsonPropertyName("SortField")]
        [FromQuery]
        public DoctorSortField SortField { get; set; }        
    }
}
