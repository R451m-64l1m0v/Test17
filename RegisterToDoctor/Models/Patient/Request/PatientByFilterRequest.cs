using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Enum;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Request
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
