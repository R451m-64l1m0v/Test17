using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient
{
    public class GetPatientFindByFilterInDto : IGetPatientFindByFilterInDto
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>        
        [JsonPropertyName("SortField")]
        [FromQuery]
        public PatientSortField SortField { get; set; }

        /// <summary>
        /// Упорядочить
        /// </summary>        
        [JsonPropertyName("Ascending")]
        [FromQuery]
        public bool Ascending { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>        
        [JsonPropertyName("PageNumber")]
        [FromQuery]
        public int PageNumber { get; set; }

        /// <summary>
        /// Минимальное значение количества записей на странице
        /// </summary>
        [JsonPropertyName("PageSizeMin")]
        [FromQuery]
        public int PageSizeMin { get; set; }

        /// <summary>
        /// Максимальное значение количества записей на странице
        /// </summary>
        [JsonPropertyName("PageSizeMax")]
        [FromQuery]
        public int PageSizeMax { get; set; }
    }
}
