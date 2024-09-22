using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class DoctorByFilterRequest
    {

        /// <summary>
        /// Сортировачное поле
        /// </summary>        
        [FromQuery]
        public DoctorSortField SortField { get; set; }

        /// <summary>
        /// Упорядочить
        /// </summary>        
        [FromQuery]
        public bool Ascending {  get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>        
        [FromQuery]
        public int PageNumber { get; set; }

        /// <summary>
        /// Минимальное значение количества записей на странице
        /// </summary>
        [FromQuery]
        public int PageSizeMin { get; set; }

        /// <summary>
        /// Максимальное значение количества записей на странице
        /// </summary>
        [FromQuery]
        public int PageSizeMax { get; set; }
    }
}
