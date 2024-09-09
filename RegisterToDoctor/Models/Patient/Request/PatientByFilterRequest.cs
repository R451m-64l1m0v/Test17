using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Models.Patient.Request
{
    public class PatientByFilterRequest
    {
        /// <summary>
        /// Сортировачное поле
        /// </summary>
        [FromQuery]
        public PatientSortField SortField { get; set; }

        /// <summary>
        /// Упорядочить
        /// </summary>
        [FromQuery]
        public bool Ascending { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        [FromQuery]
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество записей на странице
        /// </summary>
        [FromQuery]
        public int PageSize { get; set; }        
    }
}
