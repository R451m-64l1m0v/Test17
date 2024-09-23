using Microsoft.AspNetCore.Mvc;

namespace RegisterToDoctor.Models.Abstractions
{
    public abstract class ByFilterRequest
    {
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
