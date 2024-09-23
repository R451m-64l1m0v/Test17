using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Models.Abstractions;
using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Models.Doctors.Request
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
