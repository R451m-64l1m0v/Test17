using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Models.Abstractions;
using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Models.Patient.Request
{
    public class PatientByFilterRequest : ByFilterRequest
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>        
        [JsonPropertyName("SortField")]
        [FromQuery]
        public PatientSortField SortField { get; set; }        
    }
}
