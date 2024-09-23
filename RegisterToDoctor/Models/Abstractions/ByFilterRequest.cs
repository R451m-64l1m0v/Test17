using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Abstractions
{
    public abstract class ByFilterRequest
    {
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
