using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor
{
    public class GetDoctorFindByFilterInDto : IGetDoctorFindByFilterInDto
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>
        [JsonPropertyName("SortField")]
        public DoctorSortField SortField { get; set; }

        /// <summary>
        /// Упорядочить
        /// </summary>        
        [JsonPropertyName("SortOrder")]
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>        
        [JsonPropertyName("PageNumber")]
        public int PageNumber { get; set; }
        
        /// <summary>
        /// Количества записей на странице
        /// </summary>
        [JsonPropertyName("PageSize")]
        public int PageSize { get; set; }
    }
}
